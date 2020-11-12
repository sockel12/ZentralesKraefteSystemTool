using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKSTLib
{
    public class ZentralesKraefteSystem
    {
        public Force force1, force2, force3;
        private double angle2, angle3;

        public ZentralesKraefteSystem(Force f1, double angle2, double angle3)
        {
            this.force1 = f1;
            this.angle2 = angle2;
            this.angle3 = angle3;
        }

        public void Berechnen()
        {
            double f1x, f1y;
            double f2x, f2y;
            double f3x, f3y;
            bool onlyForce2X;
            double angleTurn;
            //1: Winkel2 zu 0(360) drehen; 2: Winkel2 zu 180 drehen; 3: Winkel3 zu 0(360) drehen; 4: Winkel3 zu 180 drehen
            double[] systemAngle = CalcSystemAngle();
            angleTurn = systemAngle[1];
            if(systemAngle[0] < 3)
            {
                onlyForce2X = false;
            }
            else
            {
                onlyForce2X = true;
            }
            Console.WriteLine(angleTurn);
            Console.WriteLine($"{force1.angle + angleTurn}");
            Console.WriteLine($"{angle2 + angleTurn}");
            Console.WriteLine($"{angle3 + angleTurn}");

            f1x = force1.force * Math.Cos((Math.PI / 180) * (force1.angle + angleTurn));
            f1y = force1.force * Math.Sin((Math.PI / 180) * (force1.angle + angleTurn));

            if (!onlyForce2X)
            {
                
                f3y = -(f1y);
                force3 = new Force(f3y / Math.Sin((Math.PI / 180) * (angle3 + angleTurn)), angle3);
                f3x = force3.force * Math.Cos((Math.PI / 180) * (angle3 + angleTurn));
                force2 = new Force(-f3x -f1x, angle2);
            }
            else
            {
                f2y = -(f1y);
                force2 = new Force(f2y / Math.Sin((Math.PI / 180) * (angle2 + angleTurn)), angle2);
                f2x = force2.force * Math.Cos((Math.PI / 180) * (angle2 + angleTurn));
                force3 = new Force(-f2x - f1x, angle3);
            }

        }

        private double[] CalcSystemAngle()
        {
            double caseA;            
            double caseB;
            double caseC;
            double caseD;
            double smallest;
            int id = 1;
            double[] returnValue = new double[2];

            if (angle2 > 180)
            {
                caseA = 360.0 - angle2;
            }
            else if (angle2 < 180)
            {
                caseA = 0 - angle2;
            }
            else
            {
                caseA = 0;
            }
            caseB = 180 - angle2;

            if (angle3 > 180)
            {
                caseC = 360.0 - angle3;
            }
            else if (angle3 < 180)
            {
                caseC = 0 - angle3;
            }
            else
            {
                caseC = 0;
            }
            caseD = 180 - angle3;

            smallest = Math.Abs(caseA);
            if (Math.Abs(caseB) < smallest)
            {
                smallest = caseB;
                id = 2;
            }
            if (Math.Abs(caseC) < smallest)
            {
                smallest = caseC;
                id = 3;
            }
            if (Math.Abs(caseD) < smallest)
            {
                smallest = caseD;
                id = 4;
            }

            switch (id)
            {
                case 1:
                    returnValue[0] = 1;
                    returnValue[1] = caseA;
                    return returnValue;
                case 2:
                    returnValue[0] = 2;
                    returnValue[1] = caseB;
                    return returnValue;
                case 3:
                    returnValue[0] = 3;
                    returnValue[1] = caseC;
                    return returnValue;
                default:
                    returnValue[0] = 4;
                    returnValue[1] = caseD;
                    return returnValue;
            }
        }

    }
}
