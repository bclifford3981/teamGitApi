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
            ArcherServices archerService = CreateNoteService();
            var notes = archerService.GetNotes();
            return Ok(notes);
        }
        public IHttpActionResult Post(AgentCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAgentService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }
        private ArcherServices CreateAgentId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new ArcherServices(userId);
            return noteService;
        }
        public IHttpActionResult Get(int id)
        {
            ArcherServices archerService = CreateNoteService();
            var note = archerService.GetNoteById(id);
            return Ok(note);
        }
        public IHttpActionResult Put(AgentEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAgentService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAgentService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }
    }
}
