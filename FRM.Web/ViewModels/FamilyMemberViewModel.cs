using FRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRM.Web.ViewModels
{
    public class FamilyMemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string Birthday { get; set; }
        public IEnumerable<FamilyMember> FamilyMembers { get; set; }

    }
}
