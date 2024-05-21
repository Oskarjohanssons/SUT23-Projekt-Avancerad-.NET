using SUT23_Projekt___Avancerad_.NET.Dto.Requests;
using SUT23_Projekt___Avancerad_.NET.Dto.Responses;
using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<IEnumerable<CustomerDto>> GetCustomers(string name, string email, string sortField, bool ascending);
        Task<CustomerDto> GetCustomerById(int customerId);
        Task<CreateCustomerResponse> AddCustomer(CreateCustomer customer);
        Task UpdateCustomer(CustomerDto updatedCustomer);
        Task DeleteCustomer(int customerId);
        Task<double> GetTotalBookingHoursForWeek(int customerId, int year, int weekNumber);
    }
}
