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
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            return CreateActionResult(CustomResponseDto<Department>.success(200, await _departmentService.AddAsync(department)));
        }
        [HttpPost]
        public async Task<IActionResult> AddRange(IEnumerable<DepartmentDto> departmentDtos)
        {
            var departments = _mapper.Map<List<Department>>(departmentDtos);
            await _departmentService.AddRange(departments);
            return CreateActionResult(CustomResponseDto<List<Department>>.success(200, departments));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.Remove(await _departmentService.getByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            return CreateActionResult(CustomResponseDto<Department>.success(200,await _departmentService.getByIdAsync(id)));
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var dtos = _mapper.Map<List<DepartmentDto>>(await _departmentService.gelAllAsync());
            return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.success(200, dtos));
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentDetail(int id)
        {
            return CreateActionResult(await _departmentService.DepartmentByIdDetail(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            await _departmentService.Update(_mapper.Map<Department>(departmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
