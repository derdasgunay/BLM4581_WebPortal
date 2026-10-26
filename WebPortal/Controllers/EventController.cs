using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class EventController : Controller
{
    private static List<Event> _events = new();

    [HttpGet]
    public IActionResult Index()
    {
        return View(_events);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var etkinlik = _events.FirstOrDefault(e => e.Id == id);

        if (etkinlik == null)
        {
            return NotFound();
        }

        return View(etkinlik);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    { 
        var etkinlik = _events.FirstOrDefault(e => e.Id == id);

        if (etkinlik == null)
        {
            return NotFound();
        }

        return View(etkinlik);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var etkinlik = _events.FirstOrDefault(e => e.Id == id);
        if (etkinlik == null)
        {
            return NotFound();
        }
        return View(etkinlik);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var etkinlik = _events.FirstOrDefault(e => e.Id == id);
        if (etkinlik == null)
        {
            return NotFound();
        }
        _events.Remove(etkinlik);
        TempData["SuccessMessage"] = $"\"{etkinlik.Title}\" etkinliği başarıyla silindi.";
        return RedirectToAction("Index");
    }

    public IActionResult Edit(Event gunceletkinlik)
    {
        if (!ModelState.IsValid)
        {
            return View(gunceletkinlik);
        }
        var mevcut= _events.FirstOrDefault(e => e.Id == gunceletkinlik.Id);
        if (mevcut == null)
        {
            return NotFound();
        }
        mevcut.Title = gunceletkinlik.Title;
        mevcut.Description = gunceletkinlik.Description;
        mevcut.Capacity = gunceletkinlik.Capacity;

        TempData["SuccessMessage"] = $"\"{mevcut.Title}\" etkinliği başarıyla güncellendi.!";
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Create(Event yeniEtkinlik)
    {

        if (!ModelState.IsValid)
        {
            return View(yeniEtkinlik);
        }
        
        yeniEtkinlik.Id = _events.Count + 1;
        _events.Add(yeniEtkinlik);

        TempData["SuccessMessage"] = $"\"{yeniEtkinlik.Title}\" etkinliği başarıyla oluşturuldu.!";
        return RedirectToAction("Index");
    }
}