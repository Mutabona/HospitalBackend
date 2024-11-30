using AutoMapper;
using HospitalBackend.Contracts.Examinations;
using HospitalBackend.Domain.Examinations;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль осмотра.
/// </summary>
public class ExaminationProfile : Profile
{
    public ExaminationProfile()
    {
        CreateMap<AddExaminationRequest, ExaminationDto>(MemberList.None);
        
        CreateMap<ExaminationDto, Examination>(MemberList.None);

        CreateMap<Examination, ExaminationDto>(MemberList.None)
            .ForMember(x => x.DoctorFio, map => map.MapFrom(x => x.User.FIO))
            .ForMember(x => x.PatientFio, map => map.MapFrom(x => x.History.Patient.FIO));
    }
}