using WebPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebPortal.Controllers;

public class EventController : Controller
{
    private readonly PortalDbContext _context;

    public EventController(PortalDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var etkinlikler = await _context.Events.ToListAsync();
        return View(etkinlikler);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await KategorileriDoldurAsync();
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var etkinlik = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

        if (etkinlik == null)
        {
            return NotFound();
        }

        return View(etkinlik);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var etkinlik = await _context.Events.FindAsync(id);

        if (etkinlik == null)
        {
            return NotFound();
        }

        await KategorileriDoldurAsync();
        return View(etkinlik);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var etkinlik = await _context.Events.FindAsync(id);
        if (etkinlik == null)
        {
            return NotFound();
        }
        return View(etkinlik);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var etkinlik = await _context.Events.FindAsync(id);
        if (etkinlik == null)
        {
            return NotFound();
        }
        _context.Events.Remove(etkinlik);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = $"\"{etkinlik.Title}\" etkinliği başarıyla silindi.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Event gunceletkinlik)
    {
        if (!ModelState.IsValid)
        {
            await KategorileriDoldurAsync();
            return View(gunceletkinlik);
        }
        var mevcut = await _context.Events.FindAsync(gunceletkinlik.Id);
        if (mevcut == null)
        {
            return NotFound();
        }
        mevcut.Title = gunceletkinlik.Title;
        mevcut.Description = gunceletkinlik.Description;
        mevcut.Capacity = gunceletkinlik.Capacity;
        mevcut.CategoryId = gunceletkinlik.CategoryId;
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"\"{mevcut.Title}\" etkinliği başarıyla güncellendi.!";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Event yeniEtkinlik)
    {
        if (!ModelState.IsValid)
        {
            await KategorileriDoldurAsync();
            return View(yeniEtkinlik);
        }

        _context.Events.Add(yeniEtkinlik);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"\"{yeniEtkinlik.Title}\" etkinliği başarıyla oluşturuldu.!";
        return RedirectToAction("Index");
    }

    private async Task KategorileriDoldurAsync()
    {
        var kategoriler = await _context.Categories
            .OrderBy(k => k.Name)
            .ToListAsync();
        ViewBag.Kategoriler = new SelectList(kategoriler, "Id", "Name");
    }
}