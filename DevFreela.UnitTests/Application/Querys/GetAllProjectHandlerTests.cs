using DevFreela.Application.Querys.Projects.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Querys
{
    public class GetAllProjectHandlerTests
    {
        [Fact]
        public async void ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do Teste 1", "Descricao De Teste 1", 2, 1, 10000),
                new Project("Nome do Teste 2", "Descricao De Teste 2", 2, 1, 20000),
                new Project("Nome do Teste 3", "Descricao De Teste 3", 2, 1, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAll("", 1, 4).Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("", 1, 4);
            var getAllProjectsHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList.Data);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr =>
            pr.GetAll(
                getAllProjectsQuery.Search,
                getAllProjectsQuery.Page,
                getAllProjectsQuery.Size)
            .Result, Times.Once);
        }
    }
}
