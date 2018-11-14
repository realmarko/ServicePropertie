using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicePropertie.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }

        public double Price { get; set; }

        public int PropertyTypeId { get; set; }

        public int OperationTypeId { get; set; }

        public int StateId { get; set; }
    }
}