using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{

    public delegate void CarMovingDelegate();
    public delegate void CarUpdateDistanceDelegate();


    internal static class GameDisplay
    {
        static string sportCarImage = " _    _________        \n" +
                                      " |___/         \\_____ \n" +
                                      "  |___()________()___/ ";

        static string lightCarImage = "     ________          \n" +
                                      " ___/       \\____     \n" +
                                      " ^===()========()=^    ";

        static string CargoCarImage = "  ____________         \n" +
                                      " /           \\_____   \n" +
                                      " |___( )_____( )__||   ";

        static string BusImage =      " _____=_________=___   \n" +
                                      " |                 ||  \n" +
                                      " |_()_()_______()__|/  ";

        static private string GetStringPosition(Car car)
        {
            switch (car.Position)
            {
                case 0:
                    return "START";
                case 1:
                    return "FIRST";
                case 2:
                    return "SECOND";
                case 3:
                    return "THIRD";
            }

            throw new Exception();
        }
        static private string CarImagine(Car car)
        {
            if (car is SportCar)
                return sportCarImage;

            else if (car is CargoCar)
                return CargoCarImage;

            else if (car is LightCar)
                return lightCarImage;

            else
                return BusImage;

            throw new Exception();
        }
        static public void DisplayPositions(List<Car> cars)
        {
            Console.WriteLine("(Press Enter to continue the racing)\n");
            foreach (Car car in cars)
            {
                Console.WriteLine($"The {GetStringPosition(car)} car:\n" + car);
                Console.WriteLine(CarImagine(car));
                Console.WriteLine("--------------------------");
            }

        }
        static public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("!!!CAR RACING!!!");
            Console.WriteLine("1 - One car");
            Console.WriteLine("2 - Two cars");
            Console.WriteLine("3 - Three cars");
        }
        static public void DisplayChoiceMenu()
        {
            Console.Clear();
            Console.WriteLine("!!!CHOOSE YOUR CAR!!!");
            Console.WriteLine("1 - Sport car");
            Console.WriteLine("2 - Light car");
            Console.WriteLine("3 - Cargo car");
            Console.WriteLine("4 - Bus");
        }
        static public void DisplayWonCar(Car car)
        {
            Console.Clear();
            Console.WriteLine("Car:\n" + car + '\n' + CarImagine(car) + '\n' + "\nHAS WON!!!");
        }

    }

    internal class Game
    {
        List<Car> cars;
        CarMovingDelegate carMoving;
        CarUpdateDistanceDelegate carUpdateDistance;

        public Game()
        {
            cars = new List<Car>();
        }
        
        public void AddCar(Car car)
        {
            if (cars.Count <= 3)
                cars.Add(car);
            else
                throw new OutOfMemoryException();
        }
        private void AddFunctionInDelegate()
        {
            foreach(Car car in cars)
            {
                carMoving += car.Move;
                carUpdateDistance += car.UpdateDistancePerOneSecond;
            }
        }
        private void UpdateCarsPositions()
        {
            if (cars.Count == 0)
                throw new Exception();

            cars.Sort();
            cars.Reverse();

            for (int i = 0; i < cars.Count; i++)
                cars[i].Position = i + 1;
        }
        private void ProccessOfRacing()
        {
            while (!cars[0].Finish())
            {
                Console.Clear();

                carMoving();
                carUpdateDistance();
                UpdateCarsPositions();
                GameDisplay.DisplayPositions(cars);

                Console.ReadKey();
            }
        }
        private void EndOfRacing()
        {
            GameDisplay.DisplayWonCar(cars[0]);
        }

        private int ChoiceMainMenu()
        {
            GameDisplay.DisplayMainMenu();
            return Convert.ToInt32(Console.ReadLine());
        }
        private bool AddCarFromChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddCar(new SportCar());
                    break;
                case 2:
                    AddCar(new LightCar());
                    break;
                case 3:
                    AddCar(new CargoCar());
                    break;
                case 4:
                    AddCar(new Bus());
                    break;
               default:
                    return false;
            }
            return true;
        }
        private void ChoiceMenuCarsAdd()
        {
            int carsCount = 0;

            while ((carsCount = ChoiceMainMenu()) != 1 && carsCount != 2 && carsCount != 3)
                continue;

            while(carsCount != 0)
            {
                GameDisplay.DisplayChoiceMenu();
                if (AddCarFromChoice(Convert.ToInt32(Console.ReadLine())))
                    carsCount--;            
            }
        }
        

        public int GameMain()
        {
            ChoiceMenuCarsAdd();
            AddFunctionInDelegate();
            ProccessOfRacing();
            EndOfRacing();

            return 1;
        }

    }
}
