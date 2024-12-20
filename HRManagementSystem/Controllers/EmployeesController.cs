﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;

namespace HRManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetById(id);

            if (employee == null)
                return NotFound($"Employee with ID: {id} not found");

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await unitOfWork.Employees.FindAll(["Department"]);

            if (employees.Count() == 0)
                return NotFound("No employees found!");

            IEnumerable<EmployeeRegisterDTO> employeesDto = new List<EmployeeRegisterDTO>();

            employeesDto = employees.Adapt(employeesDto);

            return Ok(employeesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeRegisterDTO dto)
        {
            var employee = dto.Adapt<Employee>();

            await unitOfWork.Employees.Add(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeRegisterDTO dto)
        {
            Employee employee = await unitOfWork.Employees.GetById(id);

            if (employee is null)
                return NotFound($"There is no employee with ID: {id}");

            if (dto is null)
                return BadRequest("Please enter the data to be modified.");

            employee = dto.Adapt(employee);

            unitOfWork.Employees.Update(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var employee = await unitOfWork.Employees.GetById(id);

            if (employee is null)
                return NotFound($"The employee doesn't exist!!!");

            unitOfWork.Employees.Delete(employee);

            unitOfWork.Complete();

            return Ok(employee);
        }
    }
}
