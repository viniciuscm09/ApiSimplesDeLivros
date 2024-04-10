using ApiSimples.Dto.Autor;
using ApiSimples.Model;
using ApiSimples.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSimples.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autor;
        public AutorController(IAutorInterface autorInterface) {

            _autor = autorInterface;
        }

        [HttpGet("ListarAutores")]

     
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autor.ListarAutores(); 
            return Ok(autores);


        }

        [HttpGet("BuscarAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autor.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorAutorLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idAutor)
        {
            var autor = await _autor.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpPost("CriarUmAutor/{autorDtocs}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutores(AutorDtocs autorDtocs)
        {
            var autor = await _autor.CriarAutores( autorDtocs);
            return Ok(autorDtocs);
        }

        [HttpDelete("ExcluirUmAutor/{autorDtocs}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int idAutor)
        {
            var autor = await _autor.ExcluirAutor(idAutor);
            return Ok(idAutor);
        }

        [HttpPut("EditarUmAutor/{autorDtocs}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto)
        {
            var autor = await _autor.EditarAutor(autorEditarDto);
            return Ok(autorEditarDto);
        }
    }
}

            
        

   

