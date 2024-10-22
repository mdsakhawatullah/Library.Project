using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.InterfaceService
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllAsync();

        Task<Staff> GetById(int id);

        Task AddAsync(Staff entity);

        Task UpdateAsync(Staff entity);

        Task DeleteAsync(int id);
    }
}
