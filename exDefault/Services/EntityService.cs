using exDefault.Models;
using exDefault.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.Services
{
    
        public interface IEntityService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <returns></returns>
            IEnumerable<EntityGetModel> GetAll(DateTime? from = null, DateTime? to = null);
            Entity GetById(int id);
            Entity Create(EntityPostModel entity);
            Entity Upsert(int id, Entity entity);
            Entity Delete(int id);
        }
        public class EntityService : IEntityService
        {
            private EntitiesDbContext context;
            public EntityService(EntitiesDbContext context)
            {
                this.context = context;
            }

            public Entity Create(EntityPostModel entity)
            {
                Entity toAdd = EntityPostModel.ToEntity(entity);
                context.Entities.Add(toAdd);
                context.SaveChanges();
                return toAdd;
            }

            public Entity Delete(int id)
            {
                var existing = context.Entities.FirstOrDefault(e => e.Id == id);
                if (existing == null)
                {
                    return null;
                }
                context.Entities.Remove(existing);
                context.SaveChanges();

                return existing;
            }

            public IEnumerable<EntityGetModel> GetAll(DateTime? from = null, DateTime? to = null)
            {
                IQueryable<Entity> result = context
                    .Entities
                    .Include(f => f.Comments);
                if (from == null && to == null)
                {
                    return result.Select(f => EntityGetModel.FromEntity(f));
                }
                if (from != null)
                {
                    result = result.Where(f => f.DateOn >= from);
                }
                if (to != null)
                {
                    result = result.Where(f => f.DateOff <= to);
                }
                return result.Select(f => EntityGetModel.FromEntity(f));
            }

            public Entity GetById(int id)
            {
                // sau context.Flowers.Find()
                return context.Entities
                    .Include(f => f.Comments)
                    .FirstOrDefault(f => f.Id == id);
            }

            public Entity Upsert(int id, Entity entity)
            {
                var existing = context.Entities.AsNoTracking().FirstOrDefault(f => f.Id == id);
                if (existing == null)
                {
                    context.Entities.Add(entity);
                    context.SaveChanges();
                    return entity;
                }
                entity.Id = id;
                context.Entities.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }