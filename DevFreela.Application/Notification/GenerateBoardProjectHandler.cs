using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Notification
{
    public class GenerateBoardProjectHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            // Exemplo de Handler para notificação de criação board de projeto, podendo ser implementada de inúmeras formas
            Console.WriteLine($"Board criado para projeto: {notification.Title}");
                
            return Task.CompletedTask;
        }
    }
}
