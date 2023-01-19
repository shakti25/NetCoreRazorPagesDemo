using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RToora.DemoRazorPages.Web.Pages.Customer;

public class EditModel : PageModel
{
    private readonly DemoDbContext _context;

    public EditModel(DemoDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Models.Customer? Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Customer = await _context.Customer.FirstOrDefaultAsync(c => c.Id == id);

        if (Customer == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Customer != null)
        {
            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CustomerExists(Customer.Id))
                {
                    return NotFound();
                }else
                {
                    // TODO: replace with logging
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CustomerExists(int id) => _context.Customer.Any(c => c.Id == id);

}