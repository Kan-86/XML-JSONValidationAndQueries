using LibraryBooksIndex.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryBooksIndex.Repos
{
    public class LibraryIndexRepo
    {
        public void WriteXMLDocument(List<object> lisob)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };

            // Start document
            xmltextWriter.WriteStartDocument();
            xmltextWriter.WriteStartElement("ROOT");

            foreach (var page in lisob)
            {
                //Create a page element
                xmltextWriter.WriteStartElement("Page", page.ToString());
                xmltextWriter.WriteAttributeString("Action", "st");
                xmltextWriter.WriteAttributeString("SearchableProperties", "rf");
                xmltextWriter.WriteEndElement();
            }


            // Same for the other lists 
            // End document
            xmltextWriter.WriteEndElement();
            xmltextWriter.Flush();
            xmltextWriter.Close();
            stringWriter.Flush();
        }
    }
}
