using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePropertie.Interfaces
{
    public interface IRepositoryOperationType
    {
        int Save(OperationType item);

        List<OperationType> GetAllOperationType();

        OperationType GetById(int id);

        OperationType Update(int id, OperationType item);

        int Delete(int id);
    }
}
