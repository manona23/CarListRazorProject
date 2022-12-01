using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarListRazor.Pages.CarList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {

            _db = db;
        }
        public IEnumerable<Car> Cars { get; set; }
        public async Task OnGet()
        {
            Cars = await _db.Car.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var car = await _db.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            _db.Car.Remove(car);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
