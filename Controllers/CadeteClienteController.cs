using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria;

[ApiController]
[Route("api/[controller]")]
public class CadeteClienteController : ControllerBase
{
    private readonly DataContext _db;
    private readonly ICadeteClienteRepository _CC;
    private readonly ILogger<CadeteClienteController> _logger;

    public CadeteClienteController(ILogger<CadeteClienteController> logger, ICadeteClienteRepository cc, DataContext db)
    {
        _db = db;
        _CC = cc;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get(Guid id)
    {
        try
        {
            var Response = _db.Clientes.Join(_db.CadCliente, client => client.Id_cliente, Cp => Cp.ClienteForeingKey,
             (client, Cp) => new { Cp.Id_cadClient, client.Id_cliente, client.Nombre, }).Join(_db.Cadetes, res => res.Id_cadClient, cad => cad.Id_cadete,
             (res, cad) => new { res.Id_cadClient, res.Id_cliente, res.Nombre, cad.Id_cadete, cad.NombreCad });
            return Ok(Response);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }
    [HttpGet("{id}")]
    [Route("action")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var Response = _db.Clientes.Join(_db.CadCliente, client => client.Id_cliente, Cp => Cp.ClienteForeingKey,
             (client, Cp) => new { Cp.Id_cadClient, client.Id_cliente, client.Nombre, }).Join(_db.Cadetes, res => res.Id_cadClient, cad => cad.Id_cadete,
             (res, cad) => new { res.Id_cadClient, res.Id_cliente, res.Nombre, cad.Id_cadete, cad.NombreCad }).Where(x => x.Id_cadClient == id);
            return Ok(Response);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] CadeteCliente cc)
    {

        try
        {
            _CC.Save(cc);
            return Ok();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("error: \n" + e.ToString());
            throw;
        }
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id_pedido, [FromBody] Pedido pedido)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok();
    }

}
