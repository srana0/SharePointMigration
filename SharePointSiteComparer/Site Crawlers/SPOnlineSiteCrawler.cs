namespace SharePointSiteComparer
{
    #region Namespace

    using Helpers;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Xml.Serialization;

    #endregion Namespace

    public class SPOnlineSiteCrawler : ISiteCrawler, ICrawlConfiguration
    {
        public ICredentials Credentials
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string SiteUrl
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool ICrawlConfiguration.IsRecursiveCrawl
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Web Crawl()
        {
            throw new NotImplementedException();
        }
    }
}