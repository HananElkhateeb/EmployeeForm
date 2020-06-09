using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeForm.DAL;
using EmployeeForm.Model;
using EmployeeForm.Service;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        ISkillService _skillService;
        public EmployeeController(IEmployeeService employeeService, ISkillService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
        }
        private CompanyContext db = new CompanyContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(_employeeService.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeService.GetEmployeeById(id.Value);
            foreach(EmployeeSkill employeeSkill in db.EmployeeSkills){
                if(employeeSkill.EmployeeID == employee.Id)
                {
                    Skill s = new Skill();
                    s.SkillName = employeeSkill.SkillName;
                    employee.EmpSkills.Add(s);
                }
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.skillList = new MultiSelectList(_skillService.GetAll(), "Id", "SkillName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Create(employee);
                string[] empSkills = employee.SelectedSkills;
                if (employee.SelectedSkills != null)
                {
                    foreach (string skill in empSkills)
                    {
                        EmployeeSkill employeeSkill = new EmployeeSkill();
                        employeeSkill.SkillID = Int16.Parse(skill);
                        employeeSkill.SkillName = _skillService.GetSkillById(Int16.Parse(skill)).SkillName;
                        employeeSkill.EmployeeID = employee.Id;
                        db.EmployeeSkills.Add(employeeSkill);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            List<string> skillsList = new List<string>();
            foreach(EmployeeSkill es in db.EmployeeSkills)
            {
                if(es.EmployeeID == employee.Id)
                {
                    skillsList.Add(es.SkillID.ToString());
                }
            }
            employee.SelectedSkills = skillsList.ToArray();
            ViewBag.skillList = new MultiSelectList(_skillService.GetAll(), "Id", "SkillName");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            string[] empSkills = employee.SelectedSkills;
            foreach(EmployeeSkill employeeSkill in db.EmployeeSkills)
            {
                if(employeeSkill.EmployeeID == employee.Id)
                {
                    db.EmployeeSkills.Remove(employeeSkill);
                }
            }

            if (employee.SelectedSkills != null)
            {
                foreach (string skill in empSkills)
                {
                    EmployeeSkill employeeSkill = new EmployeeSkill();
                    employeeSkill.SkillID = Int16.Parse(skill);
                    employeeSkill.SkillName = _skillService.GetSkillById(Int16.Parse(skill)).SkillName;
                    employeeSkill.EmployeeID = employee.Id;
                    db.EmployeeSkills.Add(employeeSkill);
                }
            }
            db.SaveChanges();

            if (ModelState.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeService.GetEmployeeById(id);
            _employeeService.Delete(employee);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
