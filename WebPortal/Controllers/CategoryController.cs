using WebPortal.Data;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class CategoryController : Controller
{
    private readonly PortalDbContext _context;

    public CategoryController(PortalDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories.ToListAsync();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index"); 
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Category category)
    {
        if (id != category.Id) return NotFound();
        
        if (!ModelState.IsValid) return View(category);

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // --- SİL (DELETE) ---
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }    
}