using System.ComponentModel.DataAnnotations;

namespace FluentValidation.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name cannot be null!")]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
