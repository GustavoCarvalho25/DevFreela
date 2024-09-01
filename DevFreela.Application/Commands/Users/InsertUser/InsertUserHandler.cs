using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _repository;

        public InsertUserHandler(IMediator mediator, IUserRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            await _repository.Add(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
