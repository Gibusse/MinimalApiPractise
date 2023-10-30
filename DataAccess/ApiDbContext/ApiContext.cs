using Microsoft.EntityFrameworkCore;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.DataAccess.ApiDbContext;

public class ApiContext: DbContext
{
    public ApiContext(DbContextOptions opt): base(opt)
    {
    }

    public DbSet<Note> Notes { get; set; }
}