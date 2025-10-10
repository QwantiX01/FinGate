using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}