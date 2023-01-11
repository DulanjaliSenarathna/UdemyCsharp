using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UdemyCsharp.Models;

namespace UdemyCsharp.ViewModels
{
    public class CustomerFormViewModel
    {
        //if we use List here, we need to modify every time when we using different collections other than list. so we use IEnumerable as common 
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}