
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
        protected static int maxSpeed = 0;
        protected static int minSpeed = 0;

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
            _speed = random.Next(minSpeed, maxSpeed);
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
        public SportCar()
        {
            if (maxSpeed == 0 || minSpeed == 0)
            {
                maxSpeed = 170;
                minSpeed = 90;
            }
        }

    }

    internal class CargoCar : Car
    {
        public CargoCar()
        {
            if (maxSpeed == 0 || minSpeed == 0)
            {
                maxSpeed = 130;
                minSpeed = 125;
            }
        }

    }

    internal class LightCar : Car
    {
        public LightCar()
        {
            if (maxSpeed == 0 || minSpeed == 0)
            {
                maxSpeed = 150;
                minSpeed = 115;
            }
        }
    }

    internal class Bus : Car
    {
        public Bus()
        {
            if (maxSpeed == 0 || minSpeed == 0)
            {
                maxSpeed = 120;
                minSpeed = 100;
            }
        }
    }


}
