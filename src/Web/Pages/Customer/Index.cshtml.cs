using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RToora.DemoRazorPages.Web.Pages.Customer;

public class IndexModel : PageModel
{
    public IList<Models.Customer>? Customers { get; set; }
    public async Task OnGetAsync()
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
