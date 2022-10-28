using System.ComponentModel.DataAnnotations;
using FluentValidation.Web.Models;

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

        // to use index we should use IList instead of ICollection
        // Customer.Address[1].Id => to use [1] we need to use IList
        public IList<Address> Addresses { get; set; }

        public Gender Gender { get; set; }

        // To not write extra code, we add get for that
        //public string GetFullName()
        //{
        //    return $"{Name}--{Email}--{Age}";
        //}

        // Now there's no GetFullName so we need to manually update in CustomerProfile
        public string FullName2()
        {
            return $"{Name}--{Email}--{Age}";
        }
    }
}
