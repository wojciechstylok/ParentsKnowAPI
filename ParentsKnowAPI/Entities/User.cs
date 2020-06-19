using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsKnowAPI.Entities
{
    public class User
    {
        public User()
        {
            ApiKey = Guid.NewGuid();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid ApiKey { get; set; }

        public virtual List<Notice> PostedNotices { get; set; }
    }
}
