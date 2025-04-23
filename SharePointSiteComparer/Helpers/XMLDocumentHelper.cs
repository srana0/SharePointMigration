namespace SharePointSiteComparer.Helpers
{
    #region Namespace

    using Microsoft.XmlDiffPatch;
    using Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    #endregion Namespace

    public class XMLDocumentHelper
    {
        private string diffFile = null;
        private XmlDiff diff = new XmlDiff();
        private XmlDiffOptions diffOptions = new XmlDiffOptions();
        private bool compareFragments = false;

        public bool CompareXMLDocuments(string sourceXmlPath, string destinationXmlPath)
        {
            bool isMatch = false;
            try
            {
                if (!File.Exists(sourceXmlPath))
                {
                    return false;
                }
                if (!File.Exists(destinationXmlPath))
                {
                    return false;
                }
                Random r = new Random();
                // to randomize the output files and hence allow
                // us to generate multiple files for the same pair
                // of comparisons.

                string startupPath = Directory.GetCurrentDirectory();
                //output diff file.
                diffFile = startupPath + Path.DirectorySeparatorChar + "vxd.out";
                XmlTextWriter tw = new XmlTextWriter(new StreamWriter(diffFile));
                tw.Formatting = Formatting.Indented;

                // This method sets the diff.Options property.
                SetDiffOptions();

                bool isEqual = false;

                // Now compare the two files.
                try
                {
                    isEqual = this.diff.Compare(sourceXmlPath, destinationXmlPath, compareFragments, tw);
                }
                catch (XmlException xe)
                {
                    throw xe;
                }
                finally
                {
                    tw.Close();
                }

                if (isEqual)
                {
                    // This means the files were identical for given options.

                    isMatch = true; //dont need to show the differences.
                }
                else
                {
                    isMatch = false;

                    // Files were not equal, so construct XmlDiffView.
                    XmlDiffView dv = new XmlDiffView();

                    // Load the original file again and the diff file.
                    XmlTextReader orig = new XmlTextReader(sourceXmlPath);
                    XmlTextReader diffGram = new XmlTextReader(diffFile);
                    dv.Load(orig, diffGram);

                    // Wrap the HTML file with necessary html and
                    // body tags and prepare it before passing it to the GetHtml method.

                    string tempFile = startupPath + Path.DirectorySeparatorChar + "diff" + r.Next() + ".htm";
                    StreamWriter sw1 = new StreamWriter(tempFile);

                    sw1.Write("<html><body><table width='100%'>");
                    // Write Legend.
                    sw1.Write("<tr><td colspan='2' align='center'><b>Legend:</b> <font style='background-color: yellow'" +
                        " color='black'>added</font>&nbsp;&nbsp;<font style='background-color: red'" +
                        " color='black'>removed</font>&nbsp;&nbsp;<font style='background-color: " +
                        "lightgreen' color='black'>changed</font>&nbsp;&nbsp;" +
                        "<font style='background-color: red' color='blue'>moved from</font>" +
                        "&nbsp;&nbsp;<font style='background-color: yellow' color='blue'>moved to" +
                        "</font>&nbsp;&nbsp;<font style='background-color: white' color='#AAAAAA'>" +
                        "ignored</font></td></tr>");

                    sw1.Write("<tr><td><b> File Name : ");
                    sw1.Write(sourceXmlPath);
                    sw1.Write("</b></td><td><b> File Name : ");
                    sw1.Write(destinationXmlPath);
                    sw1.Write("</b></td></tr>");

                    // This gets the differences but just has the
                    // rows and columns of an HTML table
                    dv.GetHtml(sw1);

                    // Finish wrapping up the generated HTML and complete the file.
                    sw1.Write("</table></body></html>");

                    // HouseKeeping...close everything we dont want to lock.
                    sw1.Close();
                    dv = null;
                    orig.Close();
                    diffGram.Close();
                    File.Delete(diffFile);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isMatch;
        }

        internal static string GenerateXMLFile(string siteUrl, ICredentials credentials, Web web)
        {
            string xmlFilePath = string.Empty;
            try
            {
                xmlFilePath = SharePointSiteComparer.Helpers.XMLDocumentHelper.GetXMLFilePath(siteUrl, credentials, Directory.GetCurrentDirectory());

                using (FileStream stream = new FileStream(xmlFilePath, FileMode.OpenOrCreate))
                {
                    Serialize(stream, web);
                    stream.Close();
                }
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Site));
                //TextWriter writer = new StreamWriter(xmlFilePath);
                //xmlSerializer.Serialize(writer, site);
                //writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return xmlFilePath;
        }

        /// <summary>
        /// This method reads the diff options set on the
        /// menu and configures the XmlDiffOptions object.
        /// </summary>
        private void SetDiffOptions()
        {
            //Reset to None and refresh the options from the menuoptions
            //else eventually all options may get set and the menu changes will
            // not be reflected.
            diffOptions = XmlDiffOptions.None;

            //Read the options settings and OR the XmlDiffOptions enumeration.

            diffOptions = diffOptions | XmlDiffOptions.IgnorePI;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreChildOrder;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreComments;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreDtd;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreNamespaces;
            diffOptions = diffOptions | XmlDiffOptions.IgnorePrefixes;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreWhitespace;
            diffOptions = diffOptions | XmlDiffOptions.IgnoreXmlDecl;

            compareFragments = true;

            //Default algorithm is Auto.
            diff.Algorithm = XmlDiffAlgorithm.Auto;
            diff.Options = diffOptions;
        }

        public static string GetXMLFilePath(string webUrl, ICredentials credentails, string currentDirectoryPath)
        {
            string filename = string.Empty;
            try
            {
                string version = SharePointHelper.GetSharePointVersion(webUrl, credentails);

                switch (version)
                {
                    case Constants.SP2007_VERSION_NUMBER:
                        filename = GetSP2007XmlFileName(currentDirectoryPath);
                        break;

                    case Constants.SP2010_VERSION_NUMBER:
                        filename = GetSP2010OnwardsXmlFileName(currentDirectoryPath);
                        break;

                    default:
                        filename = GetSP2010OnwardsXmlFileName(currentDirectoryPath);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return filename;
        }

        private static string GetSP2010OnwardsXmlFileName(string currentDirectoryPath)
        {
            string filePath = string.Empty;
            string newRandomString = RandomString(8);
            try
            {
                filePath = Directory.GetCurrentDirectory() + "\\" + "SP2010Onwards_CrawledSite_Info.xml";
                if (File.Exists(filePath))
                {
                    Random random = new Random();
                    filePath = Directory.GetCurrentDirectory() + "\\" + "SP2010Onwards_CrawledSite_Info_" + newRandomString + ".xml";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filePath;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GetSP2007XmlFileName(string currentDirectoryPath)
        {
            string filePath = string.Empty;
            string newRandomString = RandomString(8);
            try
            {
                filePath = Directory.GetCurrentDirectory() + "\\" + "SP2007_CrawledSite_Info.xml";
                if (File.Exists(filePath))
                {
                    Random random = new Random();
                    filePath = Directory.GetCurrentDirectory() + "\\" + "SP2007_CrawledSite_Info_" + newRandomString + ".xml";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filePath;
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex; //Log exception here
            }
        }

        /// <summary>
        /// Deserializes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public static object Deserialize(string text, Type objectType)
        {
            ValidationHelper.EnsureArgumentNotNull("text", text);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetByteCount(text)))
            {
                return Deserialize(stream, objectType);
            }
        }

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public static object Deserialize(Stream stream, Type objectType)
        {
            ValidationHelper.EnsureArgumentNotNull("stream", stream);
            ValidationHelper.EnsureArgumentNotNull("objectType", objectType);

            var serializer = GetSerializer(objectType);
            return serializer.Deserialize(stream);
        }

        /// <summary>
        /// Deserializes the specified text.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static TObject Deserialize<TObject>(string text)
        {
            ValidationHelper.EnsureArgumentNotNull("text", text);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetByteCount(text)))
            {
                return Deserialize<TObject>(stream);
            }
        }

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static TObject Deserialize<TObject>(Stream stream)
        {
            ValidationHelper.EnsureArgumentNotNull("stream", stream);
            XmlSerializer serializer = GetSerializer<TObject>();

            return (TObject)serializer.Deserialize(stream);
        }

        /// <summary>
        /// Serializes the specified stream.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="stream">The stream.</param>
        /// <param name="obj">The object.</param>
        public static void Serialize<TObject>(Stream stream, TObject obj)
        {
            ValidationHelper.EnsureArgumentNotNull("stream", stream);
            ValidationHelper.EnsureArgumentNotNull("obj", obj as object);

            XmlSerializer serializer = GetSerializer<TObject>();
            serializer.Serialize(stream, obj);
        }

        /// <summary>
        /// Serializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="obj">The object.</param>
        /// <param name="objectType">Type of the object.</param>
        public static void Serialize(Stream stream, object obj, Type objectType)
        {
            ValidationHelper.EnsureArgumentNotNull("stream", stream);
            ValidationHelper.EnsureArgumentNotNull("obj", obj as object);
            ValidationHelper.EnsureArgumentNotNull("objectType", objectType);

            XmlSerializer serializer = GetSerializer(objectType);
            serializer.Serialize(stream, obj);
        }

        /// <summary>
        /// Serializes to text.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string SerializeToText<TObject>(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, obj);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        /// <summary>
        /// Serializes to text.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public static string SerializeToText(object obj, Type objectType)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, obj, objectType);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <returns></returns>
        private static XmlSerializer GetSerializer<TObject>()
        {
            return GetSerializer(typeof(TObject));
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        private static XmlSerializer GetSerializer(Type objectType)
        {
            return new XmlSerializer(objectType);
        }
    }
}