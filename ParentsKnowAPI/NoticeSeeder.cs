using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParentsKnowAPI.Entities;

namespace ParentsKnowAPI
{
    public class NoticeSeeder
    {
        private readonly NoticeContext _noticeContext;
        public NoticeSeeder(NoticeContext noticeContext)
        {
            _noticeContext = noticeContext;
        }

        public void Seed()
        {
            if (_noticeContext.Database.CanConnect())
            {
                if (!_noticeContext.Notices.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var user = new User
            {
                UserName = "Administrator",
                Login = "admin",
                Password = "admin"
            };

            var notices = new List<Notice>
            {
                new Notice
                {
                    Name = "Dzień Ojca",
                    Content = "Zapraszamy na przedstawienie z okacji Dnia Ojca",
                    Date = new DateTime(2020, 6, 30, 15, 30, 00),
                    PostedBy = user,
                    Group = new Group
                    {
                        GroupName = "3-latki"
                    }
                },
                new Notice
                {
                    Name = "Dzień Matki",
                    Content = "Zapraszamy na przedstawienie z okacji Dnia Matki",
                    Date = new DateTime(2020, 5, 30, 15, 45, 00),
                    PostedBy = user,
                    Group = new Group
                    {
                        GroupName = "4-latki"
                    }
                }
            };

            _noticeContext.AddRange(notices);
            _noticeContext.SaveChanges();
        }
    }
}
