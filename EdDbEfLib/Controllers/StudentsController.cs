using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EdDbEfLib.Models;

using Microsoft.EntityFrameworkCore;

namespace EdDbEfLib.Controllers {
    
    public class StudentsController {

        private readonly EdDbContext _context = null;

        public async Task<List<Student>> GetByMajor(string description) {
            var students = await _context.Student
                 .Where(s => s.Major.Description.StartsWith(description)).ToListAsync();
            return students;
        }
        public async Task<IEnumerable<Student>> GetAll() {
            return await _context.Student.ToListAsync();
        }

        public async Task<Student> GetByPk(int id) {
            return await _context.Student.FindAsync(id);
        }

        public async Task<Student> Insert(Student student) {
            if(student == null) throw new Exception("Student is null");
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Update(int id, Student student) {
            if(student == null) throw new Exception("Student is null");
            if(id != student.Id) throw new Exception("Student id mismatch");
            _context.Entry(student).State = EntityState.Detached;
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student) {
            if(student == null) throw new Exception("Student is null");
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id) {
            var student = await GetByPk(id);
            await Delete(student);
        }

        public StudentsController() { _context = new EdDbContext(); }
    }
}
