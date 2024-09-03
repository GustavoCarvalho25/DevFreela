using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _userRepository;

        public InsertUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            await _userRepository.Add(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}