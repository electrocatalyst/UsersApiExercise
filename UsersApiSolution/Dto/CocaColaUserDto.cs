

namespace Dto
{
    public class CocaColaUserDto : IPersonDto
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public string Fullname { get; set; }
        public int Age { get; set; }
    }
}
