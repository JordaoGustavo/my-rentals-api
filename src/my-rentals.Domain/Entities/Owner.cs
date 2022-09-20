using my_rental.Domain.Commons;

namespace my_rental.Domain.Entities
{
    public class Owner : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
