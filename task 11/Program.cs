namespace task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region section 1
            List<Book> books = new List<Book>()
            {
                new Book(
            "978-0132350884",
             "Clean Code",
             new string[] { "Robert C. Martin" },
             new DateTime(2008, 8, 1),
             50m),

                new Book(
            "978",
             "Clean Code",
             new string[] { "Robert C. Martin" },
             new DateTime(2000, 5, 1),
             100m)
            };


            #region case 1
            LibraryEngine.ProcessBooks1(books, BookFunctions.GetTitle);
            #endregion


            #region case 2
            LibraryEngine.ProcessBooks2(books, BookFunctions.GetTitle);
            #endregion


            #region case 3

            LibraryEngine.ProcessBooks1(
                books,
                delegate (Book B)
                {
                    return B.ISBN;
                });

            #endregion

            #region case 4
            LibraryEngine.ProcessBooks1( books,B => B.PublicationDate.ToString());
            #endregion


            #endregion



            #region section2
            #region part 1
            Order order = new Order()
            {
                Id = 1,
                CustomerName = "Noha",
                Price = 50,
                Quantity = 2

            };


            decimal total = order.CalculateOrderPrice(order, order.CalculateTotal);

            decimal totalWithDiscount =
                order.CalculateOrderPrice(order, order.CalculateTotalWithDisscount);


            Console.WriteLine($"Total = {total}");
            Console.WriteLine($"Total With Discount = {totalWithDiscount}");
            #endregion

            #endregion



            #region part 2
            Func<Order, decimal> normalCalculation =   x => x.Price * x.Quantity;

            Func<Order, decimal> discountCalculation =
                x => (x.Price * x.Quantity) - 10;

            decimal normalPrice =  order.CalculateOrderPriceWithFunc(order, normalCalculation);

            decimal discountPrice = order.CalculateOrderPriceWithFunc(order, discountCalculation);

            Console.WriteLine($"Normal Price = {normalPrice}");
            Console.WriteLine($"Discount Price = {discountPrice}");

            /*Func<> provides a built-in delegate type, so we do not need to create a custom delegate for every method that has the same input and return type.
             * It makes the code simpler and more reusable.*/
            #endregion



            #region part 3
            bool validQuantity = order.ValidateOrder(order,order => order.Quantity > 0);

            bool validPrice = order.ValidateOrder(
                order,
                order => order.Price > 0);

            bool validCustomerName = order.ValidateOrder(
                order,
                order => !string.IsNullOrWhiteSpace(order.CustomerName));

            Console.WriteLine($"Quantity Valid: {validQuantity}");
            Console.WriteLine($"Price Valid: {validPrice}");
            Console.WriteLine($"Customer Name Valid: {validCustomerName}");

            /*Predicate<Order> is more expressive because it clearly indicates that the function is used for testing or validating a condition and returns either true or false. Func<Order, bool> can do the same
             * thing, but Predicate<Order> communicates the purpose more clearly.*/
            #endregion



            #region part 4
            Action<Order> printOrder = order =>
            {
                Console.WriteLine(
                    $"Order {order.Id} processed. Customer: {order.CustomerName}");
            };

            Action<Order> sendConfirmation = order =>
            {
                Console.WriteLine(
                    $"Confirmation message sent for Order {order.Id}.");
            };

            Action<Order> writeAudit = order =>
            {
                Console.WriteLine(
                    $"Audit message: Order {order.Id} was processed.");
            };

            order.ProcessOrder(order, printOrder);

            order.ProcessOrder(order, sendConfirmation);

            order.ProcessOrder(order, writeAudit);

            #endregion



            #region part 5
            OrderService orderService = new OrderService();

            orderService.OrderProcessed += order =>
            {
                Console.WriteLine($"Order {order.Id} processed successfully.");
            };

            orderService.OrderProcessed += order =>
            {
                Console.WriteLine($"Notification sent for Order {order.Id}.");
            };

            orderService.OrderProcessed += order =>
            {
                Console.WriteLine($"Audit: Order {order.Id} was processed.");
            };

            orderService.ProcessOrder(order);
            #endregion



            #region part 6
            OrderService orderService2 = new OrderService();

            orderService2.OrderProcessed += Handler1;
            orderService2.OrderProcessed += Handler2;

            orderService2.OrderProcessed -= Handler1;

            orderService2.ProcessOrder(order);
            #endregion



            //q1
            /* PriceCalculator is a user-defined delegate created specifically for calculating an order price.

            Func<Order, decimal> is a built-in generic delegate that represents a method that takes an Order and returns a decimal.

           Both can represent the same method signature, but Func<Order, decimal> does not require creating a custom delegate.*/


            //Q2
            /* Action<Order> takes an Order as input and does not return a value.

              Func<Order, decimal> takes an Order as input and returns a decimal value.*/



            //q3 
            /* Predicate<T> is designed to represent a condition or validation rule.

              It returns true when the object satisfies the condition and false when it does not.*/


            //q4
            /* A delegate is a type that can reference a method and can be invoked.

                An event is based on a delegate and is used to notify other parts of the application when something happens.
                
                An event also controls who can invoke it.*/


            //q5
            /* Because an event can only be raised from inside the class that declares it.

             External code can subscribe or unsubscribe to the event, but it cannot directly invoke it.*/


            //q6
            /* All subscribed handlers are called when the event is raised.

            This is called multicast behavior. */


            //Q7
            /* OrderProcessed is the event.
            The += operator subscribes HandleOrderProcessed to the event.
            HandleOrderProcessed is the handler that will be called when the event is raised.*/


            //q8
               /* Action<Order> is a delegate that can reference a method that receives an Order and returns nothing.

               event Action<Order> is an event that uses Action<Order> as its delegate type.
               
               The event is safer because external code can subscribe and unsubscribe, but normally cannot invoke the event directly.
               
               Therefore, events are used for notifications and controlled communication between classes.*/
        }

        static void Handler1(Order order)
        {
            Console.WriteLine($"Handler1: Order {order.Id} processed.");
        }

        static void Handler2(Order order)
        {
            Console.WriteLine($"Handler2: Order {order.Id} processed.");
        }
    }
}
