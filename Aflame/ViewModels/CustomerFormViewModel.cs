using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aflame.Models;

namespace Aflame.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } // we make it IEnumerable cuz we don't need to 
                                                                         // Add or modify any value, just need iteration
        public Customer Customer { get; set; } // we initilize to to can access any property inside it in View 


        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0) // why we add Customer.Id != 0, 
                                                         // However if we remove it from condition, it works??
                    return "Edit Customer";
                else
                    return "New Customer";
            }
        }
    }
}