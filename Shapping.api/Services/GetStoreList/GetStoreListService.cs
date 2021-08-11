using Shapping.api.DbContexts;
using Shapping.api.Entities;
using Shapping.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Services.GetStoreList
{
    public class GetStoreListService : IGetStoreListService
    {
        private readonly StoreItemContext _context;
        public GetStoreListService(StoreItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Store> Execute()
        {
            throw new NotImplementedException();
        }

        public List<Store> ExecuteId()
        {
            throw new NotImplementedException();
        }
    }
}
