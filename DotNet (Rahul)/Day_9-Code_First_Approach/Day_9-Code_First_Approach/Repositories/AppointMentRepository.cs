using Day_9_Code_First_Approach.Data;
using Day_9_Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_9_Code_First_Approach.Repositories
{
    public class AppointMentRepository(AppDbContext _context) : IAppointMentRepository
    {
        public async Task<bool> Create(Appointment appointment)
        {
            if (appointment == null)
                return false;

            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;
   
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Appointment?> Edit(int? id)
        {
            if (id == null)
                return null;

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return null;
            return appointment;
        }

        public async Task<Appointment?> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id)
                return null;
            var check = await _context.Appointments.AnyAsync(x => x.Id == appointment.Id);
            if (!check)
                return null;

            _context.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<List<AppointmentViewModel>> GettAllAppoinments()
        {
            var appointments = await _context.Appointments
                .Join(_context.Doctors,
                a => a.DoctorId,
                d => d.Id,
                (a, d) => new AppointmentViewModel
                {
                    Id = a.Id,
                    PatientName = a.PatientName,
                    AppointmentTime = a.AppointmentTime,
                    Reason = a.Reason,
                    doctor = d
                }).ToListAsync();
            return appointments;
        }

        public async Task<Appointment?> GetByIdAppointment(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(e => e.Id == id);

        }
    }
}
