using AwesomeShopPatterns.API.Core.Enums;

namespace AwesomeShopPatterns.API.Core.Entities
{
    public class Order
    {
        public Order(List<Guid> items)
        {
            Status = OrderStatus.Started;
            Items = items;
        }

        public OrderStatus Status { get; set; }
        public List<Guid> Items { get; set; }

        public void Add(Guid item)
        {
            if (Status == OrderStatus.Started || Status == OrderStatus.Preparing)
            {
                Items.Add(item);
            } else
            {
                throw new InvalidOperationException("Invalid operation.");
            }
        }

        public void StartPreparing()
        {
            if (Status == OrderStatus.Started)
            {
                Status = OrderStatus.Preparing;
            } else
            {
                throw new InvalidOperationException("Invalid operation.");
            }
        }

        public void StartDelivery()
        {
            if (Status == OrderStatus.Preparing)
            {
                Status = OrderStatus.OnWayToDeliver;
            } else
            {
                throw new InvalidOperationException("Invalid operation.");
            }
        }

        public void Complete()
        {
            if (Status == OrderStatus.OnWayToDeliver)
            {
                Status = OrderStatus.Completed;
            } else
            {
                throw new InvalidOperationException("Invalid operation.");
            }
        }
    }
}
