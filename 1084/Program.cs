using System;

namespace Expr10
{
    class Program
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            var data = userInput.Split();
            double sideOfSquare = double.Parse(data[0]);
            double ropeLenght = double.Parse(data[1]);
            double areaOfGrass = 0;
            double pi = Math.PI;
            double sqrOfRopeLenght = ropeLenght * ropeLenght;
            if (ropeLenght <= sideOfSquare / 2)
                areaOfGrass = pi * sqrOfRopeLenght;
            else if (Math.Sqrt(2) * 0.5 * sideOfSquare <= ropeLenght)
                areaOfGrass = sideOfSquare*sideOfSquare;
            else
            {
                double angle = 2 * Math.Acos(sideOfSquare / (2 * ropeLenght));
                areaOfGrass = pi * sqrOfRopeLenght - 4 * (0.5 * sqrOfRopeLenght * (angle - Math.Sin(angle)));
            }
            areaOfGrass = Math.Round(areaOfGrass, 3);
            Console.Write(areaOfGrass);
        }
    }
}