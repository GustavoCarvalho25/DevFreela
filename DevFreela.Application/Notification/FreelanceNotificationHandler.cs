using MediatR;

namespace DevFreela.Application.Notification
{
    public class FreelanceNotificationHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Projeto criado: {notification.Title} - {notification.TotalCost}");

            return Task.CompletedTask;
        }
    }
}
