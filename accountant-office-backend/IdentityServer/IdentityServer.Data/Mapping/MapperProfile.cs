using AutoMapper;
using IdentityServer.Data.Models;
using PersistedGrant = IdentityServer.Data.Models.PersistedGrant;

namespace IdentityServer.Data.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<DuendePersistedGrant, PersistedGrant>()
            .ForMember(d => d.CreateDate, m => m.MapFrom(s => s.CreationTime))
            .ReverseMap();
        
        CreateMap<DuendeKey, Key>()
            .ForMember(d => d.CreateDate, m => m.MapFrom(s => s.Created))
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.Parse(s.Id)))
            .ReverseMap()
            .ForMember(d => d.Id, m => m.MapFrom(s => s.Id.ToString()));
    }
}