using AutoMapper;
using HospitalBackend.Contracts.Analyzes;
using HospitalBackend.Domain.Analyzes;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль анализа.
/// </summary>
public class AnalysisProfile : Profile
{
    public AnalysisProfile()
    {
        CreateMap<AddAnalysisRequest, AnalysisDto>(MemberList.None);
        
        CreateMap<AnalysisDto, Analysis>(MemberList.None).ReverseMap();
    }
}