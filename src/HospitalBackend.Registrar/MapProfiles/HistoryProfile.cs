using AutoMapper;
using HospitalBackend.Contracts.Histories;
using HospitalBackend.Domain.Histories;

namespace HospitalBackend.Registrar.MapProfiles;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<AddHistoryRequest, HistoryDto>(MemberList.None);
        
        CreateMap<HistoryDto, History>(MemberList.None);
        
        CreateMap<History, HistoryDto>(MemberList.None)
            .ForMember(x => x.PatientFio, map => map.MapFrom(x => x.Patient.FIO))
            .ForMember(x => x.DoctorFio, map => map.MapFrom(x => x.User.FIO));
    }
}