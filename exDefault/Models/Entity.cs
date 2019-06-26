using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.Models
{
    public enum EntityType
    {
        Good,
        Bad
    }
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOrNot { get; set; }
        public DateTime DateOn { get; set; }
        public DateTime DateOff { get; set; }
        [EnumDataType(typeof(EntityType))]
        public EntityType EntityType { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
