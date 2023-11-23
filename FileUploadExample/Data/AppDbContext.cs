using Microsoft.EntityFrameworkCore;

namespace FileUploadExample.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}