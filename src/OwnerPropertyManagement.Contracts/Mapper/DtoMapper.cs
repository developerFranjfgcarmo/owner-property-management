using System.Linq;
using AutoMapper;
using OwnerPropertyManagement.Contracts.Dtos;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Contracts.Mapper
{
    /// <summary>
    ///     Configuration of Dtos
    /// </summary>
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Facility, SimpleDto>().ForMember(f => f.Name, map => map.MapFrom(mf => mf.Description));
            CreateMap<Town, SimpleDto>().ForMember(f => f.Name, map => map.MapFrom(mf => mf.Description));
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Property, PropertyDto>()
                .ForMember(f => f.Facilities,
                    map => map.MapFrom(mf => mf.PropertyFacilities.Select(s => s.FacilityId)));
            CreateMap<PropertyDto, Property>()
                .ForMember(f => f.PropertyFacilities,
                    map => map.MapFrom(mf =>
                        mf.Facilities.Select(s => new PropertyFacility {FacilityId = s, PropertyId = mf.Id})));
        }
    }
}