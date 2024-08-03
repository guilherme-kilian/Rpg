namespace Rpg.Api;

public class AppSettings
{
    public int Test { get; set; }
    public IEnumerable<IdentitySettings> Identities { get; set; }
}

public class IdentitySettings
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Host { get; set; }
    public string ClientName { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Scope { get; set; }
}
