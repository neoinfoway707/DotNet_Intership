using Day_9_Code_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_9_Code_First_Approach.Repositories
{
    public interface IAppointMentRepository
    {
        public Task<List<AppointmentViewModel>> GettAllAppoinments();
        public Task<Appointment?> GetByIdAppointment(int id);
        public Task<bool> Create(Appointment appointment);
        public Task<Appointment?> Edit(int? id);
        public Task<Appointment?> Edit(int id, Appointment appointment);
        public Task<bool> Delete(int? id);
    }
}
