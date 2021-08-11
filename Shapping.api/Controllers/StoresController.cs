using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shapping.api.DbContexts;
using Shapping.api.Entities;
using Shapping.api.Models;
using Shapping.api.Services;
using Shapping.api.Services.GetStoreList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreItemRepository _storeItemRepository;
        private readonly IGetStoreListService _getStoreListService;
        private readonly IMapper _mapper;
        private readonly StoreItemContext _context;

        public StoresController(IStoreItemRepository storeItemRepository, IMapper mapper, IGetStoreListService getStoreListService, StoreItemContext context)
        {
            _storeItemRepository = storeItemRepository ?? throw new ArgumentNullException(nameof(storeItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _getStoreListService = getStoreListService ?? throw new ArgumentNullException(nameof(getStoreListService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet("{storeId}", Name = "GetStore")]
        public IActionResult GetStore(Guid storeId)
        {
            var storeFromRepo = _storeItemRepository.GetStore(storeId);

            if (storeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StoreDto>(storeFromRepo));
        }
        [HttpDelete("{storeId}")]
        public ActionResult DeleteStore(Guid storeId)
        {
            var storeFromRepo = _storeItemRepository.GetStore(storeId);

            if (storeFromRepo == null)
            {
                return NotFound();
            }

            _storeItemRepository.DeleteStore(storeFromRepo);

            _storeItemRepository.Save();

            return NoContent();
        }
        [HttpPost]
        public ActionResult<StoreDto> CreateStore(StoreForCreationDto store)
        {
            var storeEntity = _mapper.Map<Entities.Store>(store);
            _storeItemRepository.AddStore(storeEntity);
            _storeItemRepository.Save();

            var storeToReturn = _mapper.Map<StoreDto>(storeEntity);
            return CreatedAtRoute("GetStore",
                new { storeId = storeToReturn.Id },
                storeToReturn);
        }
        [HttpGet("Test")]
        public ActionResult<IEnumerable<Store>> Execute()
        {
            var items = _context.Stores.Where(s => s.Name == "Farhad")
            .Include(s => s.Items)
             .FirstOrDefault();
            return Ok(items);
        }


        [HttpGet("TestId")]
        public ActionResult<List<Store>> ExecuteId()
        {
            var items = _context.Stores.Where(s => s.Name.Contains("Farhad"))
                .Select(s => new Store
                {
                    Id = s.Id,
                    Name = s.Name,
                    Items = s.Items
                }).ToList();
            return Ok(items);
        }
    }
}
