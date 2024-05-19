using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface IChangeLogRepository
    {
        Task<IEnumerable<ChangeLogDto>> ChangeLogHistory();
    }
}
