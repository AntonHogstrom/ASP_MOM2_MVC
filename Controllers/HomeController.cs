using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_MOM2.Models;

namespace ASP_MOM2.Controllers;

public class HomeController : Controller
{

    //function for getting last time page viewed
    public void LastViewed()
    {
        //Gets last value of Visited
        ViewBag.Visited = HttpContext.Session.GetString("Visited");

        //Sets new value of Visited that will be displayed next time
        DateTime dateTime = DateTime.Now;
        string dateString = dateTime.ToString();
        HttpContext.Session.SetString("Visited", dateString);
    }

    //index page
    public IActionResult Index()
    {
        LastViewed();

        return View();
    }

    //Error page
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

