using System.Reflection;
using DbUp;
using DbUp.Engine;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace F1.DbUp
{
    class Program
    {
        static int Main(string[] args)
        {
            // setup logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(new CompactJsonFormatter())
                .CreateLogger();

            try
            {
                var constring = args.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(constring))
                {
                    constring = "To be changed as normal connection string"; //Settings.Get("RESERVATIONQUERY_DB_CONNECTION");
                }

                var result = UpgradeDatabase(constring);

                if (!result.Successful)
                {
                    return -1;
                }

                Log.Logger.Debug("DbUp completed");
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Host terminated unexpectedly");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            return 0;
        }

        private static DatabaseUpgradeResult UpgradeDatabase(string constring)
        {

            DoWithRetry(() => EnsureDatabase.For.PostgresqlDatabase(constring));

            var variables = new Dictionary<string, string>();

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(constring)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToAutodetectedLog()
                .WithPreprocessor(new PostgresVariableSubstitutionPreprocessor(variables))
                .WithVariablesDisabled()
                .Build();

            var result = upgrader.PerformUpgrade();
            return result;
        }

        static void DoWithRetry(Action action)
        {
            var maxRetries = 10;
            var waitBetweenRetrySec = 3;
            var retryCount = 1;
            while (retryCount <= maxRetries)
            {
                try
                {
                    action();
                    break;
                }
                catch (Exception ex)
                {
                    if (maxRetries <= 0)
                    {
                        throw;
                    }
                    else
                    {
                        Log.Information(ex, "Encountered exception {0}, retrying operation", ex.ToString());
                        var sleepTime = TimeSpan.FromSeconds(waitBetweenRetrySec);
                        Thread.Sleep(sleepTime);
                        retryCount++;
                    }
                }
            }
        }
    }
}
