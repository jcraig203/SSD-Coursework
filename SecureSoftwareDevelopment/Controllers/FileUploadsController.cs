using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecureSoftwareDevelopment.Models;

namespace SecureSoftwareDevelopment.Controllers
{
    public class FileUploadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FileUploads
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.FileUploads.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: FileUploads/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: FileUploads/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: FileUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fileID,SetFileName,expectedSizeofFile,documentType,docLocation")] FileUpload fileUpload)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
            {
                db.FileUploads.Add(fileUpload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileUpload);
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}

        // GET: FileUploads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}

        // POST: FileUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fileID,SetFileName,expectedSizeofFile,documentType,docLocation")] FileUpload fileUpload)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
            {
                db.Entry(fileUpload).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileUpload);
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}

        // GET: FileUploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: FileUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                FileUpload fileUpload = db.FileUploads.Find(id);
            db.FileUploads.Remove(fileUpload);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            else
            {
                return RedirectToAction("Login", "Account");
    }
}
        // GET: FileUploads/CopyTo/5
        public ActionResult CopyTo(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FileUpload fileUpload = db.FileUploads.Find(id);
                if (fileUpload == null)
                {
                    return HttpNotFound();
                }
                return View(fileUpload);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: FileUploads/CopyTo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CopyTo([Bind(Include = "fileID,SetFileName,expectedSizeofFile,documentType,docLocation")] FileUpload fileUpload)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.FileUploads.Add(fileUpload);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(fileUpload);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
