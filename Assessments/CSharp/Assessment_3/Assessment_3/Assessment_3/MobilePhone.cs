using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public delegate void RingEventHandler();
    public class MobilePhone
    {
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            OnRing();
        }
    }
    public class RingtonePlayer
    {
        public static void Ring()
        {
            Console.WriteLine("Playing ringtone....");
        }
    }
    public class ScreenDisplay
    {
        public static void Display()
        {
            Console.WriteLine("Displaying caller information....");
        }
    }
    public class VibrationMotor
    {
        public static void Vibrating()
        {
            Console.WriteLine("Phone is vibrating....");
        }
    }

    public class Mobile
    {
        public static void Main()
        {
            MobilePhone phone = new MobilePhone();

            Console.WriteLine("==== Ring Notification System ====");

            phone.OnRing += RingtonePlayer.Ring;
            phone.OnRing += ScreenDisplay.Display;
            phone.OnRing += VibrationMotor.Vibrating;

            Console.WriteLine("Incoming Call....");
            Console.WriteLine();
            phone.ReceiveCall();

            Console.WriteLine("===================================");

        }
    }
}
