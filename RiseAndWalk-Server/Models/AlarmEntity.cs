using RiseAndWalk_Server.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiseAndWalk_Server.Entities
{
    public class AlarmEntity
    {
        [Key]
        public Guid AlarmId { get; set; }

        public string UserName { get; set; }

        [Column("alarm_time")]
        public DateTime AlarmTime { get; set; }

        [Column("repeat_every_week")]
        public bool RepeatEveryWeek { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}

