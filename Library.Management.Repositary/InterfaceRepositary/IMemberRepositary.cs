using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.InterfaceRepositary
{
    public interface IMemberRepositary
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member> GetByIdAsync(int id);
        Task AddAsync(Member entity);
        Task UpdateAsync(Member entity);
        Task DeleteAsync(int id);

    }
}
