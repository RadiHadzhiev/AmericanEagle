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
    public async Task<IActionResult> Index(Apod picture)
    {
        string date = null;

        if (picture == null)
        {
            date = DateTime.Today.ToString("yyy-MM-dd");
        }
        else
        {
            date = picture.Date;
        }

        try
        {

            Apod apod = await this.dataService.GetImageOfTheDay(date);
            return View(apod);
        }
        catch (ApplicationException e)
        {
            return RedirectToAction("Error", "Home", new { message = e.Message });
        }


    }
    public void DownloadImage(Apod apod)
    {
        System.Net.WebClient webClient = new System.Net.WebClient();
        string url = apod.Hdurl;
        byte[] bytes = webClient.DownloadData(url);
        string fileName = ( url.Split('/')[url.Split('/').Length - 1] );
        Response.ContentType = "image/png";
        Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);
        Response.Body.WriteAsync(bytes, 0, bytes.Length);
    }

}