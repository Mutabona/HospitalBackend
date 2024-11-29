using AutoMapper;
using HospitalBackend.Contracts.Users;
using HospitalBackend.Domain.Users;

namespace HospitalBackend.Registrar.MapProfiles;

/// <summary>
/// Профиль пользователя.
/// </summary>
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserRequest, UserDto>(MemberList.None);
        
        CreateMap<User, UserDto>(MemberList.None).ReverseMap();
    }
}