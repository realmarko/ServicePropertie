using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePropertie.Interfaces
{
    public interface IRepositoryProperty
    {
        int SaveProperty(Property pdm);
        List<Property> GetAllProperty();
        int UpdateProperty(Property propertie);

        Property GetPropertyById(int id);

        Property GetPropertyByLatLng(string lat, string lng);
        int DeleteProperty(int id);
    }
}
