using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trafficLight
{
    internal class TrafficLight
    {
        public enum Status { Off, Red, RedYellow, Green, Yellow }
        public Status status = Status.Off;
        public TrafficLight() { }
        public Color UpdateLights(int timer)
        {
            switch (timer)
            {

                case 0:
                    if (status == Status.Off || status == Status.Yellow)
                    {
                        status = Status.Red;
                        return Colors.Red;
                    }
                    break;
                case 10:
                    if (status == Status.Red)
                    {
                        status = Status.RedYellow;
                        return Colors.Orange;
                    }
                    break;
                case 12:
                    if (status == Status.RedYellow)
                    {
                        status = Status.Green;
                        return Colors.Green;
                    }
                    break;
                case 22:
                    if (status == Status.Green)
                    {
                        status = Status.Yellow;
                        return Colors.Yellow;
                    }
                    break;
                
                    
                    
            }
            return Colors.Gray;
        }
    }
}
