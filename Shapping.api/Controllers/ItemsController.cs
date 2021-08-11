using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shapping.api.DbContexts;
using Shapping.api.Entities;
using Shapping.api.Models;
using Shapping.api.Services;
using Shapping.api.Services.GetItemList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Controllers
{
    [Route("api/stores/{storeId}/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IStoreItemRepository _storeItemRepository;
        private readonly IGetItemListService _getItemListService;
        private readonly IMapper _mapper;
        private readonly StoreItemContext _context;

        public ItemsController(IStoreItemRepository storeItemRepository, IMapper mapper, IGetItemListService getItemListService, StoreItemContext context)
        {
            _storeItemRepository = storeItemRepository ?? throw new ArgumentNullException(nameof(storeItemRepository));
            _getItemListService = getItemListService ?? throw new ArgumentNullException(nameof(getItemListService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetItemsForStore(Guid storeId)
        {
            if (!_storeItemRepository.StoreExists(storeId))
            {
                return NotFound();
            }

            var itemsForStoreFromRepo = _storeItemRepository.GetItems(storeId);
            return Ok(_mapper.Map<IEnumerable<ItemDto>>(itemsForStoreFromRepo));
        }

        [HttpGet("{itemId}", Name = "GetItemForStore")]
        public ActionResult<ItemDto> GetItemForStore(Guid storeId, Guid itemId)
        {
            if (!_storeItemRepository.StoreExists(storeId))
            {
                return NotFound();
            }

            var itemForStoreFromRepo = _storeItemRepository.GetItem(storeId, itemId);

            if (itemForStoreFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ItemDto>(itemForStoreFromRepo));
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItemForStore(
            Guid storeId, ItemForCreationDto item)
        {
            if (!_storeItemRepository.StoreExists(storeId))
            {
                return NotFound();
            }

            var itemEntity = _mapper.Map<Entities.Item>(item);
            _storeItemRepository.AddItem(storeId, itemEntity);
            _storeItemRepository.Save();

            var itemToReturn = _mapper.Map<ItemDto>(itemEntity);
            return CreatedAtRoute("GetItemForStore",
                new { storeId = storeId, itemId = itemToReturn.Id },
                itemToReturn);
        }
        [HttpDelete("{itemId}")]
        public ActionResult DeleteItemForStore(Guid storeId, Guid itemId)
        {
            if (!_storeItemRepository.StoreExists(storeId))
            {
                return NotFound();
            }

            var itemForStoreFromRepo = _storeItemRepository.GetItem(storeId, itemId);

            if (itemForStoreFromRepo == null)
            {
                return NotFound();
            }

            _storeItemRepository.DeleteItem(itemForStoreFromRepo);
            _storeItemRepository.Save();

            return NoContent();
        }
        [HttpGet("Test")]
        public ActionResult<IEnumerable<Item>> Execute()
        {
            var items = _context.Items.Where(s => s.Name == "Cake")
            .Include(s => s.Store)
             .FirstOrDefault();
            return Ok(items);
        }


        [HttpGet("TestId")]
        public ActionResult<List<Item>> ExecuteId()
        {
            var items = _context.Items.Where(s => s.Name.Contains("Cake"))
                .Select(s => new Item
                {
                    Store = s.Store,
                    StoreId = s.StoreId,
                    Name = s.Name,
                    DateExpiration = s.DateExpiration,
                    DateManufacture = s.DateManufacture
                }).ToList();
            return Ok(items);
        }
    }
}


