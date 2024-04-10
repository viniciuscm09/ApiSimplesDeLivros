using ApiSimples.Dto.Autor;
using ApiSimples.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiSimples.Services.Autor
{
    public class AutorServices : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autor => autor.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem= ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutores(AutorDtocs autorDtocs)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Name = autorDtocs.Name,
                    Sobrenome = autorDtocs.Sobrenome,


                };
                _context.Add(autor);
                await _context.SaveChangesAsync();   
                resposta.Dados = await _context.Autor.ToListAsync();
                return resposta;
                

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(Autorbanco => Autorbanco.Id == autorEditarDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                autor.Name =autorEditarDto.Name;
                autor.Sobrenome = autorEditarDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor editado com Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                return resposta;


            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores() 
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            { 
                var autores = await _context.Autor.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todas os autores foram coletados!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem= ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public Task<ResponseModel<AutorModel>> ListarAutorPorId(int idAutor)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var Livros = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(Livros => Livros.Id == idLivro);
                if (Livros == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                resposta.Dados = Livros.Autor;
                resposta.Mensagem = "Livros Localizado!";
                return resposta;



            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
