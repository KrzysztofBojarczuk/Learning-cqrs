using CQRS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetUserTasksAsync(string appUserId);
        Task<TaskEntity> GetTaskByIdAsync(Guid id);
        Task<TaskEntity> AddTaskAsync(TaskEntity entity);
        Task<TaskEntity> TaskAsync(Guid employeeId, TaskEntity entity);
        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}
