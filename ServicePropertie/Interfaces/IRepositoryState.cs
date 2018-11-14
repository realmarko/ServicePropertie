using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicePropertie.Interfaces
{
    public interface IRepositoryState
    {
        List<State> GetAllState();
    }
}