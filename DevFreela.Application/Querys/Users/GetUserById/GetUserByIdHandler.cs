using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.Users.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não existe.");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
