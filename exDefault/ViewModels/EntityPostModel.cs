using exDefault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.ViewModels
{
    public class EntityPostModel
    {


        public string Name { get; set; }
        public bool IsOrNot { get; set; }
        public DateTime DateOn { get; set; }
        public DateTime DateOff { get; set; }
        public string EntityType { get; set; }

        public static Entity ToEntity(EntityPostModel entity)
        {
            
            EntityType entityType = Models.EntityType.Good;
            if (entity.EntityType == "Bad")
            {
                entityType = Models.EntityType.Bad;
            }
            return new Entity
            {
                Name = entity.Name,
                IsOrNot = entity.IsOrNot,
                DateOn = entity.DateOn,
                DateOff = entity.DateOff,
                EntityType = entityType

            };
        }
    }
}
