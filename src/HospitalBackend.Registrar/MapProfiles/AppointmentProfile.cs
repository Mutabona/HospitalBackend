using AutoMapper;
using HospitalBackend.Contracts.Appointments;
using HospitalBackend.Domain.Appointments;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль назначения.
/// </summary>
public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<AddAppointmentRequest, AppointmentDto>(MemberList.None);
        
        CreateMap<AppointmentDto, Appointment>(MemberList.None);

        CreateMap<Appointment, AppointmentDto>(MemberList.None)
            .ForMember(dest => dest.DoctorFio, map => map.MapFrom(x => x.Examination.User.FIO))
            .ForMember(dest => dest.PatientFio, map => map.MapFrom(x => x.Examination.History.Patient.FIO))
            .ForMember(dest => dest.IsMarked, map => map.MapFrom(x => x.Mark != null))
            .ForMember(dest => dest.MarkDate, map => map.MapFrom(x => x.Mark == null ? (DateOnly?)null : x.Mark.Date));
    }
}