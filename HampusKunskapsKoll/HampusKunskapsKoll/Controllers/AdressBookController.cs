using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HampusKunskapsKoll.Models;


namespace HampusKunskapsKoll.Controllers
{
    public class AdressBookController : Controller
    {
        static List<AdressBook> adressBok = new List<AdressBook>();
        public ActionResult Index()
        {
            AdressBook newAdressBok = new AdressBook();
            return View(newAdressBok);
        }
        [HttpPost]
        public ActionResult Create(AdressBook adressbok)
        {
            adressbok.Id = Guid.NewGuid();
            adressbok.DateUpdate = DateTime.Now;
            adressBok.Add(adressbok);
            return PartialView("List", adressBok);
        }
        public ActionResult ListAll()
        {
            return PartialView("List", adressBok);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var delete = adressBok.First(x => x.Id == id);
            adressBok.Remove(delete);
            return PartialView("List", adressBok);
        }
        public ActionResult Edit(AdressBook adressbok)
        {
            var edit = adressBok.Find(x => x.Id == adressbok.Id);
            return PartialView("Edit", edit);
        }
        [HttpPost]
        public ActionResult Edit(AdressBook adressbok, FormCollection formcollection)
        {
            var edit = adressBok.Find(x => x.Id == adressbok.Id);
            edit.Name = adressbok.Name;
            edit.Adress = adressbok.Adress;
            edit.PhoneNumber = adressbok.PhoneNumber;
            return PartialView("List", adressBok);
        }
    }
}