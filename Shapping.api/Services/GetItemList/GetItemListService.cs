using Microsoft.EntityFrameworkCore;
using Shapping.api.DbContexts;
using Shapping.api.Entities;
using Shapping.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Services.GetItemList
{
    public class GetItemListService : IGetItemListService
    {
        private readonly StoreItemContext _context;
        public GetItemListService(StoreItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Item> Execute()
        {
            throw new NotImplementedException();
        }

        public List<Item> ExecuteId()
        {
            throw new NotImplementedException();
        }
    }
}