using Shapping.api.DbContexts;
using Shapping.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapping.api.Services
{
    public class StoreItemRepository : IStoreItemRepository
    {
        private readonly StoreItemContext _context;
        public StoreItemRepository(StoreItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddItem(Guid storeId, Item item)
        {
            if (storeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(storeId));
            }
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            item.StoreId = storeId;
            _context.Items.Add(item);
        }

        public void AddStore(Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            store.Id = Guid.NewGuid();
            foreach (var item in store.Items)
            {
                item.Id = Guid.NewGuid();
            }

            _context.Stores.Add(store);
        }

        public void DeleteItem(Item item)
        {
            _context.Items.Remove(item);
        }

        public void DeleteStore(Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }
            _context.Stores.Remove(store);
        }

        public List<Store> Execute()
        {
            var stores = _context.Stores.Where(s => s.Name.Contains("a"))
            .ToList();
            return stores;
        }



        public Item GetItem(Guid storeId, Guid itemId)
        {

            if (storeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(storeId));
            }
            if (itemId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(itemId));
            }
            return _context.Items
                .Where(c => c.StoreId == storeId && c.Id == itemId).FirstOrDefault();
        }
        public IEnumerable<Item> GetItems(Guid storeId)
        {
            if (storeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(storeId));
            }

            return _context.Items
                        .Where(c => c.StoreId == storeId)
                        .OrderBy(c => c.Name).ToList();
        }

        public Store GetStore(Guid storeId)
        {
            if (storeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(storeId));
            }
            return _context.Stores.FirstOrDefault(a => a.Id == storeId);
        }

        public IEnumerable<Store> GetStores()
        {
            return _context.Stores.ToList<Store>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool StoreExists(Guid storeId)
        {
            if (storeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(storeId));
            }

            return _context.Stores.Any(a => a.Id == storeId);
        }


        public void UpdateItem(Item item)
        {
            throw new ArgumentNullException(nameof(item));
        }

        public void UpdateStore(Store store)
        {
            throw new ArgumentNullException(nameof(store));
        }
    }
}
