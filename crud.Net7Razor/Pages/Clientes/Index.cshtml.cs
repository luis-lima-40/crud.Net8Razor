using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud.Net7Razor.Data;
using crud.Net7Razor.Models;

namespace crud.Net7Razor.Pages_Clientes
{
    public class IndexModel : PageModel
    {
        private readonly crud.Net7Razor.Data.ApplicationDbContext _context;

        public IndexModel(crud.Net7Razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes.ToListAsync();
        }
    }
}
