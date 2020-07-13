
namespace Dto
{
    public class UserDto : IPersonDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
