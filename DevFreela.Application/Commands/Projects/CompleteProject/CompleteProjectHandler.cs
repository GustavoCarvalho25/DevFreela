using DevFreela.Application.Models;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPaymentService _paymentService;

        public CompleteProjectHandler(IProjectRepository projectRepository, IPaymentService paymentService)
        {
            _projectRepository = projectRepository;
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetById(request.Id);

            if (project is null)
            {
                return false;
            }

            project.Complete();

            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, project.TotalCost);

            var result = await _paymentService.ProcessPayment(paymentInfoDto);

            if(!result)
            {
                project.SetPaymentPendent();
            }

            await _projectRepository.Update(project);

            return true;
        }
    }
}
