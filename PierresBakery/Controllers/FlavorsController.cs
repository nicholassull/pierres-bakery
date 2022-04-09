using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresBakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresBakery.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresBakeryContext _db;
    
    public FlavorsController(PierresBakeryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.OrderBy(flavor => flavor.Name).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      bool isDuplicate = _db.Flavors.Any(anyFlavor => anyFlavor.Name == flavor.Name);
      if (!isDuplicate)
      {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
      .Include(flavor => flavor.JoinEntities)
      .ThenInclude(join => join.Treat)
      .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    public ActionResult Delete (int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
      
    }
    [HttpPost,ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}