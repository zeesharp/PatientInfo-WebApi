using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HospitalMIS_WebApi.Data;
using HospitalMIS_WebApi.Models;

namespace HospitalMIS_WebApi.Controllers
{
    public class PatientInfoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PatientInfo
        public IQueryable<PatientInfo> GetPatientInfo()
        {
            return db.PatientInfo;
        }

        // GET: api/PatientInfo/5
        [ResponseType(typeof(PatientInfo))]
        public async Task<IHttpActionResult> GetPatientInfo(int id)
        {
            PatientInfo patientInfo = await db.PatientInfo.FindAsync(id);
            if (patientInfo == null)
            {
                return NotFound();
            }

            return Ok(patientInfo);
        }

        // PUT: api/PatientInfo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientInfo(int id, PatientInfo patientInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(patientInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PatientInfo
        [ResponseType(typeof(PatientInfo))]
        public async Task<IHttpActionResult> PostPatientInfo(PatientInfo patientInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatientInfo.Add(patientInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patientInfo.Id }, patientInfo);
        }

        // DELETE: api/PatientInfo/5
        [ResponseType(typeof(PatientInfo))]
        public async Task<IHttpActionResult> DeletePatientInfo(int id)
        {
            PatientInfo patientInfo = await db.PatientInfo.FindAsync(id);
            if (patientInfo == null)
            {
                return NotFound();
            }

            db.PatientInfo.Remove(patientInfo);
            await db.SaveChangesAsync();

            return Ok(patientInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientInfoExists(int id)
        {
            return db.PatientInfo.Count(e => e.Id == id) > 0;
        }
    }
}