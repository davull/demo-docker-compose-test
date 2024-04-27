namespace Demo_TestContainers;

public static class Configuration
{
    public static string DatabaseServer => GetEnv("DB_SERVER");
    public static uint DatabasePort => uint.Parse(GetEnv("DB_PORT", "3306"));
    public static string DatabaseName => GetEnv("DB_NAME");
    public static string DatabaseUser => GetEnv("DB_USER");
    public static string DatabasePassword => GetEnv("DB_PASSWORD");

    private static string GetEnv(string name, string defaultValue = "")
    {
        var value = Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
    }
}