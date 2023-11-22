using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstraction
{
    public interface ISchedulerRepo
    {
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task<int> AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(int id, Schedule schedule);
        Task DeleteScheduleAsync(int id);
        Task ApproveScheduleAsync(int id);
        Task DeclineScheduleAsync(int id);
    }

}
