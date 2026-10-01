namespace task_11
{
    public class OrderService
    {
        public event Action<Order> OrderProcessed;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Order {order.Id} has been processed.");

            OrderProcessed?.Invoke(order);
        }
    }
}
