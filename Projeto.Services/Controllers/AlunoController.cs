using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Repositories.Persistence;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")] //URL: /api/aluno/cadastrar
        public HttpResponseMessage Cadastrar(AlunoCadastroViewModel model)
        {
            //verificando as validações
            if(ModelState.IsValid)
            {
                try
                {
                    Aluno a = new Aluno(); //entidade..
                    a.Nome = model.Nome;
                    a.Email = model.Email;
                    a.DataNascimento = model.DataNascimento;

                    AlunoRepository rep = new AlunoRepository();
                    rep.Insert(a); //gravando no banco de dados..

                    //retornar um status de sucesso.. HTTP 200
                    return Request.CreateResponse(HttpStatusCode.OK, 
                        "Aluno cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    //retornar um status de erro.. HTTP 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, 
                        "Erro de servidor: " + e.Message);
                }
            }
            else
            {
                //retornar um status de sucesso.. HTTP 400
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                    "Ocorreram erros de validação nos campos enviados.");
            }
        }

        [HttpPut]
        [Route("atualizar")] //URL: /api/aluno/atualizar
        public HttpResponseMessage Atualizar(AlunoEdicaoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Aluno a = new Aluno();
                    a.IdAluno = model.IdAluno;
                    a.Nome = model.Nome;
                    a.Email = model.Email;
                    a.DataNascimento = model.DataNascimento;

                    AlunoRepository rep = new AlunoRepository();
                    rep.Update(a); //atualizando..

                    return Request.CreateResponse(HttpStatusCode.OK, 
                        "Aluno atualizado com sucesso.");
                }
                catch(Exception e)
                {
                    //retornando um status de erro (HTTP 500 - Internal Server Error)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //retornando um status de erro (HTTP 400 - BadRequest)
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                    "Ocorreram erros de validação nos campos enviados.");
            }
        }

        [HttpDelete]
        [Route("excluir")] //URL: /api/aluno/exclusao
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                //buscar o aluno no banco de dados pelo id..
                AlunoRepository rep = new AlunoRepository();
                Aluno a = rep.FindById(id);

                //verificar se o aluno foi encontrado..
                if(a != null)
                {
                    rep.Delete(a); //excluindo o aluno..

                    return Request.CreateResponse(HttpStatusCode.OK, 
                        "Aluno excluido com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Aluno não foi encontrado.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")] //URL: /api/aluno/consultar
        public HttpResponseMessage Consultar()
        {
            try
            {
                List<AlunoConsultaViewModel> lista = new List<AlunoConsultaViewModel>();

                AlunoRepository rep = new AlunoRepository();
                foreach(Aluno a in rep.FindAll())
                {
                    AlunoConsultaViewModel model = new AlunoConsultaViewModel();
                    model.IdAluno = a.IdAluno;
                    model.Nome = a.Nome;
                    model.Email = a.Email;
                    model.DataNascimento = a.DataNascimento;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")] //URL: /api/aluno/consultarporid
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {
                AlunoRepository rep = new AlunoRepository();
                Aluno a = rep.FindById(id);

                if(a != null)
                {
                    AlunoConsultaViewModel model = new AlunoConsultaViewModel();
                    model.IdAluno = a.IdAluno;
                    model.Nome = a.Nome;
                    model.Email = a.Email;
                    model.DataNascimento = a.DataNascimento;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Aluno não foi encontrado.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
