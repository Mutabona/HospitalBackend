using AutoMapper;
using HospitalBackend.Contracts.Patients;
using HospitalBackend.Domain.Patients;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль пациента.
/// </summary>
public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<AddPatientRequest, PatientDto>(MemberList.None);
        
        CreateMap<PatientDto, Patient>(MemberList.None).ReverseMap();
    }
}