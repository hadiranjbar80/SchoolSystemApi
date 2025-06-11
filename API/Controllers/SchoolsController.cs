using API.DTOs;
using API.Services;
using Application.Schools;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SchoolsController : BaseApiController
    {
        private readonly TokenService _tokenService;
        public SchoolsController(TokenService tokenService)
        {
            _tokenService = tokenService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            return HandleResult(await Mediator.Send(new List.Query { }));
        }

        [HttpPost]
        public async Task<ActionResult<string>> AuthenticateSchool(School schoolDto)
        {
            var school = await Mediator.Send(new Details.Query { School = schoolDto });

            if (!school.IsSuccess) return school.Error;

            if (school != null)
            {
                return _tokenService.CreateToken(schoolDto);
            }

            return Unauthorized();
        }
    }
}