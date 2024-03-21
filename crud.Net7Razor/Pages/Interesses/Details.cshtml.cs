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
    public class DetailsModel : PageModel
    {
        private readonly crud.Net7Razor.Data.ApplicationDbContext _context;

        public DetailsModel(crud.Net7Razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
