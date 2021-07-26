using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shapping.api.Models;
using Shapping.api.Services;
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
        private readonly IMapper _mapper;

        public ItemsController(IStoreItemRepository storeItemRepository, IMapper mapper)
        {
            _storeItemRepository = storeItemRepository ?? throw new ArgumentNullException(nameof(storeItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        [HttpGet("{ItemId}", Name = "GetItemForStore")]
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
        [HttpDelete("{courseId}")]
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
    }
}
