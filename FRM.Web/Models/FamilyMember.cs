using System;

namespace FRM.Web.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public FamilyMember()
        {
           
        }

    }
}