using Shapping.api.Entities;
using Shapping.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Services.GetItemList
{
    public interface IGetItemListService
    {
        IEnumerable<Item> Execute();
        List<Item> ExecuteId();
    }
}