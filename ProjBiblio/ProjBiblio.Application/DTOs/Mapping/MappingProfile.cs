using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookAuthor, AuthorSelectListDto>()
                .ForMember(dest => dest.AuthorID, 
                            opt => opt.MapFrom(src => src.AuthorID))
                .ReverseMap();

            CreateMap<BookMarketingCampaign, BookSelectListDto>()
                .ForMember(dest => dest.BookID, 
                            opt => opt.MapFrom(src => src.BookID))
                .ReverseMap();
        }
    }
}