using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface ICustomerAppointmentRepository
    {
        Task<AppointmentDto> AddCustomerAppointment(AppointmentDto entity);
        Task<AppointmentDto> UpdateCustomerAppointment(AppointmentDto entity);
        Task<AppointmentDto> DeleteCustomerAppointment(int id);
        Task LogCustomerChange(int appointmentId, int customerId, int companyId, string action);
    }
}
