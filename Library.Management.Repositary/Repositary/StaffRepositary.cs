using Library.Management.Models;
using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.Repositary
{
    public class StaffRepositary: IStaffRepositary
    {
        private readonly LibraryMDbContext _context;
        public StaffRepositary(LibraryMDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staffs.ToListAsync();
        }
        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.StaffId==id);
        }
        public async Task AddAsync(Staff entity)
        {
            _context.Staffs.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Staff entity)
        {
            _context.Staffs.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Staffs.FindAsync(id);
            if (entity != null)
            {
                _context.Staffs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        

            

    }
}
