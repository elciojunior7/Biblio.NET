using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.Services;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;
using ProjBiblio.Infrastructure.Data.Repositories;

namespace ProjBiblio.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services){
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IKartService, KartService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMarketingCampaignService, MarketingCampaignService>();
            //se não tiver o UnitOfWork é necessário adicionar cada Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterContexts(IServiceCollection services, string conn)
        {
            services.AddDbContext<BiblioDbContext>(options=>options.UseNpgsql(conn));
        }
        public static void RegisterMappers(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.DTOs.Mapping.MappingProfile());
                mc.AddProfile(new Application.ViewModels.Mapping.MappingProfile());
                mc.AddProfile(new Application.InputModels.Mapping.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}