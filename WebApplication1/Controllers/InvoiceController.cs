using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class InvoiceController : ApiController
    {
        // GET: api/Invoice
        public IEnumerable<tblInvoice> Get()
        {
            using (var db = new TestDBEntities())
            {
                return db.tblInvoice.ToList();
            }
        }

        // GET: api/Invoice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invoice
        public int Post([FromBody] tblInvoice Invoice)
        {
            using (var db = new TestDBEntities())
            {
                if (Invoice.InvoiceID > 0)
                {
                    tblInvoice ExsistInvoice = db.tblInvoice.FirstOrDefault(x => x.InvoiceID == Invoice.InvoiceID);
                    ExsistInvoice.Status = Invoice.Status;
                    ExsistInvoice.Amount = Invoice.Amount;
                    ExsistInvoice.LastUpdateDate = DateTime.Now;
                }
                else
                {
                    tblInvoice newInvoice = new tblInvoice
                    {
                        AddedDate = DateTime.Now,
                        LastUpdateDate = null,
                        Amount = Invoice.Amount,
                        Status = Invoice.Status
                    };
                    db.tblInvoice.Add(newInvoice);
                }
                return db.SaveChanges();
            }
        }

        // PUT: api/Invoice/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Invoice/5
        public void Delete(int id)
        {
        }
    }
}
