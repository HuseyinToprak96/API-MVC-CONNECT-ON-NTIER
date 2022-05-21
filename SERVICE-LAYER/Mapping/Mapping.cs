using AutoMapper;
using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE_LAYER.Mapping
{
  public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
           // CreateMap<List<Employee>, List<EmployeeDto>>();
            CreateMap<Employee,EmployeeDepartmentDto>()
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.department.Name)); 
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailDto>();
            CreateMap<Department, EmployeeDetailDto>();
            CreateMap<Department, DepartmentwithEmployeeDto>()
                .ForMember(x=>x.employeeDtos,opt=>opt.MapFrom(x=>x.employees.ToList()))
                .ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.Name));
          //  CreateMap<List<EmployeeDto>, DepartmentwithEmployeeDto>();
        }
    }
}
