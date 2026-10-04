using Part3_BuilderPattern;

Address billingAddress = new AddressBuilder()
    .SetStreet("10 Nile Street")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("11511")
    .SetCountry("Egypt")
    .Build();

Address shippingAddress = new AddressBuilder()
    .SetStreet("20 Tahrir Street")
    .SetCity("Giza")
    .SetState("Giza")
    .SetZipCode("12511")
    .SetCountry("Egypt")
    .Build();

Order order = new OrderBuilder()
    .SetOrderDate(new DateTime(2026, 10, 3))
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(5000m)
    .SetDiscountAmount(500m)
    .SetTaxAmount(450m)
    .SetTotalAmount(4950m)
    .Build();

Invoice invoice = new InvoiceBuilder()
    .SetInvoiceId(1001)
    .SetCustomerName("Somia Ahmed")
    .SetCustomerEmail("somia@example.com")
    .SetCustomerPhone("01012345678")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
Console.WriteLine($"Payment Method: {invoice.Order.PaymentMethod}");
Console.WriteLine($"Total Amount: {invoice.Order.TotalAmount} {invoice.Order.Currency}");

Invoice singleBuilderInvoice = new InvoiceSingleBuilder()
    .SetInvoiceId(2001)
    .SetCustomerName("Ahmed Ali")
    .SetCustomerEmail("ahmed@example.com")
    .SetCustomerPhone("01112345678")

    .SetBillingStreet("5 Main Street")
    .SetBillingCity("Cairo")
    .SetBillingState("Cairo")
    .SetBillingZipCode("11511")
    .SetBillingCountry("Egypt")

    .SetShippingStreet("15 Garden Street")
    .SetShippingCity("Giza")
    .SetShippingState("Giza")
    .SetShippingZipCode("12511")
    .SetShippingCountry("Egypt")

    .SetOrderDate(new DateTime(2026, 10, 3))
    .SetPaymentMethod("Cash")
    .SetCurrency("EGP")
    .SetSubTotal(3000m)
    .SetDiscountAmount(300m)
    .SetTaxAmount(270m)
    .SetTotalAmount(2970m)
    .Build();

Console.WriteLine();
Console.WriteLine("Single Builder Test");
Console.WriteLine($"Invoice ID: {singleBuilderInvoice.InvoiceId}");
Console.WriteLine($"Customer: {singleBuilderInvoice.CustomerName}");
Console.WriteLine($"Total: {singleBuilderInvoice.Order.TotalAmount} {singleBuilderInvoice.Order.Currency}");