using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd4task1
{
    class Ship
    {
        public string Name;
        public Angle Latitude;
        public Angle Longitude;
        public Ship(string name, int latitudeDegree, float latiitudeMinute, char latitudeDirection, int longitudeDegree, float longitudeMinute, char longitudeDirection)
        {
            Name = name;
            Latitude = new Angle(latitudeDegree, latiitudeMinute, latitudeDirection);
            Longitude = new Angle(longitudeDegree, longitudeMinute, longitudeDirection);
        }
        public Ship(string name, Angle latitude, Angle longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
