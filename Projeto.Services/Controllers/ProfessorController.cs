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
    [RoutePrefix("api/professor")]
    public class ProfessorController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")] //URL: /api/professor/cadastrar
        public HttpResponseMessage Cadastrar(ProfessorCadastroViewModel model)
        {
            //verificando as validações
            if (ModelState.IsValid)
            {
                try
                {
                    Professor p = new Professor(); //entidade..
                    p.Nome = model.Nome;
                    p.Cpf = model.Cpf;

                    ProfessorRepository rep = new ProfessorRepository();
                    rep.Insert(p); //gravando no banco de dados..

                    //retornar um status de sucesso.. HTTP 200
                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Professor cadastrado com sucesso.");
                }
                catch (Exception e)
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
        [Route("atualizar")] //URL: /api/professor/atualizar
        public HttpResponseMessage Atualizar(ProfessorEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Professor p = new Professor();
                    p.IdProfessor = model.IdProfessor;
                    p.Nome = model.Nome;

                    ProfessorRepository rep = new ProfessorRepository();
                    rep.Update(p); //atualizando..

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Professor atualizado com sucesso.");
                }
                catch (Exception e)
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
        [Route("excluir")] //URL: /api/professor/exclusao
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                //buscar o professor no banco de dados pelo id..
                ProfessorRepository rep = new ProfessorRepository();
                Professor p = rep.FindById(id);

                //verificar se o professor foi encontrado..
                if (p != null)
                {
                    rep.Delete(p); //excluindo o aluno..

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Professor excluido com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Professor não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")] //URL: /api/professor/consultar
        public HttpResponseMessage Consultar()
        {
            try
            {
                List<ProfessorConsultaViewModel> lista = new List<ProfessorConsultaViewModel>();

                ProfessorRepository rep = new ProfessorRepository();
                foreach (Professor p in rep.FindAll())
                {
                    ProfessorConsultaViewModel model = new ProfessorConsultaViewModel();
                    model.IdProfessor = p.IdProfessor;
                    model.Nome = p.Nome;
                    model.Cpf = p.Cpf;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")] //URL: /api/professor/consultarporid
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {
                ProfessorRepository rep = new ProfessorRepository();
                Professor p = rep.FindById(id);

                if (p != null)
                {
                    ProfessorConsultaViewModel model = new ProfessorConsultaViewModel();
                    model.IdProfessor = p.IdProfessor;
                    model.Nome = p.Nome;
                    model.Cpf = p.Cpf;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Professor não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
