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
using Shopping.Models;

namespace Shopping.Controllers
{
    public class sys_userController : ApiController
    {
        private shoppingEntities db = new shoppingEntities();

        // GET: api/sys_user


        [Route("Api/Getsys_user")]
        public IQueryable<sys_user> Getsys_user()
        {
            return db.sys_user;
        }

        // GET: api/sys_user/5
        [ResponseType(typeof(sys_user))]
        public IHttpActionResult Getsys_user(int id)
        {
            sys_user sys_user = db.sys_user.Find(id);
            if (sys_user == null)
            {
                return NotFound();
            }

            return Ok(sys_user);
        }

        // PUT: api/sys_user/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsys_user(int id, sys_user sys_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sys_user.UserID)
            {
                return BadRequest();
            }

            db.Entry(sys_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sys_userExists(id))
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

        // POST: api/sys_user
        [ResponseType(typeof(sys_user))]
        public IHttpActionResult Postsys_user(sys_user sys_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sys_user.Add(sys_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (sys_userExists(sys_user.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sys_user.UserID }, sys_user);
        }

        // DELETE: api/sys_user/5
        [ResponseType(typeof(sys_user))]
        public IHttpActionResult Deletesys_user(int id)
        {
            sys_user sys_user = db.sys_user.Find(id);
            if (sys_user == null)
            {
                return NotFound();
            }

            db.sys_user.Remove(sys_user);
            db.SaveChanges();

            return Ok(sys_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sys_userExists(int id)
        {
            return db.sys_user.Count(e => e.UserID == id) > 0;
        }
    }
}