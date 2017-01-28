using System;
using System.Timers;

namespace time_is_ticking_out
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (Properties.Settings.Default.dateOfBirth.Equals(new DateTime(0)) || Properties.Settings.Default.expectedLifetime == 0)
            {
                FirstTimeSetup();
            }

            var secondsLeft = GetSecondsLeft();


            var timer = new Timer(1000);
            timer.Elapsed += delegate { DisplaySecondsLeft(secondsLeft--); };
            timer.Start();

            // No amount of GC is going to let you forget your time is ticking out.
            GC.KeepAlive(timer);

            Console.Read();
        }


        private static void DisplaySecondsLeft(ulong secondsLeft)
        {
            var daysLeft = (int)TimeSpan.FromSeconds(secondsLeft).TotalDays;
            var str = "\n You have " + secondsLeft + " seconds left, or about " + daysLeft + " days";
            Console.Clear();
            Console.WriteLine(str);
        }


        // uint's max value is 4'294'967'295, which taken as seconds is equivalent to about 136 years.
        // A tad optimistic, but we're not here to judge, so ulong it is ;)
        private static ulong GetSecondsLeft()
        {
            var dob = Properties.Settings.Default.dateOfBirth;
            var expectedLifetime = Properties.Settings.Default.expectedLifetime;

            var t = dob.AddYears(expectedLifetime) - DateTime.UtcNow;
            return Convert.ToUInt64(t.TotalSeconds);
        }


        private static void FirstTimeSetup()
        {
            Console.WriteLine("Hi. Let's get your timer set up.");
            GetDateOfBirth();
            Console.WriteLine("Awesome.");
            GetExpectedLifeLength();
            Console.WriteLine("Got it.");
            Properties.Settings.Default.Save();
            Console.WriteLine();
        }


        private static void GetDateOfBirth()
        {
            Console.Write("What's your date of birth? ");
            var dob = Console.ReadLine();

            var parseSucceeded = ParseDate(dob);

            while (parseSucceeded == false)
            {
                Console.Write("The provided date is not valid.\n\nA good format is DD-MM-YYYY, and it needs to be after today.\n\nPlease enter your date of birth: ");
                dob = Console.ReadLine();
                Console.WriteLine("\n");
                parseSucceeded = ParseDate(dob);
            }
        }


        private static bool ParseDate(string input)
        {
            DateTime date;
            var succeeded = DateTime.TryParse(input, out date);

            if (succeeded == false)
            {
                return false;
            }

            Properties.Settings.Default.dateOfBirth = date;
            return true;
        }


        private static void GetExpectedLifeLength()
        {
            Console.Write("How many years do you think you'll live in total? ");
            var years = Console.ReadLine();

            var succeeded = ParseExpectedLifeLength(years);

            while (succeeded == false)
            {
                Console.Write("The provided duration is not valid, try inserting a number.\n\nPlease enter your life expectancy: ");
                years = Console.ReadLine();
                Console.WriteLine("\n");
                succeeded = ParseExpectedLifeLength(years);
            }
        }


        private static bool ParseExpectedLifeLength(string input)
        {
            try
            {
                var years = Convert.ToUInt16(input, 10);
                Properties.Settings.Default.expectedLifetime = years;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}