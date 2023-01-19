namespace RToora.DemoRazorPages.Web.Context;

public class DemoDbContext : DbContext
{
	public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
	{

	}

	public DbSet<Customer> Customer => Set<Customer>();
}