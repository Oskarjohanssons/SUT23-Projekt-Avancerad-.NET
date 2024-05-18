using ClassLibary;
using Microsoft.EntityFrameworkCore;
using SUT23_Projekt___Avancerad_.NET.Data;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public class AppointmentRepo : IAppData<Appointment>
    {
        private AppDbContext _appDbContext;
        public AppointmentRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Appointment> Add(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _appDbContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetSingle(int id)
        {
            return await _appDbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == id);
        }

        public Task<Appointment> Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
