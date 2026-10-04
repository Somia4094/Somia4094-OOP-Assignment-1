namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private int? invoiceId;
    private string? customerName;
    private string? customerEmail;
    private string? customerPhone;

    private Address? billingAddress;
    private Address? shippingAddress;
    private Order? order;

    public InvoiceBuilder SetInvoiceId(int invoiceId)
    {
        this.invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        this.customerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        this.customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        this.customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(Address billingAddress)
    {
        this.billingAddress = billingAddress;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address shippingAddress)
    {
        this.shippingAddress = shippingAddress;
        return this;
    }

    public InvoiceBuilder SetOrder(Order order)
    {
        this.order = order;
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

        if (billingAddress is null)
            throw new InvalidOperationException("Billing address is required.");

        if (shippingAddress is null)
            throw new InvalidOperationException("Shipping address is required.");

        if (order is null)
            throw new InvalidOperationException("Order information is required.");

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