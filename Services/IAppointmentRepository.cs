using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointments();
        Task<IEnumerable<AppointmentDto>> GetAppointments(DateTime? startDate, DateTime? endDate, int? companyId, string sortField, bool ascending);
    }
}
