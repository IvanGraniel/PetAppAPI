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
using PetAppAPI;
using PetAppAPI.Models;


namespace PetAppAPI.Controllers
{
    public class LugaresController : ApiController
    {
        private DB_A0FC7A_PetAppEntities db = new DB_A0FC7A_PetAppEntities();

        // GET: api/Lugares
        [Route("api/Lugares/{categoria}")]
        public HttpResponseMessage GetLugar(Guid categoria)
        {
            List<Lugar> lugares = db.Lugar.Where(e => e.IdCategoria == categoria ).ToList();
            List<LugarModel> listaLugares = new List<LugarModel>();  
            foreach (Lugar l in lugares)
            {
                LugarModel lugar = new LugarModel();
                lugar.email = l.Email;
                lugar.horario = l.Horario;
                lugar.nombre = l.Nombre;
                lugar.telefono = l.Telefono;
                lugar.facebook = l.Facebook;
                lugar.latitud = l.Latitud;
                lugar.longitud = l.Longitude;
                lugar.twitter = l.Twitter;
                CategoriaLugares categoriaLugar= db.CategoriaLugares.Where(c => c.Id == l.IdCategoria).FirstOrDefault();
                Direcciones dir = db.Direcciones.Where(c => c.Id == l.Direccion).FirstOrDefault();
                lugar.categoria = categoriaLugar.Categoria;
                lugar.direccion = dir.Direccion;




                listaLugares.Add(lugar);



            }

           
            return Request.CreateResponse(HttpStatusCode.OK,listaLugares);

        }

  
       

        // PUT: api/Lugares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLugar(Guid id, Lugar lugar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lugar.Id)
            {
                return BadRequest();
            }

            db.Entry(lugar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugarExists(id))
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

        // POST: api/Lugares
        [ResponseType(typeof(Lugar))]
        public IHttpActionResult PostLugar(Lugar lugar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lugar.Add(lugar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LugarExists(lugar.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lugar.Id }, lugar);
        }

        // DELETE: api/Lugares/5
        [ResponseType(typeof(Lugar))]
        public IHttpActionResult DeleteLugar(Guid id)
        {
            Lugar lugar = db.Lugar.Find(id);
            if (lugar == null)
            {
                return NotFound();
            }

            db.Lugar.Remove(lugar);
            db.SaveChanges();

            return Ok(lugar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LugarExists(Guid id)
        {
            return db.Lugar.Count(e => e.Id == id) > 0;
        }
    }
}