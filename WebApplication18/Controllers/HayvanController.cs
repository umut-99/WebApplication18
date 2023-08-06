using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class HayvanController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public HayvanController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var Hayvans = databaseContext.Hayvans.ToList();
            return View(Hayvans);
        }

        public IActionResult Index2()
        {
            var Hayvans = databaseContext.SahiplendirilmisHayvans.ToList();
            return View(Hayvans);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add(AddHayvanViewModel model) 
        {
            var Hayvan = new Hayvan()
            {
                Id = Guid.NewGuid(),
                İsim = model.İsim,
                Tür = model.Tür,
                Cins = model.Cins,
            };

            databaseContext.Hayvans.Add(Hayvan);
            databaseContext.SaveChanges();

            return RedirectToAction("Add");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(Guid id) 
        { 
            var Hayvan = databaseContext.Hayvans.FirstOrDefault(x =>  x.Id == id);
            var viewmodel = new EditHayvanViewModel()
            {
                Id = Hayvan.Id,
                İsim = Hayvan.İsim,
                Tür = Hayvan.Tür,
                Cins = Hayvan.Cins,
            };
            return View(viewmodel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(EditHayvanViewModel model)
        {
            var Hayvan = databaseContext.Hayvans.Find(model.Id);
            Hayvan.İsim = model.İsim;
            Hayvan.Tür = model.Tür;
            Hayvan.Cins = model.Cins;
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(EditHayvanViewModel model) 
        {
            var Hayvan = databaseContext.Hayvans.Find(model.Id);
            databaseContext.Hayvans.Remove(Hayvan);
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Sahiplen(Guid id)
        {
            var Hayvan = databaseContext.Hayvans.FirstOrDefault(x => x.Id == id);
            var viewmodel = new SahiplenViewModel()
            {
                Id = Hayvan.Id,
                İsim = Hayvan.İsim,
                Tür = Hayvan.Tür,
                Cins = Hayvan.Cins
            };

            var SahiplendirilmisHayvan = new SahiplendirilmisHayvan()
            {
                Id = Hayvan.Id,
                İsim = Hayvan.İsim,
                Tür = Hayvan.Tür,
                Cins = Hayvan.Cins
            };

            databaseContext.Hayvans.Remove(Hayvan);
            databaseContext.SahiplendirilmisHayvans.Add(SahiplendirilmisHayvan);
            databaseContext.SaveChanges();

            return View(viewmodel);
        }

    }
}
