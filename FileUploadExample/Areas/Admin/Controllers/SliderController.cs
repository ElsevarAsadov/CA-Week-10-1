using FileUploadExample.Areas.Admin.Models;
using FileUploadExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;

namespace FileUploadExample.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;



    static string GenerateFilenameWithGuid(string filename, int maxLength)
    {
        string extension = System.IO.Path.GetExtension(filename);

        int availableSpace = maxLength - (extension.Length + 1);

        string newGuid = Guid.NewGuid().ToString();

        if (filename.Length + newGuid.Length + 1 > maxLength)
        {
            filename = filename.Substring(0, availableSpace);
        }

        string newFilename = $"{filename}-{newGuid}{extension}";

        return newFilename;
    }
    public SliderController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Show()
    {
        return View(_context.Slider.ToList());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveFile(SliderModel model)
    {

        if (ModelState.IsValid)
        {

            if (!new string[] { "image/jpeg", "image/png" }.Contains(model.Image.ContentType))
            {
                ModelState.AddModelError("Image", "Unsupported file format");
                return View("Create");
            }

            string fileName = GenerateFilenameWithGuid(model.Image.FileName, 300);


            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }



            string imagePath = Path.Combine(folder, fileName);
            using (FileStream fs = new FileStream(imagePath, FileMode.Create))
            {
                model.Image.CopyTo(fs);
            }

            model.ImagePath = imagePath;


            _context.Slider.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Show");
        }
        return View("Create");
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (id == null) return View("Show");

        SliderModel? model = _context.Slider.FirstOrDefault(x => x.Id == id);

        if (model == null) return View("Show");

        return View(model);
    }


    [HttpPost]
    public IActionResult UpdateFile(SliderModel? model)
    {
        if (model == null)
        {
            return NotFound();
        }


        if (ModelState.IsValid)
        {

            SliderModel? old = _context.Slider.FirstOrDefault(x => x.Id == model.Id);




            old.TextUpper = model.TextUpper;
            old.TextButton = model.TextButton;
            old.TextBelow = model.TextBelow;

            if (!new string[] { "image/jpeg", "image/png" }.Contains(model.Image.ContentType))
            {
                ModelState.AddModelError("Image", "Unsupported file format");
                return View("Create");
            }

            string fileName = GenerateFilenameWithGuid(model.Image.FileName, 300);


            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");




            string imagePath = Path.Combine(folder, fileName);


            FileInfo oldFile = new FileInfo(old.ImagePath);

            oldFile.Delete();



            using (FileStream fs = new FileStream(imagePath, FileMode.Create))
            {
                model.Image.CopyTo(fs);
            }

            old.ImagePath = imagePath;


            _context.Slider.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Show");
        }
        return View("Update");

     
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return RedirectToAction("Create");
        }

        SliderModel? model = _context.Slider.FirstOrDefault(x => x.Id == id);

        if(model == null)
        {
            return RedirectToAction("Create");
        }

        FileInfo file = new FileInfo(model.ImagePath);
        file.Delete();
        _context.Slider.Remove(model);
        _context.SaveChanges();
        return RedirectToAction("Show");
    }

}