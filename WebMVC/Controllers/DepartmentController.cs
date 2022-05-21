using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using CORE_LAYER.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentService _departmentService;

        //public DepartmentController(IDepartmentService departmentService)
        //{
        //    _departmentService = departmentService;
        //}
        private readonly DepartmentAPI _departmentAPI;

        public DepartmentController(DepartmentAPI departmentAPI)
        {
            _departmentAPI = departmentAPI;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _departmentAPI.List());
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _departmentAPI.DepartmentDetail(id));//düzeltilecek -->departmanın personelleri görünecek şekilde 
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {

            return View(await _departmentAPI.Add(departmentDto));
        }
        public async Task<IActionResult> Update(int id)
        {
            return View(await _departmentAPI.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            await _departmentAPI.Update(departmentDto);
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentAPI.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
