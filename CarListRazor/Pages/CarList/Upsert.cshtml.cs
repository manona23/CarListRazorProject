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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car Car { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Car = new Car();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Car = await _db.Car.FirstOrDefaultAsync(u => u.ID == id);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Car.ID == 0)
                {
                    _db.Car.Add(Car);
                }
                else
                {
                    _db.Car.Update(Car);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}
