using DbUp.Engine;
using DbUp.Engine.Preprocessors;

namespace F1.DbUp
{
    /// <summary>
    /// Overrides the default DbUp variable delimiter '$' because it's not a good match for postgresql dialect
    /// </summary>
    public class VariableSubstitutionPostgresqlParser : VariableSubstitutionSqlParser
    {
        public VariableSubstitutionPostgresqlParser(string sqlText, string delimiter = "GO", bool delimiterRequiresWhitespace = true) : base(sqlText, delimiter, delimiterRequiresWhitespace)
        {
        }
        protected override char VariableDelimiter => '~';
    }

    /// <summary>
    /// Substitutes variables for values in SqlScripts
    /// </summary>
    public class PostgresVariableSubstitutionPreprocessor : IScriptPreprocessor
    {
        private readonly IDictionary<string, string> _variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableSubstitutionPreprocessor"/> class.
        /// </summary>
        /// <param name="variables">The variables.</param>
        public PostgresVariableSubstitutionPreprocessor(IDictionary<string, string> variables)
        {
            _variables = variables ?? throw new ArgumentNullException(nameof(variables));
        }

        /// <summary>
        /// Substitutes variables 
        /// </summary>
        /// <param name="contents"></param>
        public string Process(string contents)
        {
            using (var parser = new VariableSubstitutionPostgresqlParser(contents))
            {
                return parser.ReplaceVariables(_variables);
            }
        }
    }

}
    
    