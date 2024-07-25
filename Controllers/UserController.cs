using System.Text;
using Microsoft.AspNetCore.Mvc;
using RemoveDuplicateItems.Models;

namespace RemoveDuplicateItems.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(UserViewModel model)
    {
        var uniqueItems = new HashSet<int>
        {
            1, 1, 3, 3, 4, 4
        };
        //model.Cars = model.Cars.Distinct().ToList();
        return Json(model.Cars);
    }

    // Index 2
    public IActionResult Index2()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index2(User2ViewModel model)
    {
        //model.Cars = model.Cars.DistinctBy(x => new { x.Name, x.Color }).ToList();
        return Json(model.Cars);
    }
}
