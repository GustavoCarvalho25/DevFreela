using MediatR;

namespace DevFreela.Application.Notification
{
    public class FreelanceNotificationHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            // Exemplo de Handler para notificação de criação de projeto, podendo ser implementada de inúmeras formas
            Console.WriteLine($"Projeto criado: {notification.Title} - {notification.TotalCost}");

            return Task.CompletedTask;
        }
    }
}
