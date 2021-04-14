using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gitTeamApi.Controllers
{
    public class ArcherDbController : ApiController
    {
        public IHttpActionResult Get()
        {
            ArcherServices archerService = CreateAgentService();
            var agent = archerService.GetAgent();
            return Ok(agent);
        }
        public IHttpActionResult Post(AgentCreate agent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAgentService();

            if (!service.CreateAgent(agent))
                return InternalServerError();

            return Ok();
        }
        private ArcherServices CreateAgentId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var archerServices = new ArcherServices(userId);
            return archerServices;
        }
        public IHttpActionResult Get(int id)
        {
            ArcherServices archerService = CreateAgentService();
            var agent = archerService.GetNoteById(id);
            return Ok(agent);
        }
        public IHttpActionResult Put(AgentEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAgentService();

            if (!service.UpdateAgent(agent))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult DeleteAgent(int id)
        {
            var service = CreateAgentService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }
    }
}
