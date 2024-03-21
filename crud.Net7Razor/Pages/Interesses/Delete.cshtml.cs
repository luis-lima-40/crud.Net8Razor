using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud.Net7Razor.Data;
using crud.Net7Razor.Models;

namespace crud.Net7Razor.Pages_Interesses
{
    public class DeleteModel : PageModel
    {
        private readonly crud.Net7Razor.Data.ApplicationDbContext _context;

        public DeleteModel(crud.Net7Razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Interesses Interesses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interesses = await _context.Interesses.FirstOrDefaultAsync(m => m.Id == id);

            if (interesses == null)
            {
                return NotFound();
            }
            else
            {
                Interesses = interesses;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interesses = await _context.Interesses.FindAsync(id);
            if (interesses != null)
            {
                Interesses = interesses;
                _context.Interesses.Remove(Interesses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
