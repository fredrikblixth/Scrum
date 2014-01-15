using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Medlemsregistret
{
    public class MemberRepository
    {
        public MemberRepository(string path)
        {
            this.FilePath = path;
        }

        public string FilePath { get; set; }

        public List<Member> LoadMembers()
        {
            var membersList = new List<Member>();
            

            return membersList;
        }

        public void SaveMembers(List<Member> members)
        {
        }
    }
}
