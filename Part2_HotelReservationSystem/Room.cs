namespace Part2_HotelReservationSystem;

public class Room
{
    private readonly List<Reservation> reservations = new();

    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public double NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    public Room(int roomNumber, RoomType roomType, double nightlyRate)
    {
        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public void ChangeNightlyRate(double newRate)
    {
        if (newRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    internal bool HasOverlappingReservation(
        DateTime checkInDate,
        DateTime checkOutDate)
    {
        foreach (Reservation reservation in reservations)
        {
            if (reservation.Status == ReservationStatus.Cancelled ||
                reservation.Status == ReservationStatus.CheckedOut)
            {
                continue;
            }

            bool overlaps =
                checkInDate < reservation.CheckOutDate &&
                checkOutDate > reservation.CheckInDate;

            if (overlaps)
                return true;
        }

        return false;
    }

    internal void RegisterReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }
}