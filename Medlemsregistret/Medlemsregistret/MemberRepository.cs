using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

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
            if(File.Exists(this.FilePath))
            { 
                var membersList = new List<Member>();
                var reader = new XmlSerializer(typeof(List<Member>));
                using (FileStream input = File.OpenRead(this.FilePath))
                {
                    membersList = reader.Deserialize(input) as List<Member>;
                }
            
                return membersList;
            }
            else
            {
                return new List<Member>();
            }
        }

        public void SaveMembers(List<Member> members)
        {
            File.Delete(this.FilePath);
            if(members.Count != 0)
            {
                var writer = new XmlSerializer(typeof(List<Member>));
                using (FileStream file = File.OpenWrite(this.FilePath))
                {
                    writer.Serialize(file, members);
                }
            }
        }
    }
}
