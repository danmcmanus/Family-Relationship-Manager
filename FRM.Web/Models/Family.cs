using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRM.Web.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }

        public IList<FamilyMember> FamilyMembers { get; set; }
    }
}
