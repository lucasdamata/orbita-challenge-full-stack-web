using backend.Data.Dtos;
using backend.Models;
using backend.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Store(CreateStudentDTO studentDto)
        {
            Student student = _studentService.Create(studentDto);
            return CreatedAtAction(nameof(Show), new { Id = student.Id }, student);
        }

        [HttpGet]
        public IEnumerable<Student> Index()
        {
            return _studentService.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            Student student = _studentService.FindById(id);
            return student != null ? Ok(student) : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDTO studentDTO)
        {
            Result student = _studentService.Update(id, studentDTO);
            return student.IsFailed ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result student = _studentService.Delete(id);
            return student.IsFailed ? NotFound() : NoContent();
        }
    }
}
