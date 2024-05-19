using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface ICompanyAppointmentRepository
    {
        Task<AppointmentDto> AddCompanyAppointment(AppointmentDto entity);
        Task<AppointmentDto> UpdateCompanyAppointment(AppointmentDto entity);
        Task<AppointmentDto> DeleteCompanyAppointment(int id);
        Task LogCompanyChange(int appointmentId, int customerId, int companyId, string action);
    }
}
