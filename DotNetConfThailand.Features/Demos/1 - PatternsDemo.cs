using System;

namespace DotNetConfThailand.Features.Demos
{
    static class PatternsDemo
    {
        public static void Demo()
        {
            Console.WriteLine(
                Format(5m)
            );
            Console.WriteLine(
                Format(new[] { "a", "b", "c" })
            );
            Console.WriteLine(
                Format((5m, 6m))
            );
        }

        public static string Format(object toFormat)
        {
            switch (toFormat)
            {
                case decimal d:
                    return $"decimal {d}";


                case string[] array:
                    return $"string array [{string.Join(", ", array)}]";


                case (var a, var b):
                    return "A tuple with " + Format(a) + " and " + Format(b);


                case string { Length: var length } str when length > 10 :
                    return @$"The long string ""{str}"" with length {length}";


                case DateTime(2018, int month, int day):
                    return $"Last year! and the current month is {month} and the day is {day}";


                case { }:
                    return "Some object that isn't null" + toFormat.ToString();


                default:
                    return "You gave me nothing";
            }
        }

        public static void Deconstruct(this DateTime date, out int year, out int month, out int day)
        {
            year = date.Year;
            month = date.Month;
            day = date.Day;
        }

        public enum CarState
        {
            Cruising,
            Accelerating,
            Decelerating,
        }

        public static string DescribeChange(CarState oldState, CarState newState) =>
            (oldState, newState) switch
            {
                (CarState.Cruising, CarState.Accelerating) => "The driver pressed the gas pedal",
                (CarState.Cruising, CarState.Decelerating) => "The driver hit the brake",
                (CarState.Accelerating, CarState.Cruising) => "The driver stopped pressing the gas pedal",
                (CarState.Accelerating, CarState.Decelerating) => "The driver moved their foot from the gas to the brake pedal",
                (CarState.Decelerating, CarState.Cruising) => "The driver turned on cruise control",
                (CarState.Decelerating, CarState.Accelerating) => "The driver moved their foot from the break to the gas pedal",

                (var a, var b) when a == b => "The driver is chilling",
                _ => "Unknown state!"
            };

    }
}
