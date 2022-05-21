using CORE_LAYER.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebMVC.Services
{
    public class EmployeeAPI
    {
        private readonly HttpClient _httpClient;

        public EmployeeAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<EmployeeDepartmentDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<EmployeeDepartmentDto>>>("Employee/ListDetail");
            return response.Data;
        }
        public async Task<EmployeeDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<EmployeeDto>>($"Employee/Find?id={id}");
            return response.Data;
        }
        public async Task<EmployeeDto> Add(EmployeeDto employeeDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Employee/Add", employeeDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<EmployeeDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Employee/Delete?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(EmployeeDto employeeDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Employee/Update",employeeDto);
            return response.IsSuccessStatusCode;
        }
    }
}
