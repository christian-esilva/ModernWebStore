using ModernWebStore.Domain.Enums;
using ModernWebStore.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernWebStore.Domain.Entities
{
    public class Order
    {
        private IList<OrderItem> _orderItems;

        public Order(IList<OrderItem> orderItems, int userId)
        {
            Date = DateTime.Now;
            _orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(x => AddItem(x));
            UserId = userId;
            Status = EOrderStatus.Created;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public ICollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            private set { _orderItems = new List<OrderItem>(value); }
        }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in _orderItems)
                    total += (item.Price * item.Quantity);

                return total;
            }
        }
        public EOrderStatus Status { get; private set; }

        public void AddItem(OrderItem item)
        {
            if (item.Register())
                _orderItems.Add(item);
        }

        public void Place()
        {
            this.PlaceOrderScopeIsValid();
        }

        public void MarkAsPaid()
        {
            // Dá baixa no estoque
            Status = EOrderStatus.Paid;
        }

        public void MarkAsDelivered()
        {
            Status = EOrderStatus.Delivered;
        }

        public void Cancel()
        {
            // Estorna os produtos
            Status = EOrderStatus.Canceled;
        }
    }
}
