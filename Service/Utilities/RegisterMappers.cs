using AutoMapper;
using DataBase.Entitys;
using Models;

namespace Service
{
    public class RegisterMappers : Profile
    {
        public RegisterMappers()
        {
            RegisterDBModels();
        }

        private void RegisterDBModels()
        {
            CreateMap<Log, LogDto>().ReverseMap();
        }
    }
}
