using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;

public class VendasController : Controller
{
    private readonly ApiVendasService _apiVendasService;

    public VendasController(ApiVendasService apiVendasService)
    {
        _apiVendasService = apiVendasService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string consola, string inicio, string fim)
    {
        DateTime dataInicio, dataFim;

        // Validação das datas recebidas no formato "dd/MM/yyyy"
        if (!DateTime.TryParseExact(inicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInicio) ||
            !DateTime.TryParseExact(fim, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataFim))
        {
            ViewBag.Error = "Formato de data inválido. Use o formato dd/MM/yyyy.";
            return View();
        }

        // Chamando o serviço para buscar as vendas
        var vendas = await _apiVendasService.GetVendasAsync(consola, dataInicio, dataFim);

        if (vendas == null)
        {
            ViewBag.Error = "Não foi possível obter os dados de vendas.";
            return View();
        }

        // Usando ViewBag para passar as datas de início e fim para a View
        ViewBag.DataInicio = dataInicio.ToString("dd/MM/yyyy"); 
        ViewBag.DataFim = dataFim.ToString("dd/MM/yyyy");        

        return View("Resultados", vendas);  // Passa a lista de vendas diretamente
    }
}
