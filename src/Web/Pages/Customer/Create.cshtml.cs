using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RToora.DemoRazorPages.Web.Pages.Customer;

public class CreateModel : PageModel
{
    private readonly DemoDbContext _context;

    public CreateModel(DemoDbContext context)
    {
        _context= context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Models.Customer? Customer { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if(Customer != null)
        {
            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
