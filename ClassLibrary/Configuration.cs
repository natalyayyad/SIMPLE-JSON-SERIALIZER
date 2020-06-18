using System;

public class Configuration
{

    public Configuration(int version, string domainName, string[] ipAddresses)
    {
        Version = version;
        DomainName = domainName;
        IpAddresses = ipAddresses;
    }

    public int Version { get; }
    public string DomainName { get; }
    public string[] IpAddresses { get; }


}
