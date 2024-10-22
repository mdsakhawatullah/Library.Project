using Library.Management.Models;
using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.Repositary
{
    public class StudentRepositary : IStudentRepositary
    {
        private readonly LibraryMDbContext _context;
        public StudentRepositary(LibraryMDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student entity)
        {
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FindAsync(id);
            if(entity !=null)
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);  
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
