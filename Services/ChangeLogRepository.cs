using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUT23_Projekt___Avancerad_.NET.Data;
using SUT23_Projekt___Avancerad_.NET.Dto;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public class ChangeLogRepository : IChangeLogRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ChangeLogRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChangeLogDto>> ChangeLogHistory()
        {
            var changeLogs = await _context.ChangeLogs.ToListAsync();

            return _mapper.Map<IEnumerable<ChangeLogDto>>(changeLogs);
        }

    }
}
