using AutoMapper;
using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using CORE_LAYER.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
         var employees= await _employeeService.gelAllAsync();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);
            return CreateActionResult(CustomResponseDto<List<EmployeeDto>>.success(200, dtos));
        }
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            return CreateActionResult(CustomResponseDto<Employee>.success(200, await _employeeService.getByIdAsync(id)));
        }
        [HttpGet]
        public async Task<IActionResult> ListDetail()
        {
            return CreateActionResult(await _employeeService.EmployeesWithDepartment());
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return CreateActionResult(CustomResponseDto<Employee>.success(200, await _employeeService.AddAsync(employee)));
        }
        [HttpPost]
        public async Task<IActionResult> AddRange(IEnumerable<EmployeeDto> employeeDtos)
        {
            var employees = _mapper.Map<List<Employee>>(employeeDtos);
            return CreateActionResult(CustomResponseDto<IEnumerable<Employee>>.success(200, await _employeeService.AddRange(employees)));
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeService.Update(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.getByIdAsync(id);
            await _employeeService.Remove(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
