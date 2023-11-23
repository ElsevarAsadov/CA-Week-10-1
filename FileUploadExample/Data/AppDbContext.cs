using FileUploadExample.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUploadExample.Data;

public class AppDbContext : DbContext
{
    public DbSet<SliderModel> Slider { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}