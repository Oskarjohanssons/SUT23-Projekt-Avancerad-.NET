using SUT23_Projekt___Avancerad_.NET.Dto.Requests;
using SUT23_Projekt___Avancerad_.NET.Dto.Responses;
using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface ICompanyRepository
    {
        Task<List<AppointmentDto>> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate, int companyId);
        Task<IEnumerable<CompanyDto>> GetAllCompanies();
        Task<CreateCompanyResponse> AddCompany(CreateCompany company);

    }
}
