using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HampusKunskapsKoll.Models;

namespace KunskapskollMVCLabb.Controllers
{
    public class AdressBokController : Controller
    {
        static List<AdressBook_M> adressBok = new List<AdressBook_M>();
        public ActionResult Index()
        {
            AdressBook_M newAdressBok = new AdressBook_M();
            return View(newAdressBok);
        }
        [HttpPost]
        public ActionResult Create(AdressBook_M adressbok)
        {
            adressbok.ID = Guid.NewGuid();
            adressbok.DateUpdate = DateTime.Now;
            adressBok.Add(adressbok);
            return PartialView("List", adressBok);
        }
        public ActionResult ListaAlla()
        {
            return PartialView("List", adressBok);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var delete = adressBok.First(x => x.ID == id);
            adressBok.Remove(delete);
            return PartialView("List", adressBok);
        }
        public ActionResult Edit(AdressBook_M adressbok)
        {
            var edit = adressBok.Find(x => x.ID == adressbok.ID);
            return PartialView("Edit", edit);
        }
        [HttpPost]
        public ActionResult Edit(AdressBook_M adressbok, FormCollection formcollection)
        {
            var edit = adressBok.Find(x => x.ID == adressbok.ID);
            edit.Name = adressbok.Name;
            edit.Adress = adressbok.Adress;
            edit.PhoneNumber = adressbok.PhoneNumber;
            return PartialView("List", adressBok);
        }
    }
}