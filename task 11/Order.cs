namespace task_11
{
    public delegate decimal PriceCalculator(Order oreder);

    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }



        public decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }

        public decimal CalculateTotalWithDisscount(Order order)
        {
            return (order.Price * order.Quantity) - 10;
        }


        public decimal CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            return calculator(order);
        }

        public decimal CalculateOrderPriceWithFunc(
            Order order,
            Func<Order, decimal> calculator)
        {
            return calculator(order);
        }


        public bool ValidateOrder( Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }

        public void ProcessOrder(Order order, Action<Order> action)
        {
            Console.WriteLine($"Order {order.Id} is being processed...");

            action(order);
        }
    }
}
