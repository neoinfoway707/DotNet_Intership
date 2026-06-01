using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.UpdateEmployee;
using DB_Approach_CRUD.API.Constants;
using DB_Approach_CRUD.API.Filters;
using DB_Approach_CRUD.Application.Features.Employees.Commands.DeleteEmployee;
using DB_Approach_CRUD.Application.Features.Employees.Queries.GetAllEmployee;
using DB_Approach_CRUD.Application.Features.Employees.Queries.GetEmployeeById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DB_Approach_CRUD.API.Controller
{
    [ApiController]
    [Authorize]
    public class EmployeeController(ISender _sender) : ControllerBase
    {

        [HttpGet(ApiRoutes.Employee.GetAll)]
        public async Task<ActionResult> GetAllEmployees()
        {
            var emp = await _sender.Send(new GetAllEmployeeQuery());
            if (emp == null)
            {
                return BadRequest("Not any Employee Found.");
            }
            return Ok(emp);
        }

        [HttpGet(ApiRoutes.Employee.GetById)]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var emp = await _sender.Send(new GetEmployeeByIdQuery { Id = id });
            if (emp == null)
            {
                return BadRequest("Given Employee Id Doesn't exists.");
            }
            return Ok(emp);
        }

        [HttpPost(ApiRoutes.Employee.CreateEmp)]
        [TypeFilter(typeof(CretaeEmployeeValidationActionFilterAttribute))]
        public async Task<ActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            try
            {
                return Ok(await _sender.Send(command));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Message = e.ErrorMessage
                }));
            }
        }
        [HttpPut(ApiRoutes.Employee.UpdateEmp)]
        [TypeFilter(typeof(ValidateIdActionFilterAttribute))]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateEmployeeCommand command)
        {
            try
            {
                command.Id = id;
                var emp = await _sender.Send(command);
                if (emp != null)
                    return Ok(emp);
                return BadRequest("Employee Not Found");
            }
            catch (ValidationException ex)
            {
                {
                    return BadRequest(ex.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    }));
                }
            }
        }

        [HttpDelete(ApiRoutes.Employee.DeleteEmp)]
        [TypeFilter(typeof(ValidateIdActionFilterAttribute))]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEmp = await _sender.Send(new DeleteEmployeeCommand { Id = id});
            if (deleteEmp == true)
                return Ok("Employee Deleted Successfully.");
            return BadRequest("Employee Id is not found.");
        }
    }
}
