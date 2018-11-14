using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePropertie.Interfaces
{
    public interface IRepositoryPropertyType
    {
        List<PropertyType> GetAllPropertyType();
    }
}
