﻿using AutoMapper;
using MagicVilla.Model;
using MagicVilla.Model.Dto;

namespace MagicVilla
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Villa, VillaDto>();
            CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap(); 
            
            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();          
            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();

        }
    }
}
