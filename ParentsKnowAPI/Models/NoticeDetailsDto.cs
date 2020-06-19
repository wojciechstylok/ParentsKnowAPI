using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsKnowAPI.Models
{
    public class NoticeDetailsDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Group { get; set; }
        public string PostedBy { get; set; }
    }
}
