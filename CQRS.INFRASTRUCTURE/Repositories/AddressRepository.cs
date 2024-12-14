using CQRS.CORE.Interfaces;
using CQRS.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Repositories
{
   public class AddressRepository(AppDbContext dbContext) : IAddressRepository
   {
   }
}
