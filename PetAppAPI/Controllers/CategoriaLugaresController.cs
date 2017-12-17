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
    public class CategoriaLugaresController : ApiController
    {
        private DB_A0FC7A_PetAppEntities db = new DB_A0FC7A_PetAppEntities();

        // GET: api/CategoriaLugares
        [Route("api/CategoriaLugares/")]
        public HttpResponseMessage GetCategorias()
        {
            List<CategoriaLugares> Categorias = db.CategoriaLugares.ToList();
            List<CategoriaModel> listaCategorias = new List<CategoriaModel>();
            foreach (CategoriaLugares C in Categorias)
            {
                CategoriaModel Categoria = new CategoriaModel();

                Categoria.id = C.Id;
                Categoria.Imagen = C.Imagen;
                Categoria.nombre = C.Categoria;




                listaCategorias.Add(Categoria);



            }


            return Request.CreateResponse(HttpStatusCode.OK, listaCategorias);

        }

        // GET: api/CategoriaLugares/5
        [ResponseType(typeof(CategoriaLugares))]
        public IHttpActionResult GetCategoriaLugares(Guid id)
        {
            CategoriaLugares categoriaLugares = db.CategoriaLugares.Find(id);
            if (categoriaLugares == null)
            {
                return NotFound();
            }

            return Ok(categoriaLugares);
        }

        // PUT: api/CategoriaLugares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaLugares(Guid id, CategoriaLugares categoriaLugares)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaLugares.Id)
            {
                return BadRequest();
            }

            db.Entry(categoriaLugares).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaLugaresExists(id))
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

        // POST: api/CategoriaLugares
        [ResponseType(typeof(CategoriaLugares))]
        public IHttpActionResult PostCategoriaLugares(CategoriaLugares categoriaLugares)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaLugares.Add(categoriaLugares);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoriaLugaresExists(categoriaLugares.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categoriaLugares.Id }, categoriaLugares);
        }

        // DELETE: api/CategoriaLugares/5
        [ResponseType(typeof(CategoriaLugares))]
        public IHttpActionResult DeleteCategoriaLugares(Guid id)
        {
            CategoriaLugares categoriaLugares = db.CategoriaLugares.Find(id);
            if (categoriaLugares == null)
            {
                return NotFound();
            }

            db.CategoriaLugares.Remove(categoriaLugares);
            db.SaveChanges();

            return Ok(categoriaLugares);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaLugaresExists(Guid id)
        {
            return db.CategoriaLugares.Count(e => e.Id == id) > 0;
        }
    }
}