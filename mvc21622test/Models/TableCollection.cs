using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc21622test.Models
{
    public class TableCollection
    {
        public int empid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> gender { get; set; }
        public Nullable<int> country { get; set; }
        public Nullable<int> state { get; set; }
        public List<tblgender> lstgender { get; set; }
        public List<tblcountry> lstcountry { get; set; }
    }
}