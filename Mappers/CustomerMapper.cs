using ClassLibary;

namespace SUT23_Projekt___Avancerad_.NET.Mappers
{
    public class CustomerMapper
    {
        public static CustomerDTO MapToDTO(Customer customer)
        {
            return new CustomerDTO
            {
                Name = customer.CustomerName,
                Email = customer.CustomerEmail,
            };
        }
    }
}
