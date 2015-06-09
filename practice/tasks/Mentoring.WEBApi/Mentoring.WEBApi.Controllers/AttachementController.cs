using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mentoring.WEBApi.Models;

namespace Mentoring.WEBApi.Controllers
{
    public class AttachementController : ApiController
    {
        private static List<Attachement>  _attach = new List<Attachement>
        {
            new Attachement{Id = 1, MailId = 1, FileName = "file1_1", FileExtention = "txt", Path = "path1", StatusId = 0},
            new Attachement{Id = 2, MailId = 1, FileName = "file1_2", FileExtention = "png", Path = "path1", StatusId = 1},
            new Attachement{Id = 3, MailId = 1, FileName = "file1_3", FileExtention = "jpg", Path = "path2", StatusId = 2},
            new Attachement{Id = 4, MailId = 2, FileName = "file2_1", FileExtention = "txt", Path = "path2", StatusId = 0},
            new Attachement{Id = 5, MailId = 2, FileName = "file2_2", FileExtention = "txt", Path = "path3", StatusId = 0},
            new Attachement{Id = 6, MailId = 3, FileName = "file3_1", FileExtention = "txt", Path = "path3", StatusId = 0},
            new Attachement{Id = 7, MailId = 3, FileName = "file3_2", FileExtention = "txt", Path = "path3", StatusId = 0},
        };

        // GET: api/Attachement
        [HttpGet]
        public IEnumerable<Attachement> BrowseByMailId(int id,string ext = null, int status = -1)
        {
            return _attach.Where(x => x.MailId == id);
        }

        // GET: api/Attachement/5
        [HttpGet]
        public Attachement BrowseByMailIdAndAttachId(int id, int attid, string extention = null, int status = -1)
        {
            var res = _attach.Where(x => x.MailId == id && x.Id == attid);

            if (extention != null)
                res = res.Where(x => x.FileExtention == extention);
            if (status != -1)
                res = res.Where(x => x.StatusId == status);

            return res.FirstOrDefault(x => x.Id == attid);
        }

        [HttpPost]
        // POST: api/Attachement
        public void InsertAttach(int id, Attachement item)
        {
            int idx = _attach.Count(x => x.MailId == id);
            item.MailId = id;
            item.Id = ++idx;
            _attach.Add(item);
        }

        [HttpPut]
        // PUT: api/Attachement/5
        public void UpdateAttach(int id, int attid, Attachement item)
        {
            int idx = _attach.FindIndex(x => x.Id == attid && x.MailId == id);
            if (idx == -1)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Attachement {0} for Mail {1} not found", attid, id)));

            item.Id = attid;
            item.MailId = id;
            _attach[idx] = item;
        }

        // DELETE: api/Attachement/5
        public void Detach(int id)
        {
            _attach.RemoveAll(x => x.Id == id);
        }
    }
}
