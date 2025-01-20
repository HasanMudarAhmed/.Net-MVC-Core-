using Microsoft.AspNetCore.Mvc;
using MVCNewProject.Models;

namespace MVCNewProject.Controllers
{

    public class ItemContriller : Controller
    {
        public IActionResult overview()
        {
            var item = new Item { Name = "keyboaed" };
            return View(item);
        }
    }

}