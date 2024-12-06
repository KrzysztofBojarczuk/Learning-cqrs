﻿using CQRS.CORE.Entities;
using CQRS.CORE.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Features.Task.Commands
{
    public record AddTaskCommand(TaskEntity Task) : IRequest<TaskEntity>;

    public class AddTaskCommandHandler(ITaskRepository taskRepository, IPublisher mediator) 
        : IRequestHandler<AddTaskCommand, TaskEntity>
    {
        public async Task<TaskEntity> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await taskRepository.AddTaskAsync(request.Task);
            return task;
        }
    }
}
