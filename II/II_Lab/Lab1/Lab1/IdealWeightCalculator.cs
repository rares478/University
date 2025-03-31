
namespace Lab1
{
    public abstract class IdealWeightCalculator
    {
        private static double CalculateIdealWeightForMen(double height, int age)
        {
            return (height - 100 - ((height - 150) / 4)) + ((age - 20) / 4);
        }

        private static double CalculateIdealWeightForWomen(double height, int age)
        {
            return (height - 100 - ((height - 150) / 2.5)) + ((age - 20) / 6);
        }

        public static void DisplayIdealWeight(double height, int age, string gender)
        {
            double idealWeight;
            if (gender.ToLower() == "m")
            {
                idealWeight = CalculateIdealWeightForMen(height, age);
            }
            else if (gender.ToLower() == "f")
            {
                idealWeight = CalculateIdealWeightForWomen(height, age);
            }
            else
            {
                Console.WriteLine("Invalid gender.");
                return;
            }

            Console.WriteLine($"The ideal weight for a {age} year old {gender} with a height of {height} cm is {idealWeight} kg.");
        }
    }
}