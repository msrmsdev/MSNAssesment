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
using CIBDigiTechAssessment.WebAPI;

namespace CIBDigiTechAssessment.WebAPI.Controllers
{
    public class PhoneBooksController : ApiController
    {
        private PhoneBookDBEntities db = new PhoneBookDBEntities();

        // GET: api/PhoneBooks
        public IQueryable<PhoneBook> GetPhoneBooks()
        {
            return db.PhoneBooks;
        }

        // GET: api/PhoneBooks/5
        [ResponseType(typeof(PhoneBook))]
        public IHttpActionResult GetPhoneBook(int id)
        {
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            return Ok(phoneBook);
        }

        private bool isContactNumberExists(string contactNumber)
        {
            return db.PhoneBooks.Count(e => e.Contact == contactNumber) > 0;
        }

        // PUT: api/PhoneBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoneBook(int id, PhoneBook phoneBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneBook.PhoneBookID)
            {
                return BadRequest();
            }

            db.Entry(phoneBook).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookExists(id))
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

        // POST: api/PhoneBooks
        [ResponseType(typeof(PhoneBook))]
        public IHttpActionResult PostPhoneBook(PhoneBook phoneBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhoneBooks.Add(phoneBook);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phoneBook.PhoneBookID }, phoneBook);
        }

        // DELETE: api/PhoneBooks/5
        [ResponseType(typeof(PhoneBook))]
        public IHttpActionResult DeletePhoneBook(int id)
        {
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            db.PhoneBooks.Remove(phoneBook);
            db.SaveChanges();

            return Ok(phoneBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneBookExists(int id)
        {
            return db.PhoneBooks.Count(e => e.PhoneBookID == id) > 0;
        }
    }
}