using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.InterfaceRepositary
{
    public interface IStudentRepositary
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(int id);
    }
}
