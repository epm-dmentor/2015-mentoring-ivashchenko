using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mentoring.WEBApi.Models;

namespace Mentoring.WEBApi.Controllers
{
 public class MailsController : ApiController
    {

        private static List<Mail> _mails = new List<Mail>
        {
            new Mail {
                       Id = 1, Subject = "Subj mail 1", Sender = "send1@mymail.com",  To ="to1@mymail.com", Cc = null,
                       Body = "Body 1", AttachementId = 0, Priority = Priority.Low, Received = DateTime.Now, Saved = DateTime.Now
                     },
            new Mail
                    {
                      Id = 2, Subject = "Subj mail 2", Sender = "send2@mymail.com",  To ="to2@mymail.com", Cc = null,
                       Body = "Body 2", AttachementId = 0, Priority = Priority.Low, Received = DateTime.Now, Saved = DateTime.Now                
                    },
            new Mail
                    {
                      Id = 3, Subject = "Subj mail 3", Sender = "send3@mymail.com",  To ="to3@mymail.com", Cc = null,
                       Body = "Body 3", AttachementId = 0, Priority = Priority.Low, Received = DateTime.Now, Saved = DateTime.Now                
                    }
        };

        // GET: api/Mails
        public IEnumerable<Mail> Get()
        {
            return _mails; 
        }

        // GET: api/Mails/5
        public Mail Get(int id)
        {
            var ret =_mails.Find(x => x.Id == id);
            if (ret != null)
                return ret;
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Mail {0} not found", id) ));
        }

        // POST: api/Mails
        public void Post(Mail item)
        {
            item.Id = _mails.Count + 1;
            _mails.Add(item);
        }

        // PUT: api/Mails/5
        public void Put(int id, Mail item)
        {
            int idx = _mails.FindIndex(x => x.Id == id);
            if(id <= 0 || id > _mails.Count || item == null || idx == -1)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Mail {0} not found", id) ));

            item.Id = id;
            _mails[idx] = item;
        }

        // DELETE: api/Mails/5
        public void Delete(int id)
        {
            if (id <= 0 || id > _mails.Count)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Mail {0} not found", id)));
            _mails.RemoveAll(x => x.Id == id);
        }
    }
}
