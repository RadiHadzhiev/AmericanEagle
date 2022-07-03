using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asteroids.Models;
using Asteroids.Services;
using System.Globalization;
using Newtonsoft.Json;

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

        try
        {
            Neo viewModel = await this.dataService.GetDataInRange(startDate, endDate);
            if (viewModel == null)
            {
                return RedirectToAction("Error");
            }

            return View(viewModel);
        }
        catch (ApplicationException e)
        {
            return RedirectToAction("Error", new { message = e.Message });
        }


    }

    public void Export(string fileName)
    {


    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string message)
    {
        ErrorViewModel error = JsonConvert.DeserializeObject<ErrorViewModel>(message);

        return View(error);
    }
}
