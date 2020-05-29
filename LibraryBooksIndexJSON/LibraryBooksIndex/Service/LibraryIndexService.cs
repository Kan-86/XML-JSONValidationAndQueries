using LibraryBooksIndex.Models;
using LibraryBooksIndex.Repos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace LibraryBooksIndex.Service
{
    public class LibraryIndexService
    {

        string jsonSchema = File.ReadAllText(@"W:\Skoli\6onn\DBDFinalExam\XML-JSONValidationAndQueries\BooksAndUsersXMLJSON\LibraryJSONSchema.json");
        string jsonFile = File.ReadAllText(@"W:\Skoli\6onn\DBDFinalExam\XML-JSONValidationAndQueries\BooksAndUsersXMLJSON\LibraryMockJSON.json");
        public void AveragePriceOfBooks(string name)
        {
            var userName = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Users>>(jsonFile);

            var peopleOverForty = from p in userName
                                  where p.Name == name 
                                  select p;

            int amount = 0;
            int total = 0;

            foreach (var item in peopleOverForty)
            {
                foreach (var s in item.BooksRented)
                {
                    amount += 1;
                    total += s.Price;
                }
            }
            Console.WriteLine($"Average price for this user is: {total / amount}");
            Console.ReadLine();
        }

        public void GetTitleWithPrice(double price)
        {

        }

        public void SearchForUserByName(string name)
        {

        }

        public void ValidateJSONSchema()
        {
            JSchema schema = JSchema.Parse(jsonSchema);

            var model = JArray.Parse(jsonFile);

            IList<string> messages;
            bool valid = model.IsValid(schema, out messages); // properly validates
            Console.WriteLine(valid);

            foreach (var item in messages)
            {
                Console.WriteLine(item);
            }
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
