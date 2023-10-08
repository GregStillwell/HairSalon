using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Hairsalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hairsalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairsalonContext _db;

    public ClientController(HairsalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List< Client> model = _db. Client.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create( Client  Client)
    {
      _db. Client.Add( Client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client this Client = _db. Client
                                  .Include( Client => client.stylist)
                                  .FirstOrDefault(client => client.clientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisclient = _db.client.FirstOrDefault(client => client.clientId == id);
      return View(thisclient);
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