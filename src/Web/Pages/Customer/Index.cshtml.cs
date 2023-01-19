using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RToora.DemoRazorPages.Web.Pages.Customer;

public class IndexModel : PageModel
{
    private readonly DemoDbContext _context;

    public IndexModel(DemoDbContext context)
    {
        _context = context;
    }

    public IList<Models.Customer>? Customers { get; set; }

    public async Task OnGetAsync()
    {
        Customers = await _context.Customer.ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var contact = await _context.Customer.FindAsync(id);

        if(contact != null)
        {
            _context.Customer.Remove(contact);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    private void GenerateSampleData()
    {
        Customers = new List<Models.Customer>()
        {
            new Models.Customer{ Id= 1, Name = "Customer 1" },
            new Models.Customer{ Id= 2, Name = "Customer 2" },
            new Models.Customer{ Id= 3, Name = "Customer 3" },
            new Models.Customer{ Id= 4, Name = "Customer 4" },
            new Models.Customer{ Id= 5, Name = "Customer 5" }
        };
    }
}
