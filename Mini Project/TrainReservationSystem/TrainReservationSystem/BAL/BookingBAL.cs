using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.DAL;

namespace TrainReservationSystem.BAL
{
    public class BookingException : Exception
    {
        public BookingException(string message) : base(message)
        {
        }
    }
    public class BookingBAL
    {
        BookingDAL dal = new BookingDAL();

        public void BookTicket(int trainNo, int from, int to, int count)
        {
            if (count <= 0 || count > 3)
                throw new BookingException("Max 3 passengers allowed");

            dal.BookTicket(trainNo, from, to, count);
        }

        public void CancelTicket(int passengerId)
        {
            if (passengerId <= 0)
                throw new BookingException("Invalid Passenger ID");

            dal.CancelTicket(passengerId);
        }

        public void GetBookingDetails(int bookingId)
        {
            dal.GetBookingDetails(bookingId);
        }
    }
}
