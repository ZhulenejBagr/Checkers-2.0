using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Checkers_2._0.Data;
using Checkers_2._0.Model;

namespace Checkers_2._0
{
    public class CreateModel : PageModel
    {
        private readonly Checkers_2._0.Data.ApplicationDbContext _db;

        public CreateModel(Checkers_2._0.Data.ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            //Game.Board = "1 0 1 0 1 0 1 0 0 1 0 1 0 1 0 1 1 0 1 0 1 0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 2 0 2 0 2 0 2 2 0 2 0 2 0 2 0 0 2 0 2 0 2 0 2";
            Game.IsTurn = true;
            Game.gameState = 0;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Game.Add(Game);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
