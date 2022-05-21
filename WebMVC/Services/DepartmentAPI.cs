using CORE_LAYER.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebMVC.Services
{
    public class DepartmentAPI
    {
        private readonly HttpClient _httpClient;
        public DepartmentAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DepartmentDto>> List()
        {
            var response= await _httpClient.GetFromJsonAsync<CustomResponseDto<List<DepartmentDto>>>("Department/List");
            return response.Data;
        }
        public async Task<DepartmentDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<DepartmentDto>>($"Department/Find?id={id}");
            return response.Data;
        }
        public async Task<DepartmentwithEmployeeDto> DepartmentDetail(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<DepartmentwithEmployeeDto>>($"Department/DepartmentDetail?id={id}");
            return response.Data;
            
        }

        public async Task<DepartmentDto> Add(DepartmentDto departmentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Department/Add", departmentDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<DepartmentDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Department/Delete?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(DepartmentDto departmentDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Department/Update", departmentDto);
            return response.IsSuccessStatusCode;
        }
    }
}
