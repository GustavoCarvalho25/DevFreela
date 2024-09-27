using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class InsertProjectHandlerTests
    {   
        private readonly IMediator _mediator;
        public InsertProjectHandlerTests(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var insertProjectCommand = new InsertProjectCommand
            (
                title: "Titulo Teste",
                description: "Descrição Teste",
                idClient: 1,
                idFreelancer: 2,
                totalCost: 50000
            );

            var insertProjectHandler = new InsertProjectHandler(projectRepository.Object, _mediator);

            // Act
            var id = await insertProjectHandler.Handle(insertProjectCommand, new CancellationToken());

            // Assert
            Assert.NotNull(id);
            Assert.True(id.Data >= 0);

            projectRepository.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
