using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Net7Razor.Data;
using crud.Net7Razor.Models;

namespace crud.Net7Razor.Pages_Interesses
{
    public class EditModel : PageModel
    {
        private readonly crud.Net7Razor.Data.ApplicationDbContext _context;

        public EditModel(crud.Net7Razor.Data.ApplicationDbContext context)
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

            var interesses =  await _context.Interesses.FirstOrDefaultAsync(m => m.Id == id);
            if (interesses == null)
            {
                return NotFound();
            }
            Interesses = interesses;
           ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Interesses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteressesExists(Interesses.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InteressesExists(int id)
        {
            return _context.Interesses.Any(e => e.Id == id);
        }
    }
}
