using mvc21622test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc21622test.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult AddEmployee()
        {
            TableCollection obj = new TableCollection();
            obj.lstcountry = db.tblcountries.ToList();
            obj.lstgender = db.tblgenders.ToList();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddEmployee(TableCollection TL)
        {
            tblemployee emp = new tblemployee();
            emp.name = TL.name;
            emp.email = TL.email;
            emp.password = TL.password;
            emp.gender = TL.gender;
            emp.country = TL.country;
            emp.state = TL.state;

            db.tblemployees.Add(emp);  
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Delete(int id=0)
        {
            var data = db.tblemployees.Find(id);
            db.tblemployees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Show()
        {
            var data = (from a in db.tblemployees
                        join b in db.tblgenders on a.gender equals b.gid
                        join c in db.tblcountries on a.country equals c.cid
                        join d in db.tblstates on a.state equals d.sid
                        select new tblemployee1{
               empid= a.empid,
                   name= a.name,
                   email= a.email,
                    password = a.password,
                   gname= b.gname,
                   cname= c.cname,
                       sname=d.sname } ).ToList();
            return View(data);
        }
        public JsonResult GetState(int A)
        {
            var data = (from a in db.tblstates where a.cid==A select a).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}