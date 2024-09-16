using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserHandler(IUserRepository repository, IAuthService authService)
        {
            _userRepository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não existe.");
            }

            HashPassword(request);

            user.Update(request.FullName, request.Email, request.BirthDate, request.Password, request.Role);
            await _userRepository.Update(user);

            return ResultViewModel.Success();
        }

        private void HashPassword(UpdateUserCommand request)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            request.SetHashingInPassord(passwordHash);
        }
    }
}
