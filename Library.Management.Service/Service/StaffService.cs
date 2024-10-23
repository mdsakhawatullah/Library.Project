using Library.Management.Models;
using Library.Management.Repositary.InterfaceRepositary;
using Library.Management.Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepositary _StaffRepositary;
        public StaffService(IStaffRepositary StaffRepositary)
        {
            _StaffRepositary = StaffRepositary;
            
        }

        public Task AddAsync(Staff entity)
        {
            return _StaffRepositary.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _StaffRepositary.DeleteAsync(id);
        }

        public Task<IEnumerable<Staff>> GetAllAsync()
        {
            return _StaffRepositary.GetAllAsync();
        }

        public Task<Staff> GetById(int id)
        {
            var staff = _StaffRepositary.GetByIdAsync(id);
            if(staff == null)
            {
                throw new Exception($"No staff found for this {id}");
            }
            return staff;
        }

        public Task UpdateAsync(Staff entity)
        {
            return _StaffRepositary.UpdateAsync(entity);
        }
    }
}
