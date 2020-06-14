using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aflame.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly byte Unknown = 0; // we used readonly cuz anyone can't change it and 
                                                 // if changed give him Compilation Error .. 
        public static readonly byte PayAsYouGo = 1;
    }
}