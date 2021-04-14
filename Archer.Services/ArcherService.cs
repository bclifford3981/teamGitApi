using System;
using Archer.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Services
{
    public class ArcherService
    {
        private readonly Guid _userID;

        public ArcherService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateArcher(ArcherCreate model)
        {

            var entity = new Data.Archer()
            {
                DbId = _userID,
                AgentId = model.AgentId,
                Name = model.Name,
                FieldType = model.FieldType,
                CreatedUtc = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Archer.Add(entity);
                return ctx.SaveChanges() == 1;

            }


        }

        public IEnumerable<ArcherListItems> GetArcher()
        {
            using (var ctx = new ApplicationDbContext())
            {
                ArcherListItems query =
                    ctx
                    .Archer
                    .Where(e => e.DbId == _userID)
                    .Select(
                        e =>
                        new ArcherListItems //Will need to add using statement for model created by Ben
                        {
                            // set values of each Archer List Item Property equal to e.(property)

                            AgentId = e.AgentId,
                            Name = e.Name,
                            CreatedUtc = e.CreatedUtc,
                            FieldType = e.FieldType
                        }
                        );
                return query.ToArray();
            }
        }

        public ArcherDetail GetArcherByAgentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Archer
                    .Single(e => e.AgentId == id && e.DbId == _userID);

                return
                    new ArcherDetail
                    {
                        // set values of each Archer Detail Property equal to entity.(property)
                        AgentId = entity.AgentId,
                        Name = entity.Name,
                        FieldType = entity.FieldType,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateArcher(ArcherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Archer
                    .Single(e => e.AgentId == model.AgentId && e.DbId == _userID);

                // confirm properties to be amended and update as needed

                entity.Name = model.Name;
                entity.FieldType = model.FieldType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArcher(int agentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Archer
                    .Single(e => e.AgentId == agentId && e.DbId == _userID);

                ctx.Archer.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
