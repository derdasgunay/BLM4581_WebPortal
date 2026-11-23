using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;
using Microsoft.EntityFrameworkCore;
using WebPortal.Data;

namespace WebPortal.Controllers;

public class HomeController : Controller
{
    private readonly PortalDbContext _context;

    public HomeController(PortalDbContext context)
    {
        _context = context;
    }    

    public async Task<IActionResult> Index()
    {
        ViewBag.Kategoriler = await _context.Categories
            .OrderBy(k => k.Name)
            .ToListAsync();

        var etkinlikler = await _context.Events
            .Include(e => e.Category)
            .Include(e => e.Registrations)
            .Where(e => e.Date >= DateTime.Now)
            .OrderBy(e => e.Date)
            .Take(3)
            .ToListAsync();

        return View(etkinlikler);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
