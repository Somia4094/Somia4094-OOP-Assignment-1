using Part1_ProceduralToOOP.src;

namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("OOP Order System");
            Console.WriteLine("Seed sample data, show a demo, then open the menu.");

            OrderSystem system = new();

            system.SeedSampleData();
            system.RunDemoScenario();

            system.PrintCustomers();
            system.PrintProducts();
            system.PrintAllOrders();

            Console.WriteLine(
                $"\nPaid sales total after demo: {system.TotalSalesPaidOnly():F2}"
            );

            RunInteractiveMenu(system);

            static void PrintMenu()
            {
                Console.WriteLine("\n---------- MENU ----------");
                Console.WriteLine("1) Print customers");
                Console.WriteLine("2) Print products");
                Console.WriteLine("3) Print all orders");
                Console.WriteLine("4) Print one order by id");
                Console.WriteLine("5) Create order");
                Console.WriteLine("6) Add line to order");
                Console.WriteLine("7) Mark order paid");
                Console.WriteLine("8) Show paid sales total");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");
            }

            static void RunInteractiveMenu(OrderSystem system)
            {
                int choice = -1;

                while (choice != 0)
                {
                    PrintMenu();

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            system.PrintCustomers();
                            break;

                        case 2:
                            system.PrintProducts();
                            break;

                        case 3:
                            system.PrintAllOrders();
                            break;

                        case 4:
                            Console.Write("Order id: ");

                            if (int.TryParse(Console.ReadLine(), out int orderId))
                            {
                                system.PrintOrder(orderId);
                            }

                            break;

                        case 5:
                            Console.Write("Order id: ");
                            int.TryParse(Console.ReadLine(), out int newOrderId);

                            Console.Write("Customer id: ");
                            int.TryParse(Console.ReadLine(), out int customerId);

                            Console.Write("Date (YYYY-MM-DD): ");
                            string date = Console.ReadLine() ?? "";

                            system.CreateOrder(
                                newOrderId,
                                customerId,
                                date
                            );

                            break;

                        case 6:
                            Console.Write("Order id: ");
                            int.TryParse(Console.ReadLine(), out int lineOrderId);

                            Console.Write("Product id: ");
                            int.TryParse(Console.ReadLine(), out int productId);

                            Console.Write("Quantity: ");
                            int.TryParse(Console.ReadLine(), out int quantity);

                            system.AddLineToOrder(
                                lineOrderId,
                                productId,
                                quantity
                            );

                            break;

                        case 7:
                            Console.Write("Order id: ");
                            int.TryParse(Console.ReadLine(), out int paidOrderId);

                            system.MarkOrderPaid(paidOrderId);
                            break;

                        case 8:
                            Console.WriteLine(
                                $"Paid sales total: {system.TotalSalesPaidOnly():F2}"
                            );
                            break;

                        case 0:
                            Console.WriteLine("Bye.");
                            break;

                        default:
                            Console.WriteLine("Unknown choice.");
                            break;
                    }
                }
            }
        }
    }
}
