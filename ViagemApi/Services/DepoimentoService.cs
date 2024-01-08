using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViagemApi.Contracts;
using ViagemApi.Data;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;
using ViagemApi.ViewModels;

namespace ViagemApi.Services;

public class DepoimentoService : IDepoimentoService
{
    private readonly ApiContext _context;
    private readonly IMapper _mapper;

    public DepoimentoService(ApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task Share(ViewCreateDepoimento depoimento)
    {
        string path = Path.Combine("Storage", depoimento.Foto.FileName);

        using Stream file = new FileStream(path, FileMode.Create);

        depoimento.Foto.CopyTo(file);

        _context.Depoimentos.Add(new Depoimento(depoimento.Name, depoimento.Depoimento, path));
        await _context.SaveChangesAsync();

    }


    public async Task Delete(int id)
    {
        var depoimentoDb = _context.Depoimentos.FirstOrDefault(d => d.id == id);

        if (depoimentoDb != null)
        {
            _context.Depoimentos.Remove(depoimentoDb);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<IEnumerable<DepoimentoDto>> GetAll(int skip = 0, int take = 10)
    {
        var listDepoimentosDb = await _context.Depoimentos.Skip(skip).Take(take).ToListAsync();

        var listDepoimentosDto = _mapper.Map<List<DepoimentoDto>>(listDepoimentosDb);

        return listDepoimentosDto;


    }


    public async Task<DepoimentoDto> GetById(int id)
    {
        var depoimentoDb = await _context.Depoimentos.FirstOrDefaultAsync(d => d.id == id);

        if (depoimentoDb == null)
        {
            throw new ApplicationException("Not Found");
        }
        var depoimentoDto = _mapper.Map<DepoimentoDto>(depoimentoDb);

        return depoimentoDto;
    }

    public async Task<IEnumerable<DepoimentoDto>> LastThree()
    {
        var listDepoimentosDb = await _context.Depoimentos.ToListAsync();
        if (!listDepoimentosDb.Any())
        {
            throw new ApplicationException("The list is empty");
        }

        var lastThree = listDepoimentosDb.Skip(listDepoimentosDb.Count - 3).Take(3);
        return _mapper.Map<List<DepoimentoDto>>(lastThree);

    }
}
