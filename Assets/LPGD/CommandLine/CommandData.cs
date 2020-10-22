namespace LPGD.CommandLine
{
    [System.Serializable]
    public class CommandData
    {
        public string commandName;

        public CommandParameter[] parameters;
    }

    [System.Serializable]
    public class CommandParameter
    {
        public string parameterName;
        public ExpectedParameterValueType expectedParameterValueType;
    }

    public enum ExpectedParameterValueType
    {
        Int, Float, String, Double, Long, Char
    }
}