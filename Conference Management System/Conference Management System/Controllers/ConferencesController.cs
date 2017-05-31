using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Conference_Management_System.Models;
using Conference_Management_System.Models.DTO;

namespace Conference_Management_System.Controllers
{
    public class ConferencesController : ApiController
    {
        private CMS db = new CMS();

        // GET: api/Conferences
        public IQueryable<ConferenceDTO> GetConferences()
        {
            return from conf in db.Conferences
                   select new ConferenceDTO()
                   {
                      Id = conf.Id,
                      Name = conf.Name,
                      Date = conf.Date,
                      StartTime = conf.StartTime,
                      EndTime = conf.EndTime,
                      SubmissionDeadline = conf.EndTime
                   };
        }

        // GET: api/Conferences/5
        [ResponseType(typeof(ConferenceDTO))]
        public IHttpActionResult GetConference(int id)
        {
            ConferenceDTO conference = db.Conferences.Select(conf => new ConferenceDTO()
            {
                Id = conf.Id,
                Name = conf.Name,
                Date = conf.Date,
                StartTime = conf.StartTime,
                EndTime = conf.EndTime,
                SubmissionDeadline = conf.EndTime
            }).SingleOrDefault(conf => conf.Id == id);
            if (conference == null)
            {
                return NotFound();
            }

            return Ok(conference);
        }

// TODO: All write methods are commented, can be used for later tasks
        
        // PUT: api/Conferences/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutConference(int id, Conference conference)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//
//            if (id != conference.Id)
//            {
//                return BadRequest();
//            }
//
//            db.Entry(conference).State = EntityState.Modified;
//
//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ConferenceExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//
//            return StatusCode(HttpStatusCode.NoContent);
//        }

        // POST: api/Conferences
//        [ResponseType(typeof(Conference))]
//        public IHttpActionResult PostConference(Conference conference)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//
//            db.Conferences.Add(conference);
//            db.SaveChanges();
//
//            return CreatedAtRoute("DefaultApi", new { id = conference.Id }, conference);
//        }

        // DELETE: api/Conferences/5
//        [ResponseType(typeof(Conference))]
//        public IHttpActionResult DeleteConference(int id)
//        {
//            Conference conference = db.Conferences.Find(id);
//            if (conference == null)
//            {
//                return NotFound();
//            }
//
//            db.Conferences.Remove(conference);
//            db.SaveChanges();
//
//            return Ok(conference);
//        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConferenceExists(int id)
        {
            return db.Conferences.Count(e => e.Id == id) > 0;
        }
    }
}