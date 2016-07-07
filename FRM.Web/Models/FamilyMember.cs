using System;
using System.ComponentModel;

namespace FRM.Web.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [DisplayName("Family")]
        public string BelongsToFamilyName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public DateTime Birthday { get; set; }

    }
}