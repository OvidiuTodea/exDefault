using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.Models
{
    public static class EntitiesDbSeeder
    {
        public static void Initialize(EntitiesDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any entity.
            if (context.Entities.Any())
            {
                return;   // DB has been seeded
            }

            context.Entities.AddRange(
                new Entity
                {
                    Name = "Rose",
                    IsOrNot = true,
                    
                  
                    
                },
                new Entity
                {
                    Name = "Daisy",
                    IsOrNot = false,
                   
                    
                }
            );
            context.SaveChanges(); // commit transaction
        }
    }
}

