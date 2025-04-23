//-----------------------------------------------------------------------
// <copyright file="CrawlFactory.cs" company="Subhabrata">
//     Copyright © 2025 [Subhabrata]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer.Helpers
{
    #region Namespace

    using SharePointSiteComparer.Site_Crawlers;
    using System.Net;

    #endregion Namespace

    /// <summary>
    /// This class create a interface for Crawlers
    /// </summary>
    public class CrawlFactory
    {
        /// <summary>
        /// Generates the crawler.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="isRecursiveCrawl">if set to <c>true</c> [is recursive crawl].</param>
        /// <returns>Interface of Crawler</returns>
        public static ISiteCrawler GenerateCrawler(string url, ICredentials credentials, bool isRecursiveCrawl)
        {
            string version = SharePointHelper.GetSharePointVersion(url, credentials);
            ISiteCrawler crawler;
            switch (version)
            {
                case Constants.SP2007_VERSION_NUMBER:
                    crawler = new SP2007SiteCrawler(url, credentials, isRecursiveCrawl);
                    break;

                case Constants.SP2010_VERSION_NUMBER:
                    crawler = new SP2010OnwardsSiteCrawler(url, credentials, isRecursiveCrawl);
                    break;

                case Constants.SP2013_VERSION_NUMBER:
                    crawler = new SP2010OnwardsSiteCrawler(url, credentials, isRecursiveCrawl);
                    break;

                default:
                    crawler = new SP2010OnwardsSiteCrawler(url, credentials, isRecursiveCrawl);
                    break;
            }

            return crawler;
        }
    }
}