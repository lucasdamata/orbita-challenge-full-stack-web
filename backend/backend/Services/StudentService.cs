using AutoMapper;
using backend.Data;
using backend.Data.Dtos;
using backend.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    public class StudentService
    {
        private StudentContext _context;
        private IMapper _mapper;

        public StudentService(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Student Create(CreateStudentDTO studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);
            _context.Students.Add(student);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data) ;
            }
            
            return _mapper.Map<Student>(student);
        }

        public IEnumerable<Student> FindAll()
        {
            return _context.Students;
        }

        public Student FindById(int id)
        {
            return _context.Students.FirstOrDefault(students => students.Id == id);
        }

        public Result Update(int id, UpdateStudentDTO studentDTO)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                return Result.Fail("Student not found");
            }
            _mapper.Map(studentDTO, student);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                return Result.Fail("Student not found");
            }
            _context.Remove(student);
            _context.SaveChanges();
            return Result.Ok();
        }
    }

    
}
