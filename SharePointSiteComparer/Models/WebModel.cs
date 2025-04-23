//-----------------------------------------------------------------------
// <copyright file="SiteModel.cs" company="Fidelity">
//     Copyright © 2025 [Subhabrata]. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SharePointSiteComparer.Models
{
      
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

   
   [Serializable]
    public class Web
    {
       // [XmlAttribute]
        public string WebTitle { get; set; }

       // [XmlAttribute]
        public string WebUrl { get; set; }

       // [XmlAttribute]
        public List<Library> Libraries { get; set; }
        public List<Web> SubWebs { get; set; }
    }
    [Serializable]
    public class Library
    {
       // [XmlAttribute]
        public string LibraryName { get; set; }

      //  [XmlAttribute]
        public List<Document> Documents { get; set; }
    }
    [Serializable]
    public class Document
    {
       // [XmlAttribute]
        public string DocumentName { get; set; }

      //  [XmlAttribute]
        public string DocumentVersions { get; set; }
    }
}