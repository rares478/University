namespace Lab1
{
    public abstract class Program
    {
        private static int[] Ex1(int n)
        {
            switch (n)
            {
                case 0:
                    return [0];
                case 1:
                    return [0, 1];
            }

            var fib = new int[n];
            fib[0] = 0;
            fib[1] = 1;

            for (var i = 2; i < n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib;
        }

        private static void Ex2()
        {
            var num1 = Convert.ToInt32(Console.ReadLine());
            var num2 = Convert.ToInt32(Console.ReadLine());
            Calculator.DisplayResults(num1, num2);
           
        }

        private static void Ex3()
        {
            Console.WriteLine("Enter temperature value:");
            var temp = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the unit of the temperature (C/F):");
            var unit = Console.ReadLine()!.ToUpper();

            switch (unit)
            {
                case "C":
                {
                    var fahrenheit = CelsiusToFahrenheit(temp);
                    Console.WriteLine($"{temp}°C is {fahrenheit}°F");
                    break;
                }
                case "F":
                {
                    var celsius = FahrenheitToCelsius(temp);
                    Console.WriteLine($"{temp}°F is {celsius}°C");
                    break;
                }
                default:
                    Console.WriteLine("Invalid unit.");
                    break;
            }
        }

        private static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        private static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        private static void Ex4()
        {
            Console.WriteLine("Enter height in cm:");
            var height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter age in years:");
            var age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter gender (m/f):");
            var gender = Console.ReadLine()!.ToLower();

            IdealWeightCalculator.DisplayIdealWeight(height, age, gender);
        }

        private static void Ex5()
        {
            Console.WriteLine("Enter a series of integers:");
            var input = Console.ReadLine();
            var numbers = input!.Split(' ').Select(int.Parse).ToArray();
            
            var arithmeticMean = numbers.Average();
            var geometricMean = Math.Pow(numbers.Aggregate(1.0, (acc, val) => acc * val), 1.0 / numbers.Length);
            
            Console.WriteLine($"Arithmetic Mean: {arithmeticMean}");
            Console.WriteLine($"Geometric Mean: {geometricMean}");
        }
        
        public static void Main(string[] args)
        {
            Ex5();
        }
    }
}