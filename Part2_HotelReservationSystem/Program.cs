namespace Part2_HotelReservationSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Room room = new(
            101,
            RoomType.Double,
            1500
        );

        Guest guest = new(
            1,
            "Mona Ali",
            "01012345678"
        );

        Reservation reservation = new(
            1001,
            new DateTime(2026, 10, 10),
            new DateTime(2026, 10, 13),
            room
        );

        guest.AddReservation(reservation);

        Console.WriteLine($"Guest: {guest.FullName}");
        Console.WriteLine($"Room: {reservation.Room.RoomNumber}");
        Console.WriteLine($"Room Type: {reservation.Room.RoomType}");
        Console.WriteLine($"Status: {reservation.Status}");
        Console.WriteLine($"Total Cost: {reservation.TotalCost:F2}");

        reservation.Confirm();
        Console.WriteLine($"Status after confirmation: {reservation.Status}");

        reservation.CheckIn();
        Console.WriteLine($"Status after check-in: {reservation.Status}");

        reservation.CheckOut();
        Console.WriteLine($"Status after check-out: {reservation.Status}");
    }
}