using CORE_LAYER.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeAPI _employeeAPI;
        private readonly DepartmentAPI _departmentAPI;

        public EmployeeController(EmployeeAPI employeeAPI, DepartmentAPI departmentAPI)
        {
            _employeeAPI = employeeAPI;
            _departmentAPI = departmentAPI;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _employeeAPI.List());
        }
        public async Task<IActionResult> Create()
        {
            TempData["Departments"] = await _departmentAPI.List();//or selectList
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            await _employeeAPI.Add(employeeDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _employeeAPI.Find(id));
        }
        public async Task<IActionResult> Update(int id)
        {
            return View(await _employeeAPI.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            await _employeeAPI.Update(employeeDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeAPI.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
