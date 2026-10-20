using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Interface for flying animals, garuntees a flightpattern function call
    public interface ICanFly
    {
        string FlightPattern();
    }
}
