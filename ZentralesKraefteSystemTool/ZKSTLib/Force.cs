using System;

namespace ZKSTLib
{
    public struct Force
    {
        public double force, angle;

        public Force(double force, double angle)
        {
            this.force = force;
            this.angle = angle;
        }

        public override string ToString()
        {
            return $"{force}N at {angle} Degrees";
        }

    }
}
