namespace Part3_BuilderPattern;

public class InvoiceSingleBuilder
{
    private int? invoiceId;
    private string? customerName;
    private string? customerEmail;
    private string? customerPhone;

    private string? billingStreet;
    private string? billingCity;
    private string? billingState;
    private string? billingZipCode;
    private string? billingCountry;

    private string? shippingStreet;
    private string? shippingCity;
    private string? shippingState;
    private string? shippingZipCode;
    private string? shippingCountry;

    private DateTime? orderDate;
    private string? paymentMethod;
    private string? currency;

    private decimal subTotal;
    private decimal discountAmount;
    private decimal taxAmount;
    private decimal totalAmount;

    public InvoiceSingleBuilder SetInvoiceId(int invoiceId)
    {
        this.invoiceId = invoiceId;
        return this;
    }

    public InvoiceSingleBuilder SetCustomerName(string customerName)
    {
        this.customerName = customerName;
        return this;
    }

    public InvoiceSingleBuilder SetCustomerEmail(string customerEmail)
    {
        this.customerEmail = customerEmail;
        return this;
    }

    public InvoiceSingleBuilder SetCustomerPhone(string customerPhone)
    {
        this.customerPhone = customerPhone;
        return this;
    }

    public InvoiceSingleBuilder SetBillingStreet(string value)
    {
        billingStreet = value;
        return this;
    }

    public InvoiceSingleBuilder SetBillingCity(string value)
    {
        billingCity = value;
        return this;
    }

    public InvoiceSingleBuilder SetBillingState(string value)
    {
        billingState = value;
        return this;
    }

    public InvoiceSingleBuilder SetBillingZipCode(string value)
    {
        billingZipCode = value;
        return this;
    }

    public InvoiceSingleBuilder SetBillingCountry(string value)
    {
        billingCountry = value;
        return this;
    }

    public InvoiceSingleBuilder SetShippingStreet(string value)
    {
        shippingStreet = value;
        return this;
    }

    public InvoiceSingleBuilder SetShippingCity(string value)
    {
        shippingCity = value;
        return this;
    }

    public InvoiceSingleBuilder SetShippingState(string value)
    {
        shippingState = value;
        return this;
    }

    public InvoiceSingleBuilder SetShippingZipCode(string value)
    {
        shippingZipCode = value;
        return this;
    }

    public InvoiceSingleBuilder SetShippingCountry(string value)
    {
        shippingCountry = value;
        return this;
    }

    public InvoiceSingleBuilder SetOrderDate(DateTime value)
    {
        orderDate = value;
        return this;
    }

    public InvoiceSingleBuilder SetPaymentMethod(string value)
    {
        paymentMethod = value;
        return this;
    }

    public InvoiceSingleBuilder SetCurrency(string value)
    {
        currency = value;
        return this;
    }

    public InvoiceSingleBuilder SetSubTotal(decimal value)
    {
        subTotal = value;
        return this;
    }

    public InvoiceSingleBuilder SetDiscountAmount(decimal value)
    {
        discountAmount = value;
        return this;
    }

    public InvoiceSingleBuilder SetTaxAmount(decimal value)
    {
        taxAmount = value;
        return this;
    }

    public InvoiceSingleBuilder SetTotalAmount(decimal value)
    {
        totalAmount = value;
        return this;
    }

    public Invoice Build()
    {
        if (invoiceId is null)
            throw new InvalidOperationException("Invoice ID is required.");

        if (string.IsNullOrWhiteSpace(customerName))
            throw new InvalidOperationException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(customerEmail))
            throw new InvalidOperationException("Customer email is required.");

        Address billingAddress = new AddressBuilder()
            .SetStreet(billingStreet ?? "")
            .SetCity(billingCity ?? "")
            .SetState(billingState ?? "")
            .SetZipCode(billingZipCode ?? "")
            .SetCountry(billingCountry ?? "")
            .Build();

        Address shippingAddress = new AddressBuilder()
            .SetStreet(shippingStreet ?? "")
            .SetCity(shippingCity ?? "")
            .SetState(shippingState ?? "")
            .SetZipCode(shippingZipCode ?? "")
            .SetCountry(shippingCountry ?? "")
            .Build();

        Order order = new OrderBuilder()
            .SetOrderDate(orderDate ?? throw new InvalidOperationException("Order date is required."))
            .SetPaymentMethod(paymentMethod ?? "")
            .SetCurrency(currency ?? "")
            .SetSubTotal(subTotal)
            .SetDiscountAmount(discountAmount)
            .SetTaxAmount(taxAmount)
            .SetTotalAmount(totalAmount)
            .Build();

        return new Invoice(
            invoiceId.Value,
            customerName,
            customerEmail,
            customerPhone,
            billingAddress,
            shippingAddress,
            order);
    }
}