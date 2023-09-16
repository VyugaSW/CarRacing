
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{

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
                try
                {
                    _position = value;
                }
                catch (Exception)
                {
                    throw;
                }
            } 
        }    

        protected int _position = 0;
        protected int _speed = 0;
        protected int _distance = 0;


        public int CompareTo(object obj)
        {
            if (obj is Car car) return _distance.CompareTo(car._distance);
            else throw new ArgumentException();
        }

        public override string ToString()
        {
            return $"Type of car: {this.GetType().ToString().Replace("CarRacing.", "")}\n" +
                $"Current speed: {_speed}\nPosition: {_position}\n" +
                $"Distance: {_distance}";
        }
        public void UpdateDistancePerOneSecond()
        {
            _distance += _speed;
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
