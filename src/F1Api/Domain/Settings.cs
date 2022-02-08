namespace F1Api.Domain;

public class Settings
{
    public static string Get(string key, IConfiguration configuration)
    {
        var setting = configuration.GetValue<string>($"MySettings:{key}");
        if (string.IsNullOrEmpty(setting))
        {
            throw new Exception("Missing environment variable: " + key);
        }
        return setting;
    }
}