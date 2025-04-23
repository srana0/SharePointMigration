//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Subhabrata">
//     Copyright © 2025 [Subhabrata]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer.Helpers
{
    /// <summary>
    /// Contains all the constants variables
    /// </summary>
    public class Constants
    {
        
        public const string SP2007_VERSION_NUMBER = "12";
        public const string SP2010_VERSION_NUMBER = "14";
        public const string SP2013_VERSION_NUMBER = "15";
        public const char STRING_SPLIT_OPTION = '^';

        // xml node variables
        public const string XML_NODE_WEBS = "Webs";

        public const string XML_NODE_WEB = "Web";
        public const string XML_NODE_WEB_TITLE = "WebTitle";
        public const string XML_NODE_WEB_URL = "WebUrl";
        public const string XML_NODE_LIBRARIES = "Libraries";
        public const string XML_NODE_LIBRARY_NAME = "LibraryName";
        public const string XML_NODE_DOCUMENTS = "Documents";
        public const string XML_NODE_DOCUMENT = "Document";
        public const string XML_NODE_DOCUMENT_NAME = "DocumentName";
        public const string XML_NODE_DOCUMENT_VERSION = "DocumentVersion";

        //XML File Names
        public const string SP2007_CRAWLED_FILE = "SP2007_CrawledSite_Info.xml";

        public const string SP2010_ONWARDS_CRAWLED_FILE = "SP2010Onwards_CrawledSite_Info.xml";

        public const string SP2007_LIST_SERVICE_ENDPOINT = "/_vti_bin/Lists.asmx";
        public const string SP2007_WEB_SERVICE_ENDPOINT = "/_vti_bin/Webs.asmx";
        public const string SP2010_ONWARDS_ROOT_WEB_REST_ENDPOINT = "/_api/web?$select=Title,Url";
        public const string SP2010_ONWARDS_WEB_REST_ENDPOINT = "/_api/web/webs?$select=Title,Url";
        public const string SP2010_ONWARDS_LIST_REST_ENDPOINT = "/_api/web/lists?$filter=BaseTemplate eq 101&$select=Title,BaseTemplate,BaseType";

        public const string DOCUMENT_LIBRARY_TEMPLATE_ID = "101";
    }
}