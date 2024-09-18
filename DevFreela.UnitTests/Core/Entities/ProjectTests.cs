using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome de Teste", "Descricao Teste", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title.Trim());

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description.Trim());

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
