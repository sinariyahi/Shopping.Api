using AutoMapper;
using Shapping.api.Entities;
using Shapping.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Profiles
{
    public class StoreItemProfile:Profile
    {
        public StoreItemProfile()
        {
            CreateMap<Entities.Store, Models.StoreDto>();
            CreateMap<Entities.Item, Models.ItemDto>();
            CreateMap<Models.ItemForCreationDto, Entities.Item>();
            CreateMap<Models.ItemForUpdateDto, Entities.Item>();
            CreateMap<Models.StoreForCreationDto, Entities.Store>();
            CreateMap<Models.StoreForUpdateDto, Entities.Store>();
            CreateMap<Models.UserDto, User>();
        }
    }
}
