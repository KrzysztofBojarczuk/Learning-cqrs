using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;

namespace CQRS.API.Controllers
{
    public record GetUserTasksQuery(string appUserId) : IRequest<IEnumerable<TaskEntity>>;

    public class GetUserTasksQueryHandler(ITaskRepository taskRepository)
        : IRequestHandler<GetUserTasksQuery, IEnumerable<TaskEntity>>
    {
        public async Task<IEnumerable<TaskEntity>> Handle(GetUserTasksQuery request, CancellationToken cancellationToken)
        {
            return await taskRepository.GetUserTasksAsync(request.appUserId);
        }
    }
}
