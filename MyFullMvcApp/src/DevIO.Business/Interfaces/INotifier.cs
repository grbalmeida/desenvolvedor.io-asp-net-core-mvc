using DevIO.Business.Notifications;
using System.Collections.Generic;

namespace DevIO.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
