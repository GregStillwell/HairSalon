using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db. Client.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db. Client.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Client
                                  .Include(client => client.Stylist)
                                  .FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Client.Update(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      _db.Client.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}