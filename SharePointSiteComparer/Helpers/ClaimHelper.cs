//-----------------------------------------------------------------------
// <copyright file="ClaimHelper.cs" company="Subhabrata">
//     Copyright © 2025 [Subhabrata]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer.Helpers
{
    #region Namespace

    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    #endregion Namespace

    /// <summary>
    /// Helper file for crawl
    /// </summary>
    public class ClaimHelper
    {
        /// <summary>
        /// Gets the form digest.
        /// </summary>
        /// <param name="siteUrl">The site URL.</param>
        /// <param name="credentails">The credentails.</param>
        /// <returns>Form Digest</returns>
        public static string GetFormDigest(string siteUrl, ICredentials credentails)
        {
            var endpoint = "/_api/contextinfo";
            var request = (HttpWebRequest)WebRequest.Create(siteUrl + endpoint);
            string formDigest = string.Empty;
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.Accept = "text/xml;charset=utf-8";
            request.ContentLength = 0;
            request.Credentials = credentails;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    var resultXml = System.Xml.Linq.XDocument.Parse(result);

                    // Get the form digest value
                    var ei = from e in resultXml.Descendants()
                             where e.Name == XName.Get("FormDigestValue", "http://schemas.microsoft.com/ado/2007/08/dataservices")
                             select e;
                    formDigest = ei.First().Value;
                }
            }

            return formDigest;
        }
    }
}