using System.Security.Claims;
using API.DTOs;
using Application.Interfaces;
using Application.Students;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class StudentsController : BaseApiController
    {
        private readonly IUserAccessor _userAccessor;
        public StudentsController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            student.SchoolCode = _userAccessor.GetSchoolCode();
            return HandleResult(await Mediator.Send(new Create.Command { Student = student }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var schoolCode = _userAccessor.GetSchoolCode();
            return HandleResult(await Mediator.Send(new List.Query { SchoolCode = schoolCode }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { StudentId = studentId }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            student.SchoolCode = _userAccessor.GetSchoolCode();
            return HandleResult(await Mediator.Send(new Update.Command { Student = student }));
        }
    }
}

/*
{
    "id": "1111111111",
    "schoolCode": "145",
    "firstName": "هادی",
    "lastName": "رنجبر",
    "fatherName": "",
    "parentPhoneNumber": "09334453929",
    "address": "مرودشت",
    "postalCode": "1234567890",
    "commuteService": 0
}

*/