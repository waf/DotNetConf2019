using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    class PatternsFeature
    {
        public static void Demo()
        {
            Console.WriteLine(Format("Hello World!"));
        }

        public static string Format(object toFormat)
        {
            switch (toFormat)
            {
                case string { Length: var length } str when length > 10 :
                    return @$"The long string ""{str}"" with length {length}";
                case string s:
                    return $"A string {s}";
                case decimal d:
                    return $"A decimal {d}";
                case (var a, var b):
                    return "A tuple with " + Format(a) + " " + Format(b);
                case { }:
                    return "Some object that isn't null" + toFormat.ToString();
                default:
                    return "You gave me nothing";
            }
        }


        public enum CarState
        {
            Cruising,
            Accelerating,
            Decelerating,
        }

        public string DescribeChange(CarState oldState, CarState newState) =>
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
