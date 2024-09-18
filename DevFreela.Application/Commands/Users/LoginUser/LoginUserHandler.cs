using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Users.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHashEncrypt = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPassword(request.Email, passwordHashEncrypt);

            if (user is null)
            {
                return ResultViewModel<LoginUserViewModel>.Error("Usuario não existe.");
            }

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = request.ToViewModel(token);

            return ResultViewModel<LoginUserViewModel>.Success(loginUserViewModel);
        }
    }
}
