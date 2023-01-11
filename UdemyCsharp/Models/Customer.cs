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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }//navigation properties customer to MembershipType
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime ? BirthDate { get; set; }
    }
}