using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ConsoleApplication1
{
    //wrapper class for xml. Directly from source class 'a'
    class signaturexmlwrapper
    {
        public static string wrapsignature(byte[] A_0)
        {
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream)memoryStream, (Encoding)utF8Encoding);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 3;
                xmlTextWriter.WriteStartDocument();
                string localName = "Base64";
                xmlTextWriter.WriteStartElement(localName);
                byte[] buffer = A_0;
                int index = 0;
                int length = A_0.Length;
                xmlTextWriter.WriteBase64(buffer, index, length);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
                byte[] array = memoryStream.ToArray();
                return utF8Encoding.GetString(array);
            }
        }

        public static byte[] wrapSig(string A_0)
        {
            byte[] numArray = (byte[])null;
            using (XmlTextReader xmlTextReader = new XmlTextReader((TextReader)new StringReader(A_0)))
            {
                xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
                if (xmlTextReader.ReadToFollowing("Base64"))
                    numArray = Convert.FromBase64String(xmlTextReader.ReadElementContentAsString());
            }
            return numArray;
        }
    }
}