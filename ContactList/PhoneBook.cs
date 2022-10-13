using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ContactList
{
    class PhoneBook<T> where T : IContact
    {
        readonly string cyrillicChars;
        readonly string latinChars;

        private const string defultLangEng = "en-US";
        private const string defultLangRu = "ru-RU";

        public SortedList contactCollection = new SortedList();
        private string currentInfo;
        private string currentAlfabet;

        public PhoneBook(string _cyrillicChars, string _latinChars)
        {
            cyrillicChars = _cyrillicChars;
            latinChars = _latinChars;
        }

        public void CheckCulture()
        {
            var cultureInfo = CultureInfo.CurrentCulture.Name;

            if (cultureInfo == defultLangEng || cultureInfo == defultLangRu)
            {
                currentInfo = cultureInfo;
                currentAlfabet = cultureInfo == defultLangEng ? latinChars : cyrillicChars;
            }
            else
            {
                currentInfo = defultLangEng;
                currentAlfabet = latinChars;
            }

        }
        public void AddToCollection(T contact)
        {
            CheckCulture();

            if (String.IsNullOrEmpty(contact.FullName))
            {
                AddToMainList(contact.PhoneNumber, contact);
            }
            else
            {
                if (currentAlfabet.Contains(contact.FullName[0]))
                {
                    var charArray = currentAlfabet.ToCharArray();

                    foreach (var item in charArray)
                    {
                        if (contact.FullName[0] == item)
                        {
                            AddToMainList(contact.FullName, contact);
                        }
                    }
                }
                else if (Regex.IsMatch(contact.FullName, "^[0-9]{1}"))
                {
                    AddToMainList("0-9", contact);
                }
                else
                {
                    AddToMainList(" # ", contact);
                }

            }


        }
        public void AddToMainList(string letter, T contact)
        {
            Comparer myComp = new Comparer(new CultureInfo(currentInfo, false));

            if (contactCollection.ContainsKey(letter[0]))
            {
                SortedList thisLetterList = contactCollection[letter[0]] as SortedList;
                thisLetterList.Add(contact.FullName, contact);
            }
            else
            {
                SortedList mySL = new SortedList(myComp);
                mySL.Add(contact.FullName, contact);
                contactCollection.Add(letter[0], mySL);
            }
        }

    }
}
