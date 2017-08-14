using System;
using Microsoft.AspNetCore.Mvc;
using StuffedAnimalCollection.Models;
using System.Collections.Generic;

namespace StuffedAnimalCollection.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/AddAnimal")]
    public ActionResult AddAnimal()
    {
      StuffedAnimal newAnimal = new StuffedAnimal(Request.Form["animal"]);
      newAnimal.Save();

      return View(StuffedAnimal.GetAll());
    }
    [HttpPost("/")]
    public ActionResult ClearAll()
    {
      StuffedAnimal.DeleteAll();

      return View("Index");
    }

  }
}
