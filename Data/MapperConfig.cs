using AutoMapper;
using  AppGestionFranca.Models;

namespace  AppGestionFranca.Data
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Technician, TechnicianDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Subsidiary, SubsidiaryDTO>().ReverseMap();
            CreateMap<TechnicianItem, TechnicianItemDTO>().ReverseMap();
        }
    }
}
