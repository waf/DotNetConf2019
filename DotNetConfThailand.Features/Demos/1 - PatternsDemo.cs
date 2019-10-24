using System;
using System.Collections.Immutable;

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


                case string { Length: var length } str when length > 10:
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

        /*
          State Management example
          We have a list UI that can add or remove input fields.
          We support a maximum of 10 input fields.
          We use an ImmutableList<Input> as our viewmodel.
        */

        public enum Button
        {
            AddInput,
            RemoveInput,
        }

        public static ImmutableList<Input> GetNextState(ImmutableList<Input> list, Button button) =>
            (list, button) switch
            {
                ({ Count: 10 }, Button.AddInput) => list,
                ({ Count: 0 }, Button.RemoveInput) => list,
                (_, Button.AddInput) => list.Add(new Input()),
                ({ Count: var count }, Button.RemoveInput) => list.RemoveAt(count - 1),

                _ => throw new ArgumentOutOfRangeException(nameof(button), button, "Unknown enum value")
            };





        public class Input { }
    }
}
