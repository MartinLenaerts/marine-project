using System;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What’s the weather like in Morocco?");
            WheatherProgram.MoroccoWheater();
            Console.WriteLine();
            Console.WriteLine("When will the sun rise and set today in Oslo?");
            WheatherProgram.OsloSun();
            Console.WriteLine("What’s the temperature in Jakarta (in Celsius)?");
            WheatherProgram.JakartaTemperature();
            Console.WriteLine();
            Console.WriteLine("Where is it more windy? New-York, Tokyo or Paris?");
            WheatherProgram.MoreWind();
            Console.WriteLine();
            Console.WriteLine("What is the humidity and pressure like in Kiev, Moscow and Berlin?");
            WheatherProgram.HumidityAndPressure();
            Console.ReadKey();
        }
    }

}