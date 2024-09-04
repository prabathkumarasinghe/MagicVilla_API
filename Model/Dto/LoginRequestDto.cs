using Azure.Identity;

namespace MagicVilla.Model.Dto
{
	public class LoginRequestDto
	{
        public string UserName { get; set; }
        public string Password { get; set; }

	}
}
