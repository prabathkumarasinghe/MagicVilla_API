
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using MagicVilla_Web.Models;


namespace MagicVilla.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<LocalUser> Register(RegisterationRequestDto registerationRequestDto);
    }
}
