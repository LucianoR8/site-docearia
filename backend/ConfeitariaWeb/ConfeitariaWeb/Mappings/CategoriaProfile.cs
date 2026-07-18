using AutoMapper;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.DTOs;

namespace ConfeitariaWeb.Mappings
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponseDto>();
            CreateMap<CategoriaCreateDto, Categoria>();
            CreateMap<CategoriaUpdateDto, Categoria>();
        }
    }
}