namespace Part3_BuilderPattern;

public class OrderBuilder
{
    private DateTime? orderDate;
    private string? paymentMethod;
    private string? currency;

    private decimal subTotal;
    private decimal discountAmount;
    private decimal taxAmount;
    private decimal totalAmount;

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        this.orderDate = orderDate;
        return this;
    }

    public OrderBuilder SetPaymentMethod(string paymentMethod)
    {
        this.paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder SetCurrency(string currency)
    {
        this.currency = currency;
        return this;
    }

    public OrderBuilder SetSubTotal(decimal subTotal)
    {
        this.subTotal = subTotal;
        return this;
    }

    public OrderBuilder SetDiscountAmount(decimal discountAmount)
    {
        this.discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder SetTaxAmount(decimal taxAmount)
    {
        this.taxAmount = taxAmount;
        return this;
    }

    public OrderBuilder SetTotalAmount(decimal totalAmount)
    {
        this.totalAmount = totalAmount;
        return this;
    }

    public Order Build()
    {
        if (orderDate is null)
            throw new InvalidOperationException("Order date is required.");

        if (string.IsNullOrWhiteSpace(paymentMethod))
            throw new InvalidOperationException("Payment method is required.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new InvalidOperationException("Currency is required.");

        if (subTotal < 0)
            throw new InvalidOperationException("Subtotal cannot be negative.");

        if (discountAmount < 0)
            throw new InvalidOperationException("Discount amount cannot be negative.");

        if (taxAmount < 0)
            throw new InvalidOperationException("Tax amount cannot be negative.");

        if (totalAmount < 0)
            throw new InvalidOperationException("Total amount cannot be negative.");

        return new Order(
            orderDate.Value,
            paymentMethod,
            currency,
            subTotal,
            discountAmount,
            taxAmount,
            totalAmount);
    }
}