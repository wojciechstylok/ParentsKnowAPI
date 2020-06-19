using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ParentsKnowAPI.Entities;
using ParentsKnowAPI.Models;

namespace ParentsKnowAPI
{
    public class NoticeProfile : Profile
    {
        public NoticeProfile()
        {
            CreateMap<Notice, NoticeDetailsDto>()
                .ForMember(n => n.Group, map => map.MapFrom(notice => notice.Group.GroupName))
                .ForMember(n => n.PostedBy, map => map.MapFrom(notice => notice.PostedBy.Login));

            CreateMap<NoticeDto, Notice>()
                .ForMember(n => n.Group, map => map.MapFrom(notice => notice.Group))
                .ForMember(n => n.PostedBy, map => map.MapFrom(notice => notice.PostedBy));
        }
    }
}
