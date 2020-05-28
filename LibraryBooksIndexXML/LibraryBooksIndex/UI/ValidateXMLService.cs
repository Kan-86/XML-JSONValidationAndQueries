using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace LibraryBooksIndex.Service
{
    public class ValidateXMLService
    {
        public void ValidateXMLFile(string xsd, string xml)
        {
            try
            {
                // Create a schema validating XmlReader.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", xsd);
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
                settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(xml, settings);

                // The XmlDocument validates the XML document contained
                // in the XmlReader as it is loaded into the DOM.
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                // Make an invalid change to the first and last
                // price elements in the XML document, and write
                // the XmlSchemaInfo values assigned to the price
                // element during load validation to the console.
                XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
                manager.AddNamespace("bk", "http://www.w3.org/2001/XMLSchema");

                XmlNode priceNode = document.SelectSingleNode(@"/bk:Library/bk:User/bk:BooksRented/bk::Price", manager);

                Console.WriteLine("SchemaInfo.IsDefault: {0}", priceNode.SchemaInfo.IsDefault);
                Console.WriteLine("SchemaInfo.IsNil: {0}", priceNode.SchemaInfo.IsNil);
                Console.WriteLine("SchemaInfo.SchemaElement: {0}", priceNode.SchemaInfo.SchemaElement);
                Console.WriteLine("SchemaInfo.SchemaType: {0}", priceNode.SchemaInfo.SchemaType);
                Console.WriteLine("SchemaInfo.Validity: {0}", priceNode.SchemaInfo.Validity);

                priceNode.InnerXml = "A";

                XmlNodeList priceNodes = document.SelectNodes(@"/bk:Library/bk:User/bk:BooksRented/Price", manager);
                XmlNode lastprice = priceNodes[priceNodes.Count - 1];

                lastprice.InnerXml = "B";

                // Validate the XML document with the invalid changes.
                // The invalid changes cause schema validation errors.
                document.Validate(ValidationEventHandler);

                // Correct the invalid change to the first price element.
                priceNode.InnerXml = "8.99";

                // Validate only the first book element. The last book
                // element is invalid, but not included in validation.
                XmlNode bookNode = document.SelectSingleNode(@"/bk:Library/bk:User", manager);
                document.Validate(ValidationEventHandler, bookNode);
            }
            catch (XmlException ex)
            {
                Console.WriteLine("XmlDocumentValidationExample.XmlException: {0}", ex.Message);
                Console.ReadLine();
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine("XmlDocumentValidationExample.XmlSchemaValidationException: {0}", ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("XmlDocumentValidationExample.Exception: {0}", ex.Message);
                Console.ReadLine();
            }
        }

        static void ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("\nWARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("\nERROR: ");

            Console.WriteLine(args.Message);
            Console.ReadLine();
        }
    }
}
