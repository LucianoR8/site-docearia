using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;
using AutoMapper;

namespace ConfeitariaWeb.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaResponseDto>> ObterTodasAsync()
        {
            var categorias = await _categoriaRepository.ObterTodasAsync();

            return _mapper.Map<List<CategoriaResponseDto>>(categorias);
        }

        public async Task<CategoriaResponseDto> AdicionarAsync(CategoriaCreateDto dto)
        {

            ArgumentNullException.ThrowIfNull(dto);
            
            var nomeCategoria = await ValidarNomeCategoriaAsync(dto.NomeCategoria);

            var categoria = new Categoria
            {
                NomeCategoria = nomeCategoria
            };

            await _categoriaRepository.AdicionarAsync(categoria);
            await _categoriaRepository.SalvarAlteracoesAsync();

            return _mapper.Map<CategoriaResponseDto>(categoria);
        }

        
        public async Task<CategoriaResponseDto?> ObterPorIdAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if(categoria == null)
            {
                return null;
            }

            return _mapper.Map<CategoriaResponseDto>(categoria);
        }

        
        public async Task<CategoriaResponseDto> AtualizarAsync(int id, CategoriaUpdateDto dto)
        {
            if(dto == null) 
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if(categoria == null)
            {
                throw new KeyNotFoundException("categoria não encontrada.");
            }

            var nomeCategoria = await ValidarNomeCategoriaAsync(dto.NomeCategoria, id);

            categoria.NomeCategoria = nomeCategoria;
            categoria.AtualizadoEm = DateTime.UtcNow;

            
            _categoriaRepository.Atualizar(categoria);
            await _categoriaRepository.SalvarAlteracoesAsync();

            return _mapper.Map<CategoriaResponseDto>(categoria);
        }

        private async Task<string> ValidarNomeCategoriaAsync(string nomeCategoria, int? ignorarId = null)
        {
            if (string.IsNullOrWhiteSpace(nomeCategoria))
            {
                throw new ArgumentException("O nome da categoria é obrigatório.");
            }

            nomeCategoria = nomeCategoria.Trim();

            if (nomeCategoria.Length > 100)
            {
                throw new ArgumentException("O nome da categoria deve possuir menos de 100 caracteres.");
            }

            if (await _categoriaRepository.ExistePorNomeAsync(nomeCategoria, ignorarId))
            {
                throw new ArgumentException("O nome dessa categoria já existe.", nameof(nomeCategoria));
            }

            return nomeCategoria;
        }

        
        public async Task RemoverAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if(categoria == null)
            {
                throw new KeyNotFoundException("Categoria não encontrada.");
            }

            if(await _categoriaRepository.PossuiProdutosAsync(categoria.IdCategoria))
            {
                throw new ArgumentException("Essa categoria ainda possui produtos vinculados.");
            }

            _categoriaRepository.Remover(categoria);

            await _categoriaRepository.SalvarAlteracoesAsync();
        }
        


    }
}