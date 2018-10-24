using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using QubitReaderOperation;

namespace QubitDriver
{
    class Driver
    {
        static void Main(string[] args)
        {

            using (var sim = new QuantumSimulator())
            {

                var r = QubitR.Run(sim).Result;
                System.Console.WriteLine(r);
            }
        }
    }
}