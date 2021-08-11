using Shapping.api.Entities;
using Shapping.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Services.GetStoreList
{
    public interface IGetStoreListService
    {
        IEnumerable<Store> Execute();
        List<Store> ExecuteId();
    }
}
