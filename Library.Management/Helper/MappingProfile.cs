using AutoMapper;
using Library.Management.Models;
using Library.Management.Models.BusinessModels;

namespace Library.Management.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberVM>();
            CreateMap<MemberVM, Member>();
        }
        

    }
}
