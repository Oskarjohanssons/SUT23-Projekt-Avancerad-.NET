using ClassLibary;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface ICustomer<T>
    {
        Task<Customer> GetSingleCustomer(int id);
        Task<Appointment> CancelAppointment(Appointment appointment);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> GetUserWithAppointment(int id);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task LogAppointmentChange(string changeType, DateTime? oldAppointmentTime, DateTime? newAppointmentTime, Appointment appointment);
    }
}
