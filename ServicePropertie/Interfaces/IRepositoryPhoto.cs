using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePropertie.Interfaces
{
    public interface IRepositoryPhoto
    {
        int Save(string photoName,int propertyId);
        List<PhotoRequest> GetAll();

        PhotoRequest GetById(int id);

        PhotoRequest Update(int id, PhotoRequest item);

        int Delete(int id);


    }
}
