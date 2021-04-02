using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.Movimenti
{
    interface IMovement
    {
        double Importo { get; set; }
        DateTime DataMovimento { get; set; }

    }
}
