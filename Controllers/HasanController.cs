using Microsoft.AspNetCore.Mvc;
using MVCNewProject.Data; // Replace with your namespace
using MVCNewProject.Models; // Replace with your namespace
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewProject.Controllers
{
    public class HasanController : Controller
    {
        private readonly AppDbContext _context;

        // Inject the DbContext into the controller
        public HasanController(AppDbContext context)
        {
            _context = context;
        }

        // GET action to display the list of items
        public IActionResult Hasan()
        {
            var items = _context.Items.ToList(); // Fetch all items from the database
            return View(items); // Pass the items to the Hasan view
        }

        // GET action to show the form for inserting a new item
        public IActionResult InsertItem()
        {
            return View(); // Return the InsertItem view
        }

        // POST action to handle form submission and insert data into the database
        [HttpPost]
        public async Task<IActionResult> InsertItem(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item); // Add the new item to the database
                await _context.SaveChangesAsync(); // Save changes
                return RedirectToAction("Hasan"); // Redirect to the Hasan action
            }

            return View(item); // If the model is invalid, return the InsertItem view with validation messages
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Hasan");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Item updatedItem)
        {
            if (id != updatedItem.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Hasan");
                }
                catch (Exception)
                {
                    return View(updatedItem);
                }
            }
            return View(updatedItem);
        }
    }
}
