using AutoMapper;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.Mapper
{
    /// <summary>
    ///     Configuration of Dtos
    /// </summary>
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyDto, Property>();
        }
    }
}
