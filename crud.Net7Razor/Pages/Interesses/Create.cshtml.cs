using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crud.Net7Razor.Data;
using crud.Net7Razor.Models;

namespace crud.Net7Razor.Pages_Interesses
{
    public class CreateModel : PageModel
    {
        private readonly crud.Net7Razor.Data.ApplicationDbContext _context;

        public CreateModel(crud.Net7Razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Interesses Interesses { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Interesses.Add(Interesses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
