using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarListRazor.Pages.CarList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car Car { get; set; }


        public async Task OnGet(int id)
        {
            Car = await _db.Car.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Car.FindAsync(Car.ID);
                BookFromDb.Name = Car.Name;
                BookFromDb.Model = Car.Model;
                BookFromDb.Color = Car.Color;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
