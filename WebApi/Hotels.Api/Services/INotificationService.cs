namespace Hotels.Api.Services
{
    using System;
    using Microsoft.Extensions.Logging;

    public interface INotificationService
    {
        void Notify(string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly Guid _id;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILoggerFactory factory)
        {
            this._logger = factory.CreateLogger<NotificationService>();
            this._id = Guid.NewGuid();
        }

        public void Notify(string message)
        {
            this._logger.LogInformation($"{this._id} : {message}");
        }
    }
}