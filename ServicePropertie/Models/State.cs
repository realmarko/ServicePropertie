using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicePropertie.Models
{
    public class State
    {
        public int id { get; set; }
        public string text { get; set; }

        public int CountryId { get; set; }
    }
}