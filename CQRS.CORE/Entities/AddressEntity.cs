using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CORE.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string AppUserId { get; set; } = null!;
        public AppUserEntity AppUserEntity { get; set; } = null!;
    }
}
