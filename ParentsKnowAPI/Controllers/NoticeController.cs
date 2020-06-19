using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParentsKnowAPI.Entities;
using AutoMapper;
using ParentsKnowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ParentsKnowAPI.Controllers
{
    [Route("api/notices")]
    public class NoticeController : ControllerBase
    {
        private readonly NoticeContext _noticeContext;
        private readonly IMapper _mapper;

        public NoticeController(NoticeContext noticeContext, IMapper mapper)
        {
            _noticeContext = noticeContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<NoticeDetailsDto>> Get()
        {
            var notices = _noticeContext.Notices.Include(n => n.Group).Include(n => n.PostedBy).ToList();
            var noticeDtos = _mapper.Map<List<NoticeDetailsDto>>(notices);

            return Ok(noticeDtos);
        }

        [HttpGet("{groupName}")]
        public ActionResult<List<NoticeDetailsDto>> Get(string groupName)
        {
            var notices = _noticeContext.Notices
                .Include(n => n.Group)
                .Include(n => n.PostedBy)
                .Where(n => n.Group.GroupName.Replace(" ", "-").ToLower() == groupName.ToLower())
                .ToList();

            if(notices == null)
            {
                return NotFound();
            }

            var noticeDtos = _mapper.Map<List<NoticeDetailsDto>>(notices);

            return Ok(noticeDtos);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NoticeDto model)
        {
            var notice = _mapper.Map<Notice>(model);

            _noticeContext.Notices.Add(notice);
            _noticeContext.SaveChanges();

            var key = notice.Name.Replace(" ", "-").ToLower();

            return Created("api/notices/" + key, null);
        }
    }
}
