using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using MyAPI.ViewModel;
using System.Globalization;

[ApiController]
[Route("api/vendas")]
public class ConsolaVendasController : ControllerBase
{
    private readonly MyDbContext _context;

    public ConsolaVendasController(MyDbContext context)
    {
        _context = context;
    }

    // Esta função lida com vendas específicas de consolas
    public async Task<ActionResult<List<ConsolaVendaDTO>>> ObterVendasPorConsola<T>(DateTime inicio, DateTime fim) where T : JogosAbstract
    {
        var vendas = await _context.Set<T>()
            .Where(j => j.AnoLancamento >= inicio.Year && j.AnoLancamento <= fim.Year)
            .GroupBy(j => j.Consola)
            .Select(grupo => new ConsolaVendaDTO
            {
                Consola = grupo.Key,
                TotalVendas = grupo.Sum(j => j.Vendas)
            }).ToListAsync();

        // Formatar TotalVendas para duas casas decimais
        foreach (var venda in vendas)
        {
            venda.TotalVendasFormatted = venda.TotalVendas.ToString("F2", CultureInfo.InvariantCulture);
        }

        return Ok(vendas);
    }

    // Métodos específicos para Nintendo DS
    [HttpGet("nintendods/periodo")]
    public async Task<ActionResult<List<ConsolaVendaDTO>>> GetVendasNintendoDS(DateTime inicio, DateTime fim)
    {
        return await ObterVendasPorConsola<NintendoDS>(inicio, fim);
    }

    // Métodos específicos para Nintendo Wii
    [HttpGet("nintendowii/periodo")]
    public async Task<ActionResult<List<ConsolaVendaDTO>>> GetVendasNintendoWii(DateTime inicio, DateTime fim)
    {
        return await ObterVendasPorConsola<NintendoWii>(inicio, fim);
    }

    [HttpGet("playstation3/periodo")]
    public async Task<ActionResult<List<ConsolaVendaDTO>>> GetVendasNintendoPlay3(DateTime inicio, DateTime fim)
    {
        return await ObterVendasPorConsola<Playstation3>(inicio, fim);
    }

    // Métodos específicos para Nintendo Wii
    [HttpGet("sonypsp/periodo")]
    public async Task<ActionResult<List<ConsolaVendaDTO>>> GetVendasPSP(DateTime inicio, DateTime fim)
    {
        return await ObterVendasPorConsola<SonyPSP>(inicio, fim);
    }

    // Métodos específicos para Nintendo Wii
    [HttpGet("xbox360/periodo")]
    public async Task<ActionResult<List<ConsolaVendaDTO>>> GetVendasXbox360(DateTime inicio, DateTime fim)
    {
        return await ObterVendasPorConsola<Xbox360>(inicio, fim);
    }
}