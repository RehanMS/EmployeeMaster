using EmployeeMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMaster.Controllers
{
    public class MemberController : Controller
    {
        EmployeeDBContext dBContext;
        public MemberController()
        {
            dBContext = new EmployeeDBContext();
        }
        public ActionResult Index()
        {
            var data = (from mem in dBContext.Registrations.ToList()
                        from prt in dBContext.ParentDetailies .Where(x => x.ParentId == mem.ParentId).ToList()
                        select new MultiData()
                        {
                            registration = mem,
                            parentDetails = prt
                        }).ToList();
            return View(data);
        }

        //public ActionResult Create()
        //{
        //    RegistrationViewModel obj = new RegistrationViewModel();
        //    obj.Parent = dBContext.ParentDetailies.ToList();
        //    return View(obj);
        //}
        //[HttpPost]
        //public ActionResult Create(CreateViewModel model)
        //{
        //    EmployeeMaster.Models.EmployeeMaster employee = new EmployeeMaster.Models.EmployeeMaster();
        //    if (model != null && model.EmployeeName != null)
        //    {
        //        employee.EmployeeName = model.EmployeeName;
        //        employee.EmployeeNo = model.EmployeeNo;
        //        employee.Email = model.Email;
        //        employee.Mobile = model.Mobile;
        //        employee.Address = model.Address;
        //        employee.Designationid = model.DesignationId;
        //        var isInserted = dBContext.EmployeeMaster.Add(employee);
        //        dBContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.msg = "Plz enter input";
        //        return View();
        //    }
        //}
    }
}