namespace GestionExpropaciones.Common;

public class AppSettings
{
    public LoggingSettings Logging { get; set; }
    public GoogleKeysSettings GoogleKeys { get; set; }
    public ConnectionStringsSettings ConnectionStrings { get; set; }
    public string AllowedHosts { get; set; }
}

public class LoggingSettings
{
    public LogLevelSettings LogLevel { get; set; }
}

public class LogLevelSettings
{
    public string Default { get; set; }
    public string MicrosoftAspNetCore { get; set; }
}

public class GoogleKeysSettings
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

public class ConnectionStringsSettings
{
    public string AppConnection { get; set; }
}
