namespace SharePointSiteComparer.Site_Crawlers
{
    using Helpers;

    #region Namespace

    using Models;
    using System;
    using System.Collections.Generic;
    using System.Net;

    #endregion Namespace

    public class SP2010OnwardsSiteCrawler : ISiteCrawler, ICrawlConfiguration
    {
        public SP2010OnwardsSiteCrawler(string siteUrl, ICredentials credentials, bool isRecursiveCrawl)
        {
            this.SiteUrl = siteUrl;
            this.Credentials = credentials;
            this.IsRecursiveCrawl = isRecursiveCrawl;
        }

        public string SiteUrl { get; set; }

        public ICredentials Credentials { get; set; }

        public bool IsRecursiveCrawl { get; set; }

        private ISiteCrawler SiteCrawler { get; set; }

        public Web Crawl()
        {
            Web web = new Web();

            try
            {
                string webUrl = this.SiteUrl;
                ICredentials credentials = this.Credentials;
                bool isRecursiveCrawl = this.IsRecursiveCrawl;

                string webTitle = SharePointSiteComparer.Helpers.SharePointHelper.GetWebTitleSP2010OnwardsWeb(webUrl, credentials);
                List<string> libraryNames = SharePointSiteComparer.Helpers.SharePointHelper.GetLibrariesSP2010OnwardsWeb(webUrl, credentials);
                List<Library> libraries = new List<Library>();
                List<Document> documents = new List<Document>();
                foreach (var libraryName in libraryNames)
                {
                    documents = SharePointSiteComparer.Helpers.SharePointHelper.GetDocumentsSP2010OnwardsWeb(this.SiteUrl, libraryName, credentials);
                    libraries.Add(new Library() { LibraryName = libraryName, Documents = documents });
                }
                if (!isRecursiveCrawl)
                {
                    web = new Web() { WebTitle = webTitle, WebUrl = webUrl, Libraries = libraries, SubWebs = null };
                }
                else
                {
                    List<Web> subWebs = SharePointHelper.GetSubWebsSP2010Onwards(webUrl, credentials, IsRecursiveCrawl, SiteCrawler);
                    web = new Web() { WebTitle = webTitle, WebUrl = webUrl, Libraries = libraries, SubWebs = subWebs };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return web;
        }
    }
}