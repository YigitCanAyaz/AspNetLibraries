namespace AutoMapper.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string MyName { get; set; }
        public string MyEmail { get; set; }
        public int MyAge { get; set; }
        public string FullName { get; set; }


        // AutoMapper will automatically pair with the CreditCard Number property
        //public string CreditCardNumber { get; set; }
        //public DateTime CreditCardValidDate { get; set; }

        //public string CCNumber { get; set; }
        //public DateTime CCValidDate { get; set; }

        // Include Members
        public string Number { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
