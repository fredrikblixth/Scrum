using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregistret
{
    public class Member
    {
        public Member(int membershipNumber, string FirstName, string LastName)
        {
            this.MembershipNumber = membershipNumber;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int MembershipNumber { get; set; }
    }
}
