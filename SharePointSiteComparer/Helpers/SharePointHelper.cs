//--------------------------------------------------------------------
// <copyright file=" SharePointHelper.cs" company="Fidelity Investments">
//     Copyright © 2016 [Fidelity]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer.Helpers
{
    #region Namespace

    using Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;

    #endregion Namespace

    /// <summary>
    /// The class contains all the helper methods for SharePoint
    /// </summary>
    public class SharePointHelper
    {
        /// <summary>
        /// Gets the share point version.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="credentials">The credentials.</param>
        /// <returns> SharePoint Version</returns>
        public static string GetSharePointVersion(string url, ICredentials credentials)
        {
            string version = string.Empty;
            try
            {
                Uri uri = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AllowAutoRedirect = false;
                request.Credentials = credentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                version = response.Headers["MicrosoftSharePointTeamServices"].Split('.')[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return version;
        }

        public static string GetWebTitleSP2007Web(string webUrl, ICredentials credentials)
        {
            string webTitle = string.Empty;
            try
            {
                SPMigrationCorpWebService.Webs objWebService = new SPMigrationCorpWebService.Webs();
                objWebService.Url = webUrl + Constants.SP2007_WEB_SERVICE_ENDPOINT;
                objWebService.Credentials = credentials;
                XmlNode ndWeb = objWebService.GetWeb(webUrl);
                webTitle = ndWeb.Attributes["Title"].Value;
            }
            catch (Exception)
            {
                throw;
            }
            return webTitle;
        }

        internal static List<Web> GetSubWebsSP2007(string webUrl, ICredentials credentials, bool isRecursiveCrawl, ISiteCrawler SiteCrawler)
        {
            List<Web> subWebs = new List<Web>();
            List<string> subWebUrls = new List<string>();
            string subWebUrl = string.Empty;
            try
            {
                /// Get all sub sites
                SPMigrationCorpWebService.Webs objWebService = new SPMigrationCorpWebService.Webs();
                objWebService.Url = webUrl + Constants.SP2007_WEB_SERVICE_ENDPOINT;
                objWebService.Credentials = credentials;
                System.Xml.XmlNode ndWeb = objWebService.GetWebCollection();

                foreach (XmlNode result in ndWeb.ChildNodes)
                {
                    subWebUrl = result.Attributes["Url"].Value;
                    SiteCrawler = CrawlFactory.GenerateCrawler(subWebUrl, credentials, isRecursiveCrawl);
                    Web subWeb = SiteCrawler.Crawl();
                    subWebs.Add(subWeb);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return subWebs;
        }

        internal static List<Web> GetSubWebsSP2010Onwards(string webUrl, ICredentials credentials, bool isRecursiveCrawl, ISiteCrawler SiteCrawler)
        {
            List<Web> subWebs = new List<Web>();
            List<string> subWebUrls = new List<string>();
            string subWebUrl = string.Empty;

            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + Constants.SP2010_ONWARDS_WEB_REST_ENDPOINT);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata =verbose";
                endpointRequest.Credentials = credentials;

                using (HttpWebResponse webResponse = endpointRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"))
                                                .Children<JObject>();

                        foreach (JObject result in resultObjects)
                        {
                            subWebUrl = Convert.ToString(result["Url"]);
                            SiteCrawler = CrawlFactory.GenerateCrawler(subWebUrl, credentials, isRecursiveCrawl);
                            Web subWeb = SiteCrawler.Crawl();
                            subWebs.Add(subWeb);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return subWebs;
        }

        internal static string GetWebTitleSP2010OnwardsWeb(string webUrl, ICredentials credentials)
        {
            string webTitle = string.Empty;

            try
            {
                HttpWebRequest rootendpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + Constants.SP2010_ONWARDS_ROOT_WEB_REST_ENDPOINT);
                rootendpointRequest.Method = "GET";
                rootendpointRequest.Accept = "application/json;odata=verbose";
                rootendpointRequest.ContentType = "application/json;odata =verbose";
                rootendpointRequest.Credentials = credentials;

                using (HttpWebResponse webResponse = rootendpointRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();

                        var resultObjects = AllChildren(JObject.Parse(json))
                                                .First(c => c.Type == JTokenType.Property)
                                                .Children<JObject>();
                        Dictionary<WebInfo, string> rootWebDictionary = new Dictionary<WebInfo, string>();
                        foreach (JObject result in resultObjects)
                        {
                            webTitle = result["Title"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return webTitle;
        }

        public static List<string> GetLibrariesSP2007Web(string webUrl, ICredentials credentials)
        {
            List<string> libraryInfoList = new List<string>();
            try
            {
                SPMigrationCorpListWebvice.Lists listService = new SPMigrationCorpListWebvice.Lists();
                listService.Url = webUrl + Constants.SP2007_LIST_SERVICE_ENDPOINT;
                listService.Credentials = credentials;
                System.Xml.XmlNode ndList = listService.GetListCollection();

                foreach (XmlNode library in ndList.ChildNodes)
                {
                    if ((library.Attributes["ServerTemplate"].Value).Equals(Constants.DOCUMENT_LIBRARY_TEMPLATE_ID))
                    {
                        libraryInfoList.Add(library.Attributes["Title"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return libraryInfoList;
        }

        internal static List<string> GetLibrariesSP2010OnwardsWeb(string webUrl, ICredentials credentials)
        {
            List<string> libraryInfoList = new List<string>();

            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + Constants.SP2010_ONWARDS_LIST_REST_ENDPOINT);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Credentials = credentials;
                using (HttpWebResponse webResponse = endpointRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"))
                                                .Children<JObject>();
                        foreach (JObject result in resultObjects)
                        {
                            libraryInfoList.Add(Convert.ToString(result["Title"]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return libraryInfoList;
        }

        public static List<Document> GetDocumentsSP2007Web(string webUrl, string libraryName, ICredentials credentials)
        {
            List<Document> documentInfoList = new List<Document>();
            try
            {
                SPMigrationCorpListWebvice.Lists listService = new SPMigrationCorpListWebvice.Lists();
                listService.Url = webUrl + Constants.SP2007_LIST_SERVICE_ENDPOINT;
                listService.Credentials = credentials;

                XmlDocument xmlDoc = new System.Xml.XmlDocument();
                XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
                XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
                XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
                //Get only Document recursively
                ndQuery.InnerXml = "<Where><Eq><FieldRef Name = \"FSObjType\"/><Value Type = \"Integer\">0</Value></Eq></Where>";
                ndQueryOptions.InnerXml = "<ViewAttributes Scope=\"RecursiveAll\"/>";
                ndViewFields.InnerXml = "";
                XmlNode ndListItems = listService.GetListItems(libraryName, null, ndQuery, ndViewFields, null, ndQueryOptions, null);
                XmlNodeList oNodes = ndListItems.ChildNodes;

                foreach (XmlNode node in oNodes)
                {
                    XmlNodeReader objReader = new XmlNodeReader(node);
                    while (objReader.Read())
                    {
                        if (objReader["ows_ID"] != null && objReader["ows_LinkFilename"] != null)
                        {
                            string docAbsoluteUrl = Convert.ToString(objReader["ows_EncodedAbsUrl"]);
                            string documentName = Convert.ToString(objReader["ows_LinkFilename"]);
                            string itemID = Convert.ToString(objReader["ows_ID"]);
                            string documentVersions = GetDocumentVersionsOf2007Site(webUrl, libraryName, itemID, credentials);

                            documentInfoList.Add(new Document { DocumentName = documentName, DocumentVersions = documentVersions });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return documentInfoList;
        }

        internal static List<Document> GetDocumentsSP2010OnwardsWeb(string webUrl, string libraryName, ICredentials credentials)
        {
            List<Document> documentInfoList = new List<Document>();
            try
            {
                List<string> idOfFiles = new List<string>();
                string restRequest = "/_api/web/Lists/GetByTitle('" + libraryName + "')/Items";
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + restRequest);
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Method = "GET";
                endpointRequest.Credentials = credentials;
                using (HttpWebResponse webResponse = (HttpWebResponse)endpointRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"))
                                                .Children<JObject>();

                        foreach (JObject result in resultObjects)
                        {
                            if (result["FileSystemObjectType"].ToString().Equals("0"))
                            {
                                string itemId = result["ID"].ToString();
                                string documentName = GetFileNameByIDSP2010OnwardsSite(webUrl, libraryName, credentials, itemId);
                                string documentVersions = Convert.ToString(GetDocumentVersionsOf2010OnwardsSite(webUrl, libraryName, itemId, credentials));

                                documentInfoList.Add(new Document { DocumentName = documentName, DocumentVersions = documentVersions });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return documentInfoList;
        }

        public static List<string> GetSubWebUrlsSP2007Web(string webUrl, ICredentials credentials)
        {
            List<string> subWebUrls = new List<string>();
            string subWebUrl = string.Empty;
            try
            {
                /// Get all sub sites
                SPMigrationCorpWebService.Webs objWebService = new SPMigrationCorpWebService.Webs();
                objWebService.Url = webUrl + Constants.SP2007_WEB_SERVICE_ENDPOINT;
                objWebService.Credentials = credentials;
                System.Xml.XmlNode ndWeb = objWebService.GetWebCollection();

                foreach (XmlNode result in ndWeb.ChildNodes)
                {
                    subWebUrl = result.Attributes["Url"].Value;
                    subWebUrls.Add(subWebUrl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return subWebUrls;
        }

        public static List<string> GetSubWebUrlsSP2010OnwardsWeb(string webUrl, ICredentials credentials)
        {
            List<string> webInfoList = new List<string>();

            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + Constants.SP2010_ONWARDS_WEB_REST_ENDPOINT);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata =verbose";
                endpointRequest.Credentials = credentials;

                using (HttpWebResponse webResponse = endpointRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"))
                                                .Children<JObject>();

                        foreach (JObject result in resultObjects)
                        {
                            webInfoList.Add(Convert.ToString(result["Url"]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return webInfoList;
        }

        public static string GetDocumentVersionsOf2007Site(string webUrl, string libraryName, string itemId, ICredentials credentials)
        {
            string fileVersion = string.Empty;

            try
            {
                SPMigrationCorpListWebvice.Lists listService = new SPMigrationCorpListWebvice.Lists();
                listService.Url = webUrl + Constants.SP2007_LIST_SERVICE_ENDPOINT;
                listService.Credentials = credentials;
                var versionsResult = listService.GetVersionCollection(libraryName, itemId, "Version");
                var versionsXml = System.Xml.Linq.XElement.Parse(versionsResult.OuterXml);
                System.Xml.Linq.XNamespace xmlns = "http://schemas.microsoft.com/sharepoint/soap/";

                var versionLabels = from verion in versionsXml.Descendants(xmlns + "Version")
                                    select verion;

                foreach (var item in versionLabels)
                {
                    fileVersion = item.Attribute("Version").Value;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }//catch

            return fileVersion;
        }

        public static string GetDocumentVersionsOf2010OnwardsSite(string webUrl, string libraryName, string itemId, ICredentials credentials)
        {
            string versions = string.Empty;
            try
            {
                /// <example>
                /// http://MY_WEB_SITE/_api/web/lists/getByTitle('Documents')/items(1)?$select=FileLeafRef,OData__UIVersionString
                /// </example>

                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + "/_api/web/lists/getByTitle('" + libraryName + "')/items('" + itemId + "')?$select=FileLeafRef,OData__UIVersionString");
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Credentials = credentials;

                using (HttpWebResponse webResponse = endpointRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                               .First(c => c.Type == JTokenType.Property)
                                               .Children<JObject>();
                        foreach (JObject result in resultObjects)
                        {
                            versions = result["OData__UIVersionString"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return versions;
        }

        private static string GetFileNameByIDSP2010OnwardsSite(string webUrl, string libraryName, ICredentials credentials, string id)
        {
            string fileName = string.Empty;

            try
            {
                string restRequest = "/_api/web/Lists/GetByTitle('" + libraryName + "')/Items/GetByID('" + id + "')?$select=FileLeafRef";
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(webUrl + restRequest);
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Method = "GET";
                endpointRequest.Credentials = credentials;
                using (HttpWebResponse webResponse = (HttpWebResponse)endpointRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var json = reader.ReadToEnd();
                        var resultObjects = AllChildren(JObject.Parse(json))
                                            .First(c => c.Type == JTokenType.Property)
                                            .Children<JObject>();
                        foreach (JObject result in resultObjects)
                        {
                            fileName = result["FileLeafRef"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return fileName;
        }

        /// <summary>
        /// Alls the children.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}