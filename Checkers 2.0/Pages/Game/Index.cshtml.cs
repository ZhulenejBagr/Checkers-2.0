using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkers_2._0.Data;
using Checkers_2._0.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Checkers_2._0
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Game> Game { get; set; }
        public IList<Piece[,]> Board { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Game = await _db.Game.ToListAsync();
            return Page();
        }
    }
}