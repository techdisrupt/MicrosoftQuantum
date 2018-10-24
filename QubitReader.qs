namespace QubitReaderOperation
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    operation QubitR () : (Int)
    {
        body
        {
            mutable nOnes = 0;
            using (qubits = Qubit[1])
            {

                for (test in 1..100000)
                {
                    // Measure a qubit and place the measurement into m
                    H (qubits[0]);
                    let m = M (qubits[0]);

                    if (m == One)
                    {
                        set nOnes = nOnes + 1;
                    } 
                    // Flip our state to zero 
                    let c = M (qubits[0]);
                    if (c != Zero)
                    {
                        X (qubits[0]);
                    }
                }
            }
            return nOnes;
        }
    }
}
