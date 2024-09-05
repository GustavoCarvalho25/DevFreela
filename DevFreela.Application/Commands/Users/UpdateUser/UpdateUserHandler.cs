using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não existe.");
            }

            user.Update(request.FullName, request.Email, request.BirthDate);
            await _userRepository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
