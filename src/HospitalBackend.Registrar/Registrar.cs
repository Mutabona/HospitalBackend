using AutoMapper;
using HospitalBackend.AppServices.Contexts.Examinations.Repositories;
using HospitalBackend.AppServices.Contexts.Examinations.Services;
using HospitalBackend.AppServices.Contexts.Histories.Repositories;
using HospitalBackend.AppServices.Contexts.Histories.Services;
using HospitalBackend.AppServices.Contexts.Patients.Repositories;
using HospitalBackend.AppServices.Contexts.Patients.Services;
using HospitalBackend.AppServices.Contexts.Users.Repositories;
using HospitalBackend.AppServices.Contexts.Users.Services;
using HospitalBackend.AppServices.Services;
using HospitalBackend.DataAccess;
using HospitalBackend.DataAccess.Examinations;
using HospitalBackend.DataAccess.Histories;
using HospitalBackend.DataAccess.Patients;
using HospitalBackend.DataAccess.Users;
using HospitalBackend.Infrastructure.Repository;
using HospitalBackend.Registrar.MapProfiles;
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
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IJwtService, JwtService> ();
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<IHistoryService, HistoryService>();
        services.AddTransient<IExaminationService, ExaminationService>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<IExaminationRepository, ExaminationRepository>();
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        services.AddScoped<DbContext>(s => s.GetRequiredService<ApplicationDbContext>());

        //services.AddFluentValidation();
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<PatientProfile>();
            cfg.AddProfile<HistoryProfile>();
            cfg.AddProfile<ExaminationProfile>();
        });
        
        configuration.AssertConfigurationIsValid();
        return configuration;
    }

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