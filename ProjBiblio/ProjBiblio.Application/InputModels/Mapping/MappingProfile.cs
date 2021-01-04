using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.InputModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorInputModel>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ReverseMap();

            CreateMap<Book, BookInputModel>()
                .ForMember(b => b.Id, opt => opt.MapFrom(src => src.BookId))
                .ForMember(b => b.Authors, opt => opt.MapFrom(src => src.BoAuthors))  
                .ReverseMap();

            CreateMap<Kart, KartInputModel>()
                .ForMember(k => k.Id, opt => opt.MapFrom(src => src.KartID))
                .ReverseMap();

            CreateMap<User, UserInputModel>()
                .ForMember(u => u.Id, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();

            CreateMap<Genre, GenreInputModel>()
                .ForMember(g => g.Id, opt => opt.MapFrom(src => src.GenreID))
                .ReverseMap();

            CreateMap<MarketingCampaign, MarketingCampaignInputModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.MarketingCampaignID))
                .ForMember(m => m.Books, opt => opt.MapFrom(src => src.BoMarketing))  
                .ReverseMap();
        }
    }
}