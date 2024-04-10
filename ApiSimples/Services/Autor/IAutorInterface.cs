using ApiSimples.Dto.Autor;
using ApiSimples.Model;

namespace ApiSimples.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> ListarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int idLivro);

        Task<ResponseModel<AutorModel>>BuscarAutorPorId(int idAutor);

        Task<ResponseModel<List<AutorModel>>> CriarAutores(AutorDtocs autorDtocs);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto);


    }
}