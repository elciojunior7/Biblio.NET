using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ReverseMap();

            CreateMap<Book, BookViewModel>()
                .ForMember(b => b.Id, opt => opt.MapFrom(src => src.BookId))
                .ReverseMap();

            CreateMap<Kart, KartViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.KartID))
                .ForMember(dest => dest.BookName,
                           opt => 
                            {
                                opt.PreCondition(src => src.Books != null);
                                opt.MapFrom(src => src.Books.Title);
                            })
                .ReverseMap();

            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();

            CreateMap<Loan, LoanViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LoanID))
                //  .ForMember(dest => dest.Books,
                //              opt => opt.MapFrom(src => src.BoLoan))   
                .ReverseMap();

            CreateMap<Genre, GenreViewModel>()
                .ForMember(g => g.Id, opt => opt.MapFrom(src => src.GenreID))
                .ReverseMap();

            CreateMap<MarketingCampaign, MarketingCampaignViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.MarketingCampaignID))
                .ReverseMap();
        }

    }
}