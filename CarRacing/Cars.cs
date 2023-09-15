
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{


    internal abstract class Car : IComparable
    {
        protected const int DistanceForFinish = 10000;

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
        public int UpdateDistancePerOneSecond()
        {
            if (_distance < DistanceForFinish)
                _distance += _speed;
            else
                return Finish();
            return 0;
        }
        public void Move()
        {
            Random random = new Random();
            _speed = random.Next(MinSpeed, MaxSpeed);
        }
        public int Finish()
        {
            return -1;
        }

    }

 

    internal class SportCar : Car
    {
        static int _maxSpeed = 200;
        static int _minSpeed = 90;


        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public SportCar() : base() { }

    }

    internal class CargoCar : Car
    {
        static int _maxSpeed = 135;
        static int _minSpeed = 85;

        public override int MaxSpeed { get => _maxSpeed; }
        public override int MinSpeed { get => _minSpeed; }

        public CargoCar() : base() { }




    }

    internal class LightCar : Car
    {
        static int _maxSpeed = 160;
        static int _minSpeed = 120;

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
