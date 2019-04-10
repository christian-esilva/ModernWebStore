using ModernWebStore.Domain.Commands.OrderCommands;
using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class OrderApplicationService : ApplicationService, IOrderApplicationService
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public OrderApplicationService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public void Cancel(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.Cancel();
            _orderRepository.Update(order);

            Commit();
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            var user = _userRepository.GetByEmail(email);
            var orderItems = new List<OrderItem>();
            foreach (var item in command.OrderItems)
            {
                var orderItem = new OrderItem();
                var product = _productRepository.Get(item.Product);
                orderItem.AddProduct(product, item.Quantity, item.Price);
                orderItems.Add(orderItem);
            }

            var order = new Order(orderItems, user.Id);
            order.Place();
            _orderRepository.Create(order);

            return Commit() ? order : null;
        }

        public void Delivery(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.MarkAsDelivered();
            _orderRepository.Update(order);

            Commit();
        }

        public List<Order> Get(string email, int skip, int take)
        {
            return _orderRepository.Get(email, skip, take);
        }

        public List<Order> GetCanceled(string email)
        {
            return _orderRepository.GetCanceled(email);
        }

        public List<Order> GetCreated(string email)
        {
            return _orderRepository.GetCreated(email);
        }

        public List<Order> GetDelivered(string email)
        {
            return _orderRepository.GetDelivered(email);
        }

        public Order GetDetails(int id, string email)
        {
            return _orderRepository.GetDetails(id, email);
        }

        public List<Order> GetPaid(string email)
        {
            return _orderRepository.GetPaid(email);
        }

        public void Pay(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.MarkAsPaid();
            _orderRepository.Update(order);

            Commit();
        }
    }
}
