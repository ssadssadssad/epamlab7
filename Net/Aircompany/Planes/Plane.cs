using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string model { get; private set; }
        public int maxSpeed { get; private set; }
        public int maxFlightDistance { get; private set; }
        public int maxLoadCapacity { get; private set; }

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
            this.maxFlightDistance = maxFlightDistance;
            this.maxLoadCapacity = maxLoadCapacity;
        }

        public override string ToString()
        {
            return $"Plane( Model = {model}, MaxSpeed = {maxSpeed}, MaxFlightDistance = {maxFlightDistance}, MaxLoadCapacity = {maxLoadCapacity})";
        }

        public override bool Equals(object obj)
        {
            Plane plane = obj as Plane;
            return plane != null &&
                   model == plane.model &&
                   maxSpeed == plane.maxSpeed &&
                   maxFlightDistance == plane.maxFlightDistance &&
                   maxLoadCapacity == plane.maxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + maxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + maxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + maxLoadCapacity.GetHashCode();
            return hashCode;
        }

    }
}
