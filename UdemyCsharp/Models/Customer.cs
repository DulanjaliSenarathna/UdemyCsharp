using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UdemyCsharp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter your name")]//override default error message
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }//navigation properties customer to MembershipType
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //implicitly required, because of byte data type

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime ? BirthDate { get; set; }
    }
}