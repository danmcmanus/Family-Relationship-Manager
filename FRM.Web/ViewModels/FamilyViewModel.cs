using FRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRM.Web.ViewModels
{
    public class FamilyViewModel
    {
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public IEnumerable<FamilyMember> FamilyMembers { get; set; }
    }
}
