using Microsoft.AspNetCore.Mvc;
using BonBonEtc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BonBonEtc.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly BonBonEtcContext _db;

    public FlavorsController(BonBonEtcContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    public ActionResult Details(int id)
    {
      Flavor thisFlav = _db.Flavors
          .Include(flav => flav.JoinEntities)
          .ThenInclude(join => join.Treat)
          .FirstOrDefault(flav => flav.FlavorId == id);
      return View(thisFlav);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flav)
    {
      _db.Flavors.Add(flav);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      Flavor thisFlav = _db.Flavors.FirstOrDefault(flavs => flavs.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlav);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flav, int treatId)
    {
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flav.FlavorId));
      #nullable disable
      if (joinEntity == null && treatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flav.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flav.FlavorId });
    }

    public ActionResult Edit(int id)
    {
      Flavor thisFlav = _db.Flavors.FirstOrDefault(flavs => flavs.FlavorId == id);
      return View(thisFlav);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flav)
    {
      _db.Flavors.Update(flav);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Flavor thisFlav = _db.Flavors.FirstOrDefault(flavs => flavs.FlavorId == id);
      return View(thisFlav);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor thisFlav = _db.Flavors.FirstOrDefault(flavs => flavs.FlavorId == id);
      _db.Flavors.Remove(thisFlav);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}