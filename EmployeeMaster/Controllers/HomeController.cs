using EmployeeMaster.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeMaster.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBContext dBContext;
        public HomeController()
        {
            dBContext = new EmployeeDBContext();
        }
        public ActionResult Index()
        {
            var data = (from emp in dBContext.EmployeeMaster.ToList()
                        from deg in dBContext.DesignationMaster.Where(x => x.DesignationId == emp.Designationid).ToList()
                        select new MultiData()
                        {
                            employeeMasters = emp,
                            designationMasters = deg
                        }).ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            CreateViewModel obj = new CreateViewModel();
            obj.DesignationMaster = dBContext.DesignationMaster.ToList();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            EmployeeMaster.Models.EmployeeMaster employee = new EmployeeMaster.Models.EmployeeMaster();
            if (model != null && model.EmployeeName != null)
            {
                employee.EmployeeName = model.EmployeeName;
                employee.EmployeeNo = model.EmployeeNo;
                employee.Email = model.Email;
                employee.Mobile = model.Mobile;
                employee.Address = model.Address;
                employee.Designationid = model.DesignationId;
                var isInserted = dBContext.EmployeeMaster.Add(employee);
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Plz enter input";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var employee = dBContext.EmployeeMaster.Where(x => x.EmployeeId == id).FirstOrDefault();
            CreateViewModel obj = new CreateViewModel();
            obj.EmployeeId = employee.EmployeeId;
            obj.EmployeeName = employee.EmployeeName;
            obj.EmployeeNo = employee.EmployeeNo;
            obj.Email = employee.Email;
            obj.Mobile = employee.Mobile;
            obj.Address = employee.Address;
            obj.DesignationId = employee.Designationid;
            obj.DesignationMaster = dBContext.DesignationMaster.ToList();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(CreateViewModel employee)
        {
            EmployeeMaster.Models.EmployeeMaster empMaster =dBContext.EmployeeMaster.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();           
            if (empMaster != null&&empMaster.EmployeeId!=0)
            {
                empMaster.EmployeeName = employee.EmployeeName;
                empMaster.EmployeeNo = employee.EmployeeNo;
                empMaster.Email = employee.Email;
                empMaster.Mobile = employee.Mobile;
                empMaster.Address = employee.Address;
                empMaster.Designationid = employee.DesignationId;
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

        }
        public ActionResult Details(int id)
        {
            var employee = dBContext.EmployeeMaster.Where(x => x.EmployeeId == id).FirstOrDefault();
            CreateViewModel model = new CreateViewModel();
            model.EmployeeId = employee.EmployeeId;
            model.EmployeeNo = employee.EmployeeNo;
            model.EmployeeName = employee.EmployeeName;
            model.Email = employee.Email;
            model.Mobile = employee.Mobile;
            model.Address = employee.Address;
            model.DesignationId = employee.Designationid;
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var employee = dBContext.EmployeeMaster.Where(x => x.EmployeeId == id).FirstOrDefault();
            CreateViewModel model = new CreateViewModel();
            model.EmployeeId = employee.EmployeeId;
            model.EmployeeNo = employee.EmployeeNo;
            model.EmployeeName = employee.EmployeeName;
            model.Email = employee.Email;
            model.Mobile = employee.Mobile;
            model.Address = employee.Address;
            model.DesignationId = employee.Designationid;
            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            EmployeeMaster.Models.EmployeeMaster model = dBContext.EmployeeMaster.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (model != null)
            {
                dBContext.EmployeeMaster.Remove(model);
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

    }
}