using Shapping.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Services
{
    public interface IStoreItemRepository
    {
        IEnumerable<Item> GetItems(Guid storeId);
        Item GetItem(Guid storeId, Guid itemId);
        void AddItem(Guid storeId, Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        IEnumerable<Store> GetStores();
        Store GetStore(Guid storeId);
        void AddStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
        bool StoreExists(Guid storeId);
        bool Save();
    }
}
