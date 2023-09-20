
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{

    public delegate bool FinishDelegate();

    // I didn't come up with that, how do so to end the game with event, except the situation,
    // when I end the game in the class Car. But I think end the game in the class Car is incorrectly

    internal abstract class Car : IComparable
    {
        protected static int DistanceForFinish = 10000;

        public abstract int MaxSpeed { get; }
        public abstract int MinSpeed { get; }
        public int Position 
        { 
            get => _position; 
            set 
            {
                PropertyExceptionsCatcher(ref _position, value);
            } 
        }    
        public int Distance 
        { 
            get => _distance;
            private set
            {
                PropertyExceptionsCatcher(ref _distance, value);
                FinishEvent?.Invoke();
            }
        
        }

        FinishDelegate FinishEvent;

        protected int _position = 0;
        protected int _speed = 0;
        protected int _distance = 0;

        public Car()
        {
            FinishEvent += Finish;
        }

        public int CompareTo(object obj)
        {
            if (obj is Car car) return _distance.CompareTo(car._distance);
            else throw new ArgumentException();
        }

        private void PropertyExceptionsCatcher(ref int field, int value)
        {
            try
            {
                if (value < 0)
                    throw new FormatException(nameof(value) + " < 0");
                field = value;
            }
            catch (Exception) { throw; }
        }
        public void UpdateDistancePerOneSecond()
        {
            Distance += _speed;
        }
        public void Move()
        {
            Random random = new Random();
            _speed = random.Next(MinSpeed, MaxSpeed);
        }
        public bool Finish()
        {
            if (_distance > DistanceForFinish)
                return true;
            return false;
        }
        public override string ToString()
        {
            return $"Type of car: {this.GetType().ToString().Replace("CarRacing.", "")}\n" +
                $"Current speed: {_speed}\nPosition: {_position}\n" +
                $"Distance: {_distance}";
        }
    }

 

    internal class SportCar : Car
    {
        static int _maxSpeed = 170;
        static int _minSpeed = 90;


        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public SportCar() : base() { }

    }

    internal class CargoCar : Car
    {
        static int _maxSpeed = 135;
        static int _minSpeed = 125;

        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public CargoCar() : base() { }




    }

    internal class LightCar : Car
    {
        static int _maxSpeed = 150;
        static int _minSpeed = 115;

        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public LightCar() : base() { }
    }

    internal class Bus : Car
    {
        static int _maxSpeed = 120;
        static int _minSpeed = 100;

        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public Bus() : base() { }
    }


}
