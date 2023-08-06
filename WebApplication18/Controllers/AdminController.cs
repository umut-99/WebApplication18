using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication18.Entities;

namespace WebApplication18.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public AdminController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            List<User> users = databaseContext.Users.ToList();

            return View(users);
        }

        public IActionResult Delete(Guid id) 
        {
            var user = databaseContext.Users.FirstOrDefault(x => x.Id == id);
            databaseContext.Users.Remove(user);
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
