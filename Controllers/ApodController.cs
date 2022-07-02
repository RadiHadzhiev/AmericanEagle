using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asteroids.Models;
using Asteroids.Services;
using System.Globalization;

namespace Asteroids.Controllers;
public class ApodController : Controller
{
    private readonly IDataService dataService;

    public ApodController(IDataService dataService)
    {
        this.dataService = dataService;
    }
    public async Task<IActionResult> Index()
    {
        Apod apod = await this.dataService.GetImageOfTheDay();

        return View(apod);
    }

}