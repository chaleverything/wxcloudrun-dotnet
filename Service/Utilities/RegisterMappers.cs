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
            CreateMap<Categorys, CategorysDto>().ReverseMap();
            CreateMap<Comments, CommentsDto>().ReverseMap();
            CreateMap<Goods, GoodsDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<Medias, MediasDto>().ReverseMap();
            CreateMap<Skus, SkusDto>().ReverseMap();
            CreateMap<Specs, SpecsDto>().ReverseMap();
            CreateMap<SpecVals, SpecValsDto>().ReverseMap();
            CreateMap<Stores, StoresDto>().ReverseMap();
        }
    }
}
