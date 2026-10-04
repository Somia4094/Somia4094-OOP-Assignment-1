namespace Part2_HotelReservationSystem;

public class Guest
{
    private readonly List<Reservation> reservations = new();

    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    public IReadOnlyList<Reservation> Reservations =>
        reservations.AsReadOnly();

    public Guest(
        int guestId,
        string fullName,
        string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException(
                "Guest full name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException(
                "Guest phone number cannot be empty.");
        }

        GuestId = guestId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public void AddReservation(Reservation reservation)
    {
        if (reservation is null)
        {
            throw new ArgumentNullException(nameof(reservation));
        }

        if (!reservations.Contains(reservation))
        {
            reservations.Add(reservation);
        }
    }
}