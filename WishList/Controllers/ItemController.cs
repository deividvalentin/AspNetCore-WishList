using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() {
            var model = _context.Itens.ToList();

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View("Create");
        }

        public IActionResult Create([FromBody] Item item) {
            _context.Itens.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var item = _context.Itens.FirstOrDefault(e => e.Id == id);
            _context.Itens.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}