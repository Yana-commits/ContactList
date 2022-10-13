using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    interface IContact
    {
        string FullName { get; set; }
        string PhoneNumber { get; set; }
    }
}
