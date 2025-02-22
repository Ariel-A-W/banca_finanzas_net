using banca_finanzas_net.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace banca_finanzas_net.Application.Clientes;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ICRUDUsesCases<
        ClientesResponse,
        ClientesAddRequest,
        ClientesDeleteRequest,
        ClientesUpdateRequest
    > _clientes;

    public ClientesController(
        ICRUDUsesCases<
            ClientesResponse,
            ClientesAddRequest,
            ClientesDeleteRequest,
            ClientesUpdateRequest
        > clientes)
    {
        _clientes = clientes;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ClientesResponse>> GetList()
    {
        var clientes = _clientes.GetAll();

        if (clientes == null || !clientes.Any())
            return NotFound(MessagesStatusCodes.NotFoundMessage);

        return Ok(clientes);
    }
}
