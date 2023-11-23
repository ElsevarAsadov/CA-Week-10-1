using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadExample.Areas.Admin.Models;

public class Slider
{
    public int Id { get; set; }
    public string TextUpper { get; set; }
    public string TextBelow { get; set; }
    public string TextButton { get; set; }
    public string? ImagePath { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; }
    
}