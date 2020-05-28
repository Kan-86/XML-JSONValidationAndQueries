using LibraryBooksIndex.Repos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace LibraryBooksIndex.Service
{
    public class LibraryIndexService
    {


        public void AveragePriceOfBooks(string name)
        {

        }

        public void GetTitleWithPrice(double price)
        {

        }

        public void SearchForUserByName(string name)
        {

        }

        public void ValidateJSONSchema()
        {
            JSchema schema = JSchema.Parse(File.ReadAllText(@"W:\Skoli\6onn\DBDFinalExam\XML-JSONValidationAndQueries\BooksAndUsersXMLJSON\LibraryJSONSchema.json"));

            JToken json = JToken.Parse(File.ReadAllText(@"W:\Skoli\6onn\DBDFinalExam\XML-JSONValidationAndQueries\BooksAndUsersXMLJSON\LibraryMockJSON.json"));
            // validate json
            IList<ValidationError> errors;
            bool valid = json.IsValid(schema, out errors);

            Console.WriteLine("Is the schema valid? :  " + valid);
            Console.ReadLine();
        }

        private void OpenXML()
        {

        }
    }
    public class ValidateResponse
    {
        public bool Valid { get; set; }
        public IList<ValidationError> Errors { get; set; }
    }
}
