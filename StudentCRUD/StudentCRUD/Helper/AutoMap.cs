using AutoMapper;
using StudentCRUD.Models;

namespace StudentCRUD.Helper
{
    public class AutoMap: Profile
    {
        public AutoMap()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
