using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiseAndWalk_Server.Entities;
using RiseAndWalk_Server.ExceptionFilters;
using RiseAndWalk_Server.Models;
using System;
using System.Linq;
using System.Security.Claims;

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
            var userAlarms = _db.Alarms
                .Where(x => x.UserGuid == User.FindFirst(ClaimTypes.Email).Value)
                .ToList();
            return new JsonResult(userAlarms);
        }


        [InternalServerExceptionFilter]
        [HttpPost]
        public void Post([FromBody]AlarmModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(HttpContext.User.Identity.Name);
                var entity = new AlarmEntity()
                {
                    UserGuid = User.FindFirst(ClaimTypes.Email).Value,
                    AlarmTime = model.AlarmTime,
                    RepeatEveryWeek = model.RepeatEveryWeek,
                    Description = model.Description
                };

                _db.Add(entity);
                _db.SaveChanges();
            }
            else BadRequest(ModelState);
        }

        //TODO: проверка совпадения User.Name с именеим в Alarm
        [InternalServerExceptionFilter]
        [HttpPut("{id=Guid}")]
        public void Put(Guid id, [FromBody]AlarmModel model)
        {
            var entity = _db.Alarms.FirstOrDefault(x => x.AlarmId == id);
            entity.UserGuid = User.FindFirst(ClaimTypes.Email).Value;
            entity.AlarmTime = model.AlarmTime;
            entity.RepeatEveryWeek = model.RepeatEveryWeek;
            entity.Description = model.Description;


            _db.Update(entity);
            _db.SaveChanges();
        }

        //TODO: проверка совпадения User.Name с именеим в Alarm
        [InternalServerExceptionFilter]
        [HttpDelete("{id=Guid}")]
        public void Delete(Guid id)
        {
            _db.Remove(_db.Alarms.FirstOrDefault(x => x.AlarmId == id));
            _db.SaveChanges();
        }

        [InternalServerExceptionFilter]
        [HttpDelete]
        public void Delete()
        {
            _db.Remove(_db.Alarms.FirstOrDefault(x => x.UserGuid == User.FindFirst(ClaimTypes.Email).Value));
            _db.SaveChanges();
        }
    }
}