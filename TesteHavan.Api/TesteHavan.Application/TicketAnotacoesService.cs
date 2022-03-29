using AutoMapper;
using System;
using System.Threading.Tasks;
using TesteHavan.Application.Contracts;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Application
{
    public class TicketAnotacoesService : ITicketAnotacoesService
    {
        private readonly ITicketAnotacoesRepo _ticketAnotacoesRepo;
        private readonly IMapper _mapper;

        public TicketAnotacoesService(IMapper mapper, ITicketAnotacoesRepo ticketAnotacoesRepo)
        {
            _mapper = mapper;
            _ticketAnotacoesRepo = ticketAnotacoesRepo;
        }

        public async Task<TicketAnotDto> AnotaInfoTicket(TicketAnotDto ticketAnotDto)
        {
            try
            {
                var novoTicketAnotacao = _mapper.Map<TicketAnotacao>(ticketAnotDto);
                var novoTciketAnot = await _ticketAnotacoesRepo.SalvaAnotacoesAsync(novoTicketAnotacao);
                if (novoTciketAnot == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<TicketAnotDto>(novoTciketAnot);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
