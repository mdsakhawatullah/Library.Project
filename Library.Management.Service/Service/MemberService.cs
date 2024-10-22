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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepositary _MemberRepositary;
        public MemberService(IMemberRepositary MemberRepositary)
        {
            _MemberRepositary = MemberRepositary;
            
        }

        public Task AddAsync(Member entity)
        {
            return _MemberRepositary.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _MemberRepositary.DeleteAsync(id);
        }

        public Task<IEnumerable<Member>> GetAllAsync()
        {
            return _MemberRepositary.GetAllAsync();
        }

        public Task<Member> GetById(int id)
        {
            return _MemberRepositary.GetByIdAsync(id);
        }

        public Task UpdateAsync(Member entity)
        {
            return _MemberRepositary.UpdateAsync(entity);
        }
    }
}
