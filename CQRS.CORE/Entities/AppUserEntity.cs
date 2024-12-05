using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Entities
{
    public class AppUserEntity : IdentityUser
    {
        public ICollection<EmployeeEntity> EmployeeEntities { get; set; } = new List<EmployeeEntity>();
        public ICollection<TaskEntity> TaskEntity { get; set; } = new List<TaskEntity>();
    }
}
