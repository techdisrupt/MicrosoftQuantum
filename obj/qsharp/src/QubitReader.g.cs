#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("QubitReaderOperation", "QubitR () : Int", new string[] { }, "/Users/brett/MQ/QubitReader/QubitReader.qs", 148L, 7L, 5L)]
#line hidden
namespace QubitReaderOperation
{
    public class QubitR : Operation<QVoid, Int64>, ICallable
    {
        public QubitR(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "QubitR";
        String ICallable.FullName => "QubitReaderOperation.QubitR";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<QVoid, Int64> Body => (__in) =>
        {
#line 10 "/Users/brett/MQ/QubitReader/QubitReader.qs"
            var nOnes = 0L;
#line 11 "/Users/brett/MQ/QubitReader/QubitReader.qs"
            var qubits = Allocate.Apply(1L);
#line 14 "/Users/brett/MQ/QubitReader/QubitReader.qs"
            foreach (var test in new Range(1L, 100000L))
            {
                // Measure a qubit and place the measurement into m
#line 17 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 18 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                var m = M.Apply(qubits[0L]);
#line 20 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                if ((m == Result.One))
                {
#line 22 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                    nOnes = (nOnes + 1L);
                }

                // Flip our state to zero 
#line 25 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                var c = M.Apply(qubits[0L]);
#line 26 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                if ((c != Result.Zero))
                {
#line 28 "/Users/brett/MQ/QubitReader/QubitReader.qs"
                    MicrosoftQuantumPrimitiveX.Apply(qubits[0L]);
                }
            }

#line hidden
            Release.Apply(qubits);
#line 32 "/Users/brett/MQ/QubitReader/QubitReader.qs"
            return nOnes;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn(QVoid data) => data;
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__)
        {
            return __m__.Run<QubitR, QVoid, Int64>(QVoid.Instance);
        }
    }
}