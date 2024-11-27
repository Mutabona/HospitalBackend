using HospitalBackend.DataAccess;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalBackend.Registrar;

/// <summary>
/// Класс для регистрации компонентов в IoC-контейнере.
/// </summary>
public static class Registrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        //services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        services.AddScoped<DbContext>(s => s.GetRequiredService<ApplicationDbContext>());

        //services.AddFluentValidation();
        
        return services;
    }

    // private static MapperConfiguration GetMapperConfiguration()
    // {
    //     var configuration = new MapperConfiguration(cfg =>
    //     {
    //         cfg.AddProfile<UserProfile>();
    //         cfg.AddProfile<BookProfile>();
    //         cfg.AddProfile<ImageProfile>();
    //         cfg.AddProfile<NewsProfile>();
    //     });
    //     
    //     configuration.AssertConfigurationIsValid();
    //     return configuration;
    // }

    // private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    // {
    //     services.AddValidatorsFromAssemblyContaining<LoginUserRequestValidator>();
    //     services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();
    //     services.AddValidatorsFromAssemblyContaining<AddBookRequestValidator>();
    //     services.AddValidatorsFromAssemblyContaining<AddNewsRequestValidator>();
    //     services.AddFluentValidationAutoValidation();
    //
    //     return services;
    // }
}