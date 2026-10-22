using Backoffice.Dtos;
using Backoffice.Services;
using Microsoft.AspNetCore.Mvc;
namespace Backoffice.Dtos
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
     private readonly ICategoriaService _service;
     public CategoriaController(ICategoriaService service){
         _service=service;
     }
     [HttpGet]
     public ActionResult<IEnumerable<CategoriaDto>> Listar()
        {
            return Ok(_service.Listar());
        }
    [HttpGet("{id:int}")]
    public ActionResult<CategoriaDto> ObtenerPorId(int id)
        {
            var Categoria = _service.ObtenerPorId(id);
            return Categoria is null ? NotFound() : Ok(Categoria);
        }
    [HttpPost]
    public ActionResult<CategoriaDto> Crear(CategoriaCrearDto dto)
        {
            var nueva = _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nueva.Id }, nueva);
        }

    }
}