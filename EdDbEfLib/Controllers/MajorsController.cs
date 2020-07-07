using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using EdDbEfLib.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EdDbEfLib.Controllers {
    
    public class MajorsController {

        private readonly EdDbContext _context = null;

        public async Task<List<Major>> GetAll() {
            return await _context.Major.ToListAsync();
        }

        public async Task<Major> GetByPk(int id) {
            return await _context.Major.FindAsync(id);
        }

        public async Task<bool> Insert(Major major) {
            if(major == null) {
                throw new Exception("Major input cannot be null");
            }
            await _context.Major.AddAsync(major);   
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Major major) {
            if(major == null) {
                throw new Exception("Major input cannot be null");
            }
            if(id != major.Id) {
                throw new Exception("Id does not match Major.Id");
            }
            //_context.Entry(major).State = EntityState.Modified;
            _context.Update(major);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Major major) {
            if(major == null) {
                throw new Exception("Major input cannot be null");
            }
            _context.Remove(major);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id) {
            var major = GetByPk(id);
            if(major == null) {
                throw new Exception("Major id not found!");
            }
            await Delete(major.Result);
            return true;
        }

        public MajorsController() {
            _context = new EdDbContext();
        }
    }
}
