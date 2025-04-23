//-----------------------------------------------------------------------
// <copyright file=" SiteComparer.cs" company="Subhabrata">
//     Copyright © 2025 [Subhabrata]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer
{
    #region Namespace

    using Helpers;
    using Models;
    using System.Net;

    #endregion Namespace

    /// <summary>
    /// Comapres Source and Destination Sites
    /// </summary>
    /// <seealso cref="SharePointSiteComparer.ICrawlConfiguration" />
    public class SiteComparer : ICrawlConfiguration
    {
        public SiteComparer(string sourceUrl, ICredentials sourceCredentials, string destinationUrl, ICredentials destinationCredentials, bool isRecursiveCrawl)
        {
            this.SourceUrl = sourceUrl;
            this.SourceCredentials = sourceCredentials;
            this.DestinationUrl = destinationUrl;
            this.DestinationCredentials = destinationCredentials;
            this.IsRecursiveCrawl = isRecursiveCrawl;
        }

        public string SourceUrl { get; set; }
        public ICredentials SourceCredentials { get; set; }
        public string DestinationUrl { get; set; }
        public ICredentials DestinationCredentials { get; set; }
        private ISiteCrawler SourceCrawler { get; set; }
        private ISiteCrawler DestinationCrawler { get; set; }
        public bool IsRecursiveCrawl { get; set; }


        /// <summary>
        /// Compares the sites.
        /// </summary>
        /// <returns>status message</returns>
        public string CompareSites()
        {
            string statusMessage = string.Empty;
            try
            {
                this.SourceCrawler = CrawlFactory.GenerateCrawler(this.SourceUrl, this.SourceCredentials, this.IsRecursiveCrawl);
                Web sourceSite = this.SourceCrawler.Crawl();
                string sourceXmlOutputfilePath = SharePointSiteComparer.Helpers.XMLDocumentHelper.GenerateXMLFile(this.SourceUrl, this.SourceCredentials, sourceSite);

                this.DestinationCrawler = CrawlFactory.GenerateCrawler(this.DestinationUrl, this.DestinationCredentials, this.IsRecursiveCrawl);
                Web destinationSite = this.DestinationCrawler.Crawl();
                string destinationXmlOutputfilePath = SharePointSiteComparer.Helpers.XMLDocumentHelper.GenerateXMLFile(this.DestinationUrl, this.DestinationCredentials, destinationSite);
               
                // Compare the xml files
                XMLDocumentHelper xmlHelper = new XMLDocumentHelper();
                bool isMatch = xmlHelper.CompareXMLDocuments(sourceXmlOutputfilePath, destinationXmlOutputfilePath);
                if (isMatch)
                {
                    statusMessage = "Both source and destination sites matched";
                }
                else
                {
                    statusMessage = "Source and destination sites does not match";
                }
            }
            catch (System.Exception ex)
            {
                statusMessage = ex.Message;
            }

            return statusMessage;
        }
    }
}