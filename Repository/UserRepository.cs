//using MagicVilla.Data;
//using MagicVilla.Model;
//using MagicVilla.Model.Dto;
//using MagicVilla.Repository.IRepository;
//using MagicVilla_Web.Models;
//using MagicVilla_Web.Models.Dto;

//namespace MagicVilla.Repository
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _db;

//        public UserRepository(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        public bool IsUniqueUser(string username)
//        {
//            var user = _db.localUsers.FirstOrDefault(x=>x.UserName==username);
//            if (user == null)
//            {
//                return true;
//            }
//            return false;
//        }

//        public Task<LoginResponseDto> Login(LoginResponseDto loginResponseDto)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<LocalUser> Register(RegistrationRequestDto registerationRequestDto)
//        {
//            LocalUser user = new LocalUser() { } 
//        }
//    }
//}
