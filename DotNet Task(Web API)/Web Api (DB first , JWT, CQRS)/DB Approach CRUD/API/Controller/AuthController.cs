using Application.Features.Auth.Commands.LoginCommand;
using Application.Features.Auth.Commands.RegisterCommand;
using DB_Approach_CRUD.API.Constants;
using DB_Approach_CRUD.API.Filters;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DB_Approach_CRUD.API.Controller
{
    [ApiController]
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost(ApiRoutes.User.Register)]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var user = await sender.Send(command);
                if (user == null)
                    return BadRequest(new { message = "User already exists or details are invalid." });

                return Ok(user);
            }
            catch (ValidationException ex) 
            {
                return BadRequest(ex.Errors.Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage }));
            }
        }

        [HttpPost(ApiRoutes.User.Login)]
        public async Task<ActionResult> Login([FromBody] LoginUserCommand qry)
        {
            var token = await sender.Send(qry);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new
                {
                    StatusCode = 401,
                    message = "Unauthorized: Invalid username or password."
                });
            }
            return Ok(new { Token = token });
        }
    }
}
