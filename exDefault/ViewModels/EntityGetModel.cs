using exDefault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.ViewModels
{
    public class EntityGetModel
    {

        
        public string Name { get; set; }
        public bool IsOrNot { get; set; }
        public DateTime DateOn { get; set; }
        public DateTime DateOff { get; set; }
        public EntityType EntityType { get; set; }

        public static EntityGetModel FromEntity(Entity entity)
        {
            return new EntityGetModel
            {
                Name = entity.Name,
                IsOrNot = entity.IsOrNot,
                DateOn = entity.DateOn,
                DateOff = entity.DateOff,
                EntityType = entity.EntityType
            };
        }
    }
}

