using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asteroids.Models;
using Asteroids.Services;
using System.Globalization;

namespace Asteroids.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataService dataService;

    public HomeController(ILogger<HomeController> logger, IDataService dataService)
    {
        _logger = logger;
        this.dataService = dataService;
    }

    public async Task<IActionResult> Index(IFormCollection dateForm)
    {
        string dateFormat = "yyy-MM-dd";

        DateTime startDate = Convert.ToDateTime(dateForm["startDate"], CultureInfo.InvariantCulture);
        DateTime endDate = Convert.ToDateTime(dateForm["endDate"], CultureInfo.InvariantCulture);

        Neo viewModel = await this.dataService.GetDataInRange(startDate, endDate);

        if (viewModel == null)
        {
            return RedirectToAction("Error");
        }

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Export(string TableData)
    {
        return File(System.Text.Encoding.ASCII.GetBytes(TableData), "application/vnd.ms-excel", "asteroids.xls");
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
