using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSTOneighboreenos.DAL;
using TSTOneighboreenos.Models;

namespace TSTOneighboreenos.Controllers
{
    public class PlayerController : Controller
    {
        //private NeighboreenoContext db = new NeighboreenoContext();  // original context
        private IPlayerRepository repo;

        // Called by MVC Framework
        public PlayerController()
        {
            repo = new PlayerRepository(new NeighboreenoContext());
        }

        // called by the unit tests
        public PlayerController(IPlayerRepository fakeRepo)
        {
            repo = fakeRepo;
        }

        // GET: Player
        public ActionResult Index()
        {
            //return View(db.Players.ToList());  // original code
            return View(repo.GetPlayers());
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = db.Players.Find(id);   // orignal code
            Player player = repo.GetPlayerByID((int)id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // NOTE:  Added a try-catch block
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TSTOhandle,Level,NameFirst,MidInit,NameLast,Email,SpringfieldPath,Active,AddMe")] Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*db.Players.Add(player);  // original code
                    db.SaveChanges();*/
                    repo.InsertPlayer(player);
                    repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = db.Players.Find(id);   // original code
            Player player = repo.GetPlayerByID((int)id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // NOTE: Removed ID field and added MidInit to Bind
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var playerToUpdate = db.Players.Find(id);    // original code
            var playerToUpdate = repo.GetPlayerByID((int)id);

            if(TryUpdateModel(playerToUpdate, "",
                new string[] { "TSTOhandle", "Level", "NameFirst", "MidInt", "NameLast", "Email"}))
            {
                try
                {
                    /*db.Entry(playerToUpdate).State = EntityState.Modified;
                    db.SaveChanges(); */  // original block of code
                    repo.UpdatePlayer(playerToUpdate);
                    repo.Save();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(playerToUpdate);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = db.Players.Find(id);    // original code
            Player player = repo.GetPlayerByID((int)id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();*/
            repo.DeletePlayer(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
