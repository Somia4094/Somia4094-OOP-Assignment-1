namespace Part2_HotelReservationSystem;

public class Reservation
{
    public int ReservationId { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public Room Room { get; }
    public ReservationStatus Status { get; private set; }

    public double TotalCost =>
        (CheckOutDate - CheckInDate).Days * Room.NightlyRate;

    public Reservation(
        int reservationId,
        DateTime checkInDate,
        DateTime checkOutDate,
        Room room)
    {
        if (checkOutDate <= checkInDate)
        {
            throw new ArgumentException(
                "Check-out date must be after check-in date.");
        }

        if (room.IsUnderMaintenance)
        {
            throw new InvalidOperationException(
                "Cannot create a reservation for a room under maintenance.");
        }

        if (room.HasOverlappingReservation(
                checkInDate,
                checkOutDate))
        {
            throw new InvalidOperationException(
                "The room already has an overlapping active reservation.");
        }

        ReservationId = reservationId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        Status = ReservationStatus.Pending;

        room.RegisterReservation(this);
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
        {
            throw new InvalidOperationException(
                "Only a pending reservation can be confirmed.");
        }

        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "A reservation must be confirmed before check-in.");
        }

        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
        {
            throw new InvalidOperationException(
                "Only a checked-in reservation can be checked out.");
        }

        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.Pending &&
            Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Only pending or confirmed reservations can be cancelled.");
        }

        Status = ReservationStatus.Cancelled;
    }
}