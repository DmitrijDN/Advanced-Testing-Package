
using DataAccess.Infrastructure;

namespace DataAccess.Entities
{
    public class User:BaseEntity
    {
        public Name Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public string PlaceOfWork { get; set; }
        public Country Country { get; set; }
        public string Password { get; set; }
    }

    public class Country: BaseEntity
    {

    }

    public enum Gender
    {
        Male,
        Female
    }
}
