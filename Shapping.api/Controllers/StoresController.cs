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
    [Route("api/stores")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreItemRepository _storeItemRepository;
        private readonly IMapper _mapper;

        public StoresController(IStoreItemRepository storeItemRepository,IMapper mapper)
        {
            _storeItemRepository = storeItemRepository ?? throw new ArgumentNullException(nameof(storeItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    }
}
