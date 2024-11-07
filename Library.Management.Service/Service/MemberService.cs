using AutoMapper;
using Library.Management.Models;
using Library.Management.Models.BusinessModels;
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
        private readonly IMapper _mapper;
        public MemberService(IMemberRepositary MemberRepositary, IMapper mapper)
        {
            _MemberRepositary = MemberRepositary;
            _mapper = mapper;
            
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

        public async Task<MemberVM> GetById(int id)
        {
            var member = await _MemberRepositary.GetByIdAsync(id);
            if(member == null)
            {
                throw new Exception($"No member found for this {id}");
            }
            return _mapper.Map<MemberVM>(member);
        }

        public Task UpdateAsync(Member entity)
        {
           
            return _MemberRepositary.UpdateAsync(entity);
        }
    }
}
