using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using XMProWebAPI.Models;

namespace XMProWebAPI.Controllers
{
    public class ParcelsController : ODataController
    {
        ParcelContext db = new ParcelContext();
        // GET <controller>
        [EnableQuery]
        public IEnumerable<Parcels> Get()
        {
            return db.Parcels;
        }

        // GET <controller>?id=5
        [EnableQuery]
        public SingleResult<Parcels> Get([FromODataUri] int Id)
        {
            IQueryable<Parcels> result = db.Parcels.Where(p => p.ParcelID == Id);

            return SingleResult.Create(result);
        }

        // POST <controller>
        public async Task<IHttpActionResult> Post(Parcels Parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parcels.Add(Parcel);
            await db.SaveChangesAsync();
            return Created(Parcel);
        }

        // PUT <controller>?Id=5
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromODataUri] int Id, [FromBody] Parcels update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Id != update.ParcelID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        // DELETE <controller>?Id=5
        public async Task<IHttpActionResult> Delete([FromODataUri] int Id)
        {
            var _parcel = await db.Parcels.FindAsync(Id);
            if (_parcel == null)
            {
                return NotFound();
            }
            db.Parcels.Remove(_parcel);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool ParcelExists(int Id)
        {
            bool _return = false;
            Parcels _parcel = db.Parcels.Where(p => p.ParcelID == Id).FirstOrDefault();

            if(_parcel != null)
            {
                _return = true;
            }
            return _return;
        }
    }
}