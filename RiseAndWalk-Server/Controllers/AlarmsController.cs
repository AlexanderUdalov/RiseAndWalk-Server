using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiseAndWalk_Server.Entities;
using RiseAndWalk_Server.ExceptionFilters;
using RiseAndWalk_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RiseAndWalk_Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        private AlarmsDbContext _db;

        public AlarmsController(AlarmsDbContext db)
        {
            _db = db;
        }


        [InternalServerExceptionFilter]
        [HttpGet]
        public ActionResult Get()
        {
            var userAlarms = _db.Alarms.Where(x => x.UserName == User.Identity.Name).ToList();
            return new JsonResult(userAlarms);
        }


        [InternalServerExceptionFilter]
        [HttpPost]
        public void Post([FromBody]AlarmModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new AlarmEntity()
                {
                    UserName = User.Identity.Name,
                    AlarmTime = model.AlarmTime,
                    RepeatEveryWeek = model.RepeatEveryWeek,
                    Description = model.Description
                };

                _db.Add(entity);
                _db.SaveChanges();
            }
            else BadRequest(ModelState);
        }
        

        [InternalServerExceptionFilter]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [InternalServerExceptionFilter]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}