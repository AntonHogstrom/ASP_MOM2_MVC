using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_MOM2.Models;
using Newtonsoft.Json;

namespace ASP_MOM2.Controllers;

public class GamesController : Controller
{
    //function for getting last time page viewed
    public void LastViewed() {
        //Gets last value of Visited
        ViewBag.Visited = HttpContext.Session.GetString("Visited");

        //Sets new value of Visited that will be displayed next time
        DateTime dateTime = DateTime.Now;
        string dateString = dateTime.ToString();
        HttpContext.Session.SetString("Visited", dateString);
    }

    //Index page
    public IActionResult Index()
    {
        //Puts JSON-file as string variable
        var jsonString = System.IO.File.ReadAllText("games.json");
        //Converts string JSON to objects in list
        var jsonObject = JsonConvert.DeserializeObject<List<GameModel>>(jsonString);

        LastViewed();

        //returns View Model as object from JSON
        return View(jsonObject);
    }

    //Create Game page
    public IActionResult Add_Game()
    {
        LastViewed();

        return View();
    }

    //Post game
    [HttpPost]
    public IActionResult Add_Game(GameModel model)
    {
        if(ModelState.IsValid)
        {
            var jsonString = System.IO.File.ReadAllText("games.json");
            var jsonObject = JsonConvert.DeserializeObject<List<GameModel>>(jsonString);

            if(jsonObject != null)
            {
                if (model.Trailer != null) {
                    model.Trailer = model.Trailer.Replace("watch?v=", "embed/");
                    string[] embedLink = model.Trailer.Split('&');
                    model.Trailer = embedLink[0];
                }

                jsonObject.Add(model);
            }

            System.IO.File.WriteAllText("games.json", JsonConvert.SerializeObject(jsonObject, Formatting.Indented));
            ModelState.Clear();
        }
        return View();
    }

    //Error page
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

