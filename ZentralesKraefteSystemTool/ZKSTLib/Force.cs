//---------------------------------------------------------------------------------------------
//-------------------------------Copyright © Benjamin Appel 2020-------------------------------
//---------------------------------------------------------------------------------------------

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
            force = Math.Round(force, 3);
            angle = Math.Round(angle, 3);

            return $"{Math.Abs(force)}N bei {Math.Abs(angle)} Grad";
        }

    }
}
