using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = JsonHandler.Serialization();

            var phoneBook = new PhoneBook<Contact>(config.AlfabetInfo.CyrillicChars, config.AlfabetInfo.LatinChars);

            Contact contact = new Contact { FullName = "Alex", PhoneNumber = "0966596442" };
            Contact contact1 = new Contact { FullName = "Kei", PhoneNumber = "0966590442" };
            phoneBook.AddToCollection(contact);
            phoneBook.AddToCollection(contact1);

            Console.WriteLine($"{phoneBook.contactCollection.Count}");
        }
    }
}
