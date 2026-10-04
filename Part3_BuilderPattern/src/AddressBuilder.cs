namespace Part3_BuilderPattern;

public class AddressBuilder
{
    private string? street;
    private string? city;
    private string? state;
    private string? zipCode;
    private string? country;

    public AddressBuilder SetStreet(string street)
    {
        this.street = street;
        return this;
    }

    public AddressBuilder SetCity(string city)
    {
        this.city = city;
        return this;
    }

    public AddressBuilder SetState(string state)
    {
        this.state = state;
        return this;
    }

    public AddressBuilder SetZipCode(string zipCode)
    {
        this.zipCode = zipCode;
        return this;
    }

    public AddressBuilder SetCountry(string country)
    {
        this.country = country;
        return this;
    }

    public Address Build()
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new InvalidOperationException("Street is required.");

        if (string.IsNullOrWhiteSpace(city))
            throw new InvalidOperationException("City is required.");

        if (string.IsNullOrWhiteSpace(state))
            throw new InvalidOperationException("State is required.");

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new InvalidOperationException("Zip code is required.");

        if (string.IsNullOrWhiteSpace(country))
            throw new InvalidOperationException("Country is required.");

        return new Address(
            street,
            city,
            state,
            zipCode,
            country);
    }
}