

using Impar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Impar.Infra.EF;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; } = default!;
    public DbSet<Photo> Photos { get; set; } = default!;
}
