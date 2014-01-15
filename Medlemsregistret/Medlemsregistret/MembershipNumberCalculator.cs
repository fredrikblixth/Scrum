using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregistret
{
    public static class MembershipNumberCalculator
    {
        public static int CalculateMembershipNumber(List<Member> members)
        {
            if (members.Count != 0)
            { 
                var highestMemberNumber = 0;

                foreach (Member member in members)
                {
                    highestMemberNumber = (highestMemberNumber < member.MembershipNumber) ? member.MembershipNumber : highestMemberNumber;
                }

                return highestMemberNumber + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
