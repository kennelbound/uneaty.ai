public class SimpleAIOutputConfig
{
    public SimpleAIOutputConfig(string outputKey, OutputType type)
    {
        Type = type;
        OutputKey = outputKey;
    }

    public OutputType Type { get; set; }
    public string OutputKey { get; set; }
}