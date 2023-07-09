using AtheneumApp.Blazor.Server.UI.Services.Base;
using AutoMapper;

namespace AtheneumApp.Blazor.Server.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadDto, AuthorUpdateDto>().ReverseMap();
        }
    }
}
