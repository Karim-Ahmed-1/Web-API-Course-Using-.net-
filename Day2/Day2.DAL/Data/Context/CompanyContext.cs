using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Numerics;

namespace Day2.DAL;

public class CompanyContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Department>    Departments=> Set<Department>();
    public DbSet<Developer> Developers => Set<Developer>();
    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {

    }
}

