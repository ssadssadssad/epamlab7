using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public IEnumerable<Plane> planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes;
        }

        public IEnumerable<T> GetPlanes<T>() where T : Plane
        {
            return planes.Where(plane => plane.GetType() == typeof(T)).Cast<T>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPlanes<PassengerPlane>().OrderByDescending(plane => plane.passengersCapacity).First();
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetPlanes<MilitaryPlane>().Where(plane => plane.militaryType == MilitaryType.Transport);
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(plane => plane.maxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(plane => plane.maxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(plane => plane.maxLoadCapacity));
        }

        public override string ToString()
        {
            return $"Airport planes: {string.Join(",  ", planes.Select(plane => plane.model))}";
        }
    }
}
