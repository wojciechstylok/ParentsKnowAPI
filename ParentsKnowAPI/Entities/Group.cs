using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsKnowAPI.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }


        public virtual List<Notice> Notices { get; set; }
    }
}
