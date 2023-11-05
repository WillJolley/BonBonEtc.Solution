using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonBonEtc.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace BonBonEtc.Controllers
{
  public class HomeController : Controller
  {
    private readonly BonBonEtcContext _db;
    
    public HomeController(BonBonEtcContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Flavor[] flavs = _db.Flavors.ToArray();
      Treat[] treats = _db.Treats.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string,object[]>();
      model.Add("flavors", flavs);
      model.Add("treats", treats);
      return View(model);
    }
  }
}