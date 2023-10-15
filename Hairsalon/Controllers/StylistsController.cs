using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylists> model = _db.Stylists
                            .Include(stylist => stylist.Client)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Client, "ClientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylists stylist)
    {
      if (stylist.ClientId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylists thisStylist = _db.Stylists
                          .Include(stylist => stylist.Client)
                          .FirstOrDefault(stylist => stylist.StylistsId == id);
      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylists thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistsId == id);
      ViewBag.ClientId = new SelectList(_db.Client, "ClientId", "Name");
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylists stylist)
    {
      _db.Stylists.Update(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Stylists thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistsId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylists thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistsId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}