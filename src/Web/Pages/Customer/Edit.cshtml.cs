using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RToora.DemoRazorPages.Web.Pages.Customer;

public class EditModel : PageModel
{
    [BindProperty]
    public Models.Customer? Customer { get; set; }
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        Customer = new Models.Customer() { Id = id.Value, Name = $"Customer {id}" };

        if( Customer == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }

        if(Customer != null) 
        {
            
        }

        return RedirectToPage("./Index");
    }
}
