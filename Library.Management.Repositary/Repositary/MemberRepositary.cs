using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Management.Models;
using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Microsoft.EntityFrameworkCore;

namespace Library.Management.Repositary.Repositary
{
    public class MemberRepositary : IMemberRepositary
    {
        private readonly LibraryMDbContext _context;
        public MemberRepositary(LibraryMDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<Member> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }
        public async Task AddAsync(Member entity)
        {
             _context.Members.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Member entity)
        {
            _context.Members.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Members.FindAsync(id);
            if(entity !=null)
            {
                _context.Members.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
