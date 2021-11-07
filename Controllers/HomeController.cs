using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lesson3.Models;
using Lesson3.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MvcProductContext _context;

    public HomeController(ILogger<HomeController> logger, MvcProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int FilterCat = -1)
    {
        ViewBag.cats = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        if (FilterCat == -1)
        {
            return View(await _context.Products.ToListAsync());
        }
        var list = _context.Products.Where(x => x.CategoryId == FilterCat);
        return View(list);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.cats = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var category = await _context.Categories.FindAsync(product.CategoryId);
        product.Category = category;
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        ViewBag.cats = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
        var product = await _context.Products.FindAsync(id);
        return View(product);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
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
