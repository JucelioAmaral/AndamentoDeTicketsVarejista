using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Contracts;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Application
{
    public class ViewBDService : IViewBDService
    {
        private readonly IViewRepo _viewRepo;
        private readonly IMapper _mapper;

        public ViewBDService(IMapper mapper, IViewRepo viewRepo)
        {
            _mapper = mapper;
            _viewRepo = viewRepo;
        }

        public async Task<ClsView> GetValoresViewBD(int codigoDoTicket, string nomeDoUsuario, string cpf)
        {
            try
            {
                ViewDto dados = new ViewDto
                {
                    CodigoDoTicket = codigoDoTicket,
                    NomeDoUsuario = nomeDoUsuario,
                    CPF = cpf                    
                };

                var dadosDaConsulta = _mapper.Map<ClsView>(dados);
                var view = await _viewRepo.GetViewAsync(dadosDaConsulta);
                if (view == null)
                {
                    return null;
                }
                else
                {
                    return view;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
