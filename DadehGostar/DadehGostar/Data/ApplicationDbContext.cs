
using DadehGostar.Models;
using Microsoft.EntityFrameworkCore;

namespace DadehGostar.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ContactMessage> ContactMessages { get; set; }
}
