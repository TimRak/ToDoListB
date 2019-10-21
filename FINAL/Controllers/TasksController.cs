using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FINAL.Models;

namespace FINAL.Controllers
{
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController() : this(new Dal())
        {

        }

        private LoginController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        public ActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Utilisateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel, string returnUrl)
        {
            viewModel.Utilisateur.ConfirmMotDePasse = viewModel.Utilisateur.MotDePasse; 
            if(true)//if(ModelState.IsValid)
            {
                Utilisateur utilisateur = dal.Authentifier(viewModel.Utilisateur.Nom, viewModel.Utilisateur.MotDePasse);
                if (utilisateur != null)
                {
                    FormsAuthentication.SetAuthCookie(utilisateur.Id.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Utilisateur.Nom", "Nom et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerCompte(Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                int id = dal.AjouterUtilisateur(utilisateur.Nom, utilisateur.MotDePasse, utilisateur.ConfirmMotDePasse, utilisateur.Email);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(utilisateur);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }

    public class TasksController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Tasks
        /*public ActionResult Index()
        {
            return View(db.Tasks.Where(x => (x.User == HttpContext.User.Identity.Name && x.Type == "task") || x.Type == "blogpost").ToList()); 
        }*/

        public ActionResult Index()
        {
            TaskViewModel viewModel = new TaskViewModel { taskmodels = db.Tasks.Where(x => x.User == HttpContext.User.Identity.Name && x.Type == "task" || x.Type == "blogpost").ToList() };
            return View(viewModel);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModel task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Title,Type,Date,Description,Status,Votes")] TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.User = HttpContext.User.Identity.Name;
                task.Status = false;
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        /* 
        public static ITask create_itask(string itask_name)
        {
            switch(itask_name)
                case "blogpost":
                    return new blogpost();
                case "task":
                    return new task();
                default:
                    break;
        }
        */

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModel task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Title,Type,Date,Description,Status,Votes")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskModel task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskModel task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateStatus(int? id, bool button)
        {
            TaskModel task = db.Tasks.Find(id);

            if (task.Type=="task")
            {
                ITask ftask = Factory.create_task("task");
                ftask.UpdateStatus(task.Status);
            }

            if (task.Type=="blogpost")
            {
                ITask fblogpost = Factory.create_task("blogpost");
                fblogpost.UpdateStatus(button);
            }

            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (task == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
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
