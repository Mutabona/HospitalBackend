using AutoMapper;
using HospitalBackend.AppServices.Contexts.Analyzes.Repositories;
using HospitalBackend.AppServices.Contexts.Analyzes.Services;
using HospitalBackend.AppServices.Contexts.Appointments.Repositories;
using HospitalBackend.AppServices.Contexts.Appointments.Services;
using HospitalBackend.AppServices.Contexts.Examinations.Repositories;
using HospitalBackend.AppServices.Contexts.Examinations.Services;
using HospitalBackend.AppServices.Contexts.Histories.Repositories;
using HospitalBackend.AppServices.Contexts.Histories.Services;
using HospitalBackend.AppServices.Contexts.Marks.Repositories;
using HospitalBackend.AppServices.Contexts.Marks.Services;
using HospitalBackend.AppServices.Contexts.Patients.Repositories;
using HospitalBackend.AppServices.Contexts.Patients.Services;
using HospitalBackend.AppServices.Contexts.Users.Repositories;
using HospitalBackend.AppServices.Contexts.Users.Services;
using HospitalBackend.AppServices.Services;
using HospitalBackend.DataAccess;
using HospitalBackend.DataAccess.Analyzes;
using HospitalBackend.DataAccess.Appointments;
using HospitalBackend.DataAccess.Examinations;
using HospitalBackend.DataAccess.Histories;
using HospitalBackend.DataAccess.Marks;
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
        services.AddTransient<IAppointmentService, AppointmentService>();
        services.AddTransient<IAnalysisService, AnalysisService>();
        services.AddTransient<IMarkService, MarkService>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<IExaminationRepository, ExaminationRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        services.AddScoped<IMarkRepository, MarkRepository>();
        
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
            cfg.AddProfile<AppointmentProfile>();
            cfg.AddProfile<AnalysisProfile>();
            cfg.AddProfile<MarkProfile>();
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