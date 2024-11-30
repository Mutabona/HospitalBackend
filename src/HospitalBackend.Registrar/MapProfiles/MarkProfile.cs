using AutoMapper;
using HospitalBackend.Contracts.Marks;
using HospitalBackend.Domain.Marks;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль отметок.
/// </summary>
public class MarkProfile : Profile
{
    public MarkProfile()
    {
        CreateMap<MarkDto, Mark>(MemberList.None).ReverseMap();
    }
}