using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // to use [Requierd] and so on.

namespace Aflame.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Customer's name.")] // => It Called Annotation by this way i forced it to be not null(required)
        [StringLength(255)] // i determine Length of Name as 255 Char. 
                            // finally, you must to create Migration of this Change
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; } // This is called Navgation Property and we 
                                                           // created it to load customer and related data with it.it's better way
        [Display(Name = "Data of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BD { get; set; }

        [Display(Name = "Membership Type")] // in Validation, why it's Required, However i'm not Added Required Annotation??? => Reason in Inspect ( <option value> Select Membership Type) 
        public byte MembershipTypeId { get; set; } //Foreign Key?? => to connect two tables together.
                                                  // when we asked a sepcific data we can use just id to load it 
                                                  // so it's useful of Foreign key.
    }
}