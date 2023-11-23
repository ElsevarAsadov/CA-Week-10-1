using FileUploadExample.Data;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadExample.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;
    public SliderController(AppDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Show()
    {
        return View();
    }
    
}