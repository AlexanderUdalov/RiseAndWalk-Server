using System;
using System.ComponentModel.DataAnnotations;

namespace RiseAndWalk_Server.Entities
{
    public class AlarmEntity
    {
        [Key]
        public Guid AlarmId { get; set; }

        [Required]
        public string UserGuid { get; set; }
        
        [Required]
        public DateTime AlarmTime { get; set; }
        
        public bool? RepeatEveryWeek { get; set; }
        
        public string Description { get; set; }
    }
}

