using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public InsertUserHandler(IUserRepository repository, IAuthService authService)
        {
            _userRepository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            HashPassword(request);

            var user = request.ToEntity();

            await _userRepository.Add(user);

            return ResultViewModel<int>.Success(user.Id);
        }

        private void HashPassword(InsertUserCommand request)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            request.SetHashingInPassord(passwordHash);
        }
    }
}