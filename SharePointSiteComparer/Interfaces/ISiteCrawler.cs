namespace SharePointSiteComparer
{
    using Models;
    using System.Net;   
    public interface ISiteCrawler
    {
        string SiteUrl { get; set; }
        ICredentials Credentials { get; set; }
        Web Crawl();
    }
}