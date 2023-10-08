using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Hairsalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hairsalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairsalonContext _db;

    public StylistsController(HairsalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylists> model = _db.Stylist
                            .Include(stylist => stylist.client)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Client, "ClientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      if (stylist.ClientId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Stylist.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist thisstylist = _db.stylist
                          .Include(stylist => stylist.Client)
                          .FirstOrDefault(stylist => stylist.stylistsId == id);
      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistsId == id);
      ViewBag.ClientId = new SelectList(_db.Client, "ClientId", "Name");
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Stylist.Update(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylist.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}