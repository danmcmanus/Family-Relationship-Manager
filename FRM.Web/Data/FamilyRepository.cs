using FRM.Web.Contracts;
using FRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRM.Web.Data
{
    public class FamilyRepository : RepositoryBase<Family>
    {
        public FamilyRepository(ApplicationDbContext context) : base(context)
        {
            if (context == null)
            {
                throw new NullReferenceException();
            }
        }
    }
}
