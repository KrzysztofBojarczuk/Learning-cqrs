using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Repositories
{
    public class TaskRepository(AppDbContext dbContext) : ITaskRepository
    {
        public async Task<IEnumerable<TaskEntity>> GetTasksAsync(string appUserId)
        {
            return await dbContext.Tasks
                .Where(t => t.AppUserId == appUserId)
                .ToListAsync();
        }

        public async Task<TaskEntity> GetTaskByIdAsync(Guid id)
        {
            return await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskEntity> AddTaskAsync(TaskEntity entity)
        {
            entity.Id = Guid.NewGuid(); // Przypisanie nowego identyfikatora
            dbContext.Tasks.Add(entity);

            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskEntity> TaskAsync(Guid employeeId, TaskEntity entity)
        {
            var task = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (task is not null)
            {
                task.Name = entity.Name;
                task.Description = entity.Description;

                await dbContext.SaveChangesAsync();
                return task;
            }

            return null; 
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var task = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task is not null)
            {
                dbContext.Tasks.Remove(task);
                return await dbContext.SaveChangesAsync() > 0; 
            }

            return false;
        }
    }
}
