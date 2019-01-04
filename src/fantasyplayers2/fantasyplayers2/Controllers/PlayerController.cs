using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraussDa.ApplicationCore.Entities;
using StraussDa.ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _pRepo;

        public PlayerController(IPlayerRepository pRepo)
        {
            _pRepo = pRepo;
        }
        // GET: Player
        public ActionResult Index()
        {
            return View(_pRepo.ListAll());
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            return View(_pRepo.GetById(id));
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View(new Player());
        }

        // POST: Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player newPlayer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _pRepo.Add(newPlayer);
                    return RedirectToAction(nameof(Index));
                }


                
            }
            catch(Exception ex)
            {
               //TODO LOG THE ERROR
            }

            return View(newPlayer);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_pRepo.GetById(id));
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Player editedPlayer)
        {
            try
            {
                _pRepo.Edit(editedPlayer);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                //TODO Log the Exception
            }
            return View(editedPlayer);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_pRepo.GetById(id));
        }

        // POST: Player/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Player deletedPlayer)
        {
            try
            {
                _pRepo.Delete(deletedPlayer);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                //TODO Log Exception
            }
            return View(deletedPlayer);
        }
    }
}