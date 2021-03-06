﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkers_2._0.Data;
using Checkers_2._0.Model;

namespace Checkers_2._0
{
    public class EditModel : PageModel
    {
        private readonly Checkers_2._0.Data.ApplicationDbContext _db;

        public EditModel(Checkers_2._0.Data.ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Game Game { get; set; }
        [TempData]
        public string buttonval { get; set; }
        public Board Board { get; set; }
        public string Data { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _db.Game.FirstOrDefaultAsync(m => m.Id == id);
            Board = new Board(Game.Board);
            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostCheck(string buttonval)
        {
            var xy = Array.ConvertAll(buttonval.Split(' '), int.Parse).ToList();
            int x = xy[0];
            int y = xy[1];
            Board = new Board(Game.Board);
            if (Board.PossibleMoves(x, y))
            {
                Game.IsTurn = !Game.IsTurn;
            }

            var GameFromDb = await _db.Game.FirstOrDefaultAsync(s => s.Id == Game.Id);
            GameFromDb.Board = Board.SaveBoard(Board.Storage);

            await _db.SaveChangesAsync();
            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var GameFromDb = await _db.Game.FirstOrDefaultAsync(g => g.Id == Game.Id );

            return RedirectToPage("./Index");
        }

        private bool GameExists(int id)
        {
            return _db.Game.Any(e => e.Id == id);
        }
    }
}
