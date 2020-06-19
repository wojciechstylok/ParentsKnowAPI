using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsKnowAPI.Entities
{
    public class Notice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public virtual User PostedBy { get; set; }
        public virtual Group Group { get; set; }
    }
}