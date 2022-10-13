using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    class Contact : IContact
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
