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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositary _StudentRepositary;
        public StudentService(IStudentRepositary StudentRepositary)
        {
            _StudentRepositary = StudentRepositary;
            
        }
        public Task<IEnumerable<Student>> GetAllAsync()
        {
            return _StudentRepositary.GetAllAsync();
        }
        public Task<Student> GetById(int id)
        {
            var student = _StudentRepositary.GetByIdAsync(id);
            if(student == null)
            {
                throw new Exception($"An error occured for this {id}");
            }
            return student;
        }
        public Task AddAsync(Student entity)
        {
            return _StudentRepositary.AddAsync(entity);
        }
        public Task UpdateAsync(Student entity)
        {
            return _StudentRepositary.UpdateAsync(entity);
        }
        public Task DeleteAsync(int id)
        {
            return _StudentRepositary.DeleteAsync(id);
        }

    }
}
