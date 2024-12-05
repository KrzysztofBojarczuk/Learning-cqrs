﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; } //unikalny identyfikator
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
        public AppUserEntity AppUserEntity { get; set; } = null!;
    }
}
