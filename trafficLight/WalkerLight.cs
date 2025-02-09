using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trafficLight
{
    internal class WalkerLight
    {
        public enum Status { Green, Red, None}
        public Status status = Status.None;
        public Color UpdateLight(int timer)
        {
            switch (timer)
            {
                case 0:
                    if (status == Status.Green)
                    {
                        status = Status.Red;
                        return Colors.Red;
                    }
                    break;
                case 12:
                    if (status == Status.Red)
                    {
                        status = Status.Green;
                        return Colors.Green;
                    }
                    break;
            }
            return Colors.Gray;
        }
    }
}
