using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadExample.Areas.Admin.Models;

public class SliderModel
{
    public int Id { get; set; }
    [Required]
    public string TextUpper { get; set; }
    [Required]
    public string TextBelow { get; set; }
    [Required]
    public string TextButton { get; set; }
  
    [StringLength(maximumLength:200)]
    public string? ImagePath { get; set; }

    [NotMapped]
    [Required]
    public IFormFile Image { get; set; }
    
}