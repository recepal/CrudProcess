using AutoMapper;
using CrudProcess.Model;

namespace CrudProcess.Service
{
    public class CrudProfile : Profile
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                SetConfigurations(cfg);
            });

            return config.CreateMapper();
        }

        private static void SetConfigurations(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
