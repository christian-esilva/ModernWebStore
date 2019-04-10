using ModernWebStore.Infra.Persistence;
using ModernWebStore.SharedKernel;
using ModernWebStore.SharedKernel.Events;

namespace ModernWebStore.ApplicationService
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHandler<DomainNotification> _notifications;

        public ApplicationService(IUnitOfWork uof)
        {
            _unitOfWork = uof;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
