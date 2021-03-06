﻿using System.Collections.Generic;

namespace ModernWebStore.Domain.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
        public CreateOrderCommand(IList<CreateOrderItemCommand> orderItems)
        {
            OrderItems = orderItems;
        }

        public IList<CreateOrderItemCommand> OrderItems { get; set; }
    }
}
