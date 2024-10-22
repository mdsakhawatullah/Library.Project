using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.InterfaceService
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllAsync();

        Task<Member> GetById(int id);

        Task AddAsync(Member entity);

        Task UpdateAsync(Member entity);

        Task DeleteAsync(int id);
    }
}
