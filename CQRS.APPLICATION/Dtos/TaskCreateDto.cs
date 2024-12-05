using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.Dtos
{
    public class TaskCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
