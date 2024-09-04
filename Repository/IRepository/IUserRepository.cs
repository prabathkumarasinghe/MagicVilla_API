using MagicVilla.Model;
using MagicVilla.Model.Dto;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginResponseDto loginResponseDto);
        Task<LocalUser> Register(RegisterationRequestDto registerationRequestDto);
    }
}
