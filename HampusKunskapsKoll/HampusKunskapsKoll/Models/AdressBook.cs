using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HampusKunskapsKoll.Models
{
    public class AdressBook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}