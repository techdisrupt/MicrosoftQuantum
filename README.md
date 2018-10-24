#Introduction to Quantum Computation with Microsoft Q#

Quantum is a vast field and an area that is burgeoning. You might have seen the news about various companies from IBM to Google to Microsoft working on Quantum Computers. There is a lot of hype and a lot of noise, but there is (IMHO) a dearth of opportunities to find a decent introduction to practial quantum computing, that doesn't thrust a mass of jargon at you, assuming that you are a Quantum expert, or that wades too much into the basics of Quantum Effects from first principles. This guide aims to be somewhat in the middle, the "Goldilocks" area where there is enough of the basics to get you some understanding, but also less basics and more about building some understanding of Quantum Compting with Q#

# Qubit, lets start at the heart of Quantum Computing

The right place to start is the Qubit, because in some ways, we can explain some of the behaviour Quantum effects with Qubits in a loose hand-waving way without getting bogged down in the details of the Quantum physics and all its machinery. Later there will be guide for some of the details that have been over-looked.

Of course the name Qubit, if you hadn't already guessed, originates from the concatenation of Qu (__Qu__antum) and bit (__B__inary Dig__it__). A binary digit is a representation that has two and only two possibilities, commonly referred to as 0 and 1. 

If you prefer these could be 'on' or 'off', but could be any two states. In the mechnical sense, you could call a light switch a bit, because it has two states, 'on' and 'off'. In machine language we commonly refer to states of the bit as 0 and 1. A bit can only be 0 OR 1 at any moment in time, much the same as a light switch. There is no inbetween state.

What makes the Qubit different from the standard bit, that you find in the classical sense and in your computer is that the Qubit can take on non binary values (i.e. doesn't have to be binary), whilst the standard bit can only take on two values. 

Now we could go into all kinds of maths here, or we can simply make our lives easier and say that a Qubit is a linear combination of the state 0 and the state 1. The term superposition might mean something to you, but that is what you may call it here, there is a proportion of the Qubit in state 0 and in state 1, at the same time!

We don't explain the reasoning by which this can be useful in our computations, I'll save that for extra reading if you are interested, but, by the ability of the Qubit to take on any value, it means that we can perform computations that would take much much longer on a classical machine. Quantum Parallelism, if you like, for this computational ability to operate more effectively.

For those that must see even a little math...

Q = a |0> + b |1>

Which means our quantum state has a proportion given in state |0> as a and in state b as |1>. The coefficients a and b must normalize, this won't be discussed here.

Measuring a Qubit, we can now see the similarity between a traditional or classic bit, because whatever the internal state of the Qubit, when we measure an individual Qubit, we can only obtain a 0 or 1. Whoa! 

That's bonkers. What this etails is that when it comes to measuring the Qubit state, we cannot have any intermediary states. However we can have multiple Qubits and if we were to measure them, we can measure the proportion in state 0 and in state 1, but not at the individual Qubit level.

#Representing the Qubit in Q#

As you would expect from Microsoft's dedicated language, Q#, the Qubit forms the unit of interest that a typical programmer will focus upon. Therefore it is worth to get to grips with how Qubits are employed and used in the language. 

Let's look at example piece of code that handles a single Qubit. We cannot do much with it, but we'll learn how a Qubit is initially born, how it is measured and the operations we can perform on it. 

#Minimal code to run a Single Qubit in Q#

using (qubits = Qubit[1])
{


}


Let's explain what is happening. The using keyword essentially brings into life or instantiates variables which only exist in the code block below, the curly brances. 

Did you see how easy the syntax is for creating a qubit. We literally specify how many we want and in this case the number in the square brackets represents the number of Qubits. In this case one, a single solitarily lonely Qubit. If we wanted 2 Quibits we could simply state two in brackets. 

using (qubits = Qubit[2])

If we wanted 10 we can state 10. Within reason there is no maximum. Each Qubit is addressed like an array element, so we can address with square brackets giving us [0] or [1] for example with each addressable Qubit starting at zero

#Where to get Q# from?

As you might have guessed Q# pronounced Q sharp gets it name from another language that originated from Microsoft and that is c#, but there are other languages too in the samily vain such as F#.

You'll need the right tools to run Q# and this means installing many of the dot net dependencies, which are part of the Microsoft Framework.

#What editor can I use?

For those starting out I would recommend the Microsodt VScode product. It's longer name is Visual Studio Code. It's Free, it works on multiple platforms such as Windows, Mac and Linux. It's less fully featured then Visual Studio but also easier to handle and we want to focus on getting you running with Q# as quickly as possible. 

##Download VScode and Q# 

Follow the link to obtain the assets you need.

[Download .NET 2.0 or higher](https://www.microsoft.com/net/download)
[Download VScode](https://code.visualstudio.com/download)


Go to the shell and run

`dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.2.1809.701-preview"`

Check that you can run VScode. 

Now get the Quantum Development Kit, follow the below link, press install and 

[Install Download Quantum Development Kit](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)

#Creating a first Q# console application

Go into your terminal window or shel window and type the following, which will create a couple of files, the basis of Quantum Q# development.

`dotnet new console -lang Q# --output QubitReader` 

creates a folder named `QubitReader` and within there are two .qs files named `Driver.cs` and `Operation.cs` alongside a C# project file named `QubitReader.csproj`. If you look into the `Driver.qs` and `Operation.qs` file you'll see the following boiler plate code.

```
Driver.cs

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QubitReader
{
    class Driver
    {
        static void Main(string[] args)
        {

        }
    }
}
```

```Operation.cs

namespace QubitReader
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    operation Operation () : ()
    {
        body
        {
            
        }
    }
}
```

Looking at `Driver.cs`, we can see this is essentially the entry point to run your code. At the moment it's empty, rather akin to the traditional __C++__ or __C__ entry point for code, for example analagously below

```
int main(void)
{
return 0;
}
```


The __operation__ file is where we can perform the manipulation of the Qubits, and you'll see that there is a generic operation, with two empty brackets. This is a function that can be called anything we want, and inside the ()'s we can place both the input and output parameters, respectively, into these empty brackets. Later we'll see how we do this.

#Running the Quantum Project using VScode

Open VScode and open the QubitReader Folder that was created. You should be asked to add any dependencies if these are missing. To test these boiler plate files work, go to the Terminal tab within the IDE and execute the following:

`dotnet run`

You should find the code runs, but you likely won't get any response if everything goes to plan.

Lets now start working with a Qubit! The first thing we are going to do is write some code that can measure a Qubit and decide whether this Qubit is in the right state. Remember that the nature of quantum Qubits are basically probabilistic, and this means that whilst the Qubit can be in a superposition, when we measure it, it can only take on two possible values {0,1} or 0 or 1. 

#What does a Qubit look like? Quantum Hello World

Lets create a Qubit and see what it looks like. Change your renamed `QubitReader.qs` (was `Operations.qs`) to the following code below which will create a new namespace and operation function called `QubitR` which will measure the status of a Qubit. Simple, but the Quantum Equivalent of the "Hello World" and report this state back to us.

The result of the `M` function or `Measurement` function is to return one of two types, literally `One` and `Zero`. We could return these, but we are going examine the result and see whether we got a `One`. So compile, run the code multiple times and see what happens.

`dotnet run`

OK, looks right? Every-time we run the code, it looks we are always getting a 0. Hmmm, not very interesting. It appears we start off with a zero configuration of our Qubit and of course, we might want to check that is the case before we do something important with it. 

I want to point out there are some gotcha's here, but in the spirit of building things up gently I want you to understand some of the issues more fully later on.

```
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
                // Measure a Qubit and place the measurement into m
                let m = M (qubits[0]);

                if (m == One)
                {
                    set nOnes = nOnes + 1;
                } 
            }
            return nOnes;
        }
    }
}
```
```
Driver.cs

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
```

Now lets do something interesting with the Qubit. Lets perform a rotation or transformation and then measure. Specifically lets try a __Hadamard__ called `H`, which puts our Qubit into a supeposition of 0 and 1 states. So lets do this using the command and then measure

`H (qubit[0]);`

So now perform a Hadamard and measure

```
H (qubits[0]);
let m = M (qubits[0]);
```
And run the code again. Something interesting happens. We get the following issue:

```
Unhandled Exception: System.AggregateException: One or more errors occurred. (Released qubits are not in zero state.) ---> Microsoft.Quantum.Simulation.Simulators.Exceptions.ReleasedQubitsAreNotInZeroState: Released qubits are not in zero state.
```

What this means is that we need to release our qubits in the right way, and as the code error suggests, we should leave a qubit in the correct state. Lets do that. Add the following code before the end of the using block.

```
let c = M (qubits[0]);
if (c != Zero)
{
    X (qubits[0]);
}
```

Now when running the command line, you should see that for each run, the output could be 0 or 1. 

```
dotnet run 
0
dotnet run 
1
dotnet run 
1
dotnet run 
1
dotnet run 
0
dotnet run 
1
```


Your results are likely to be different. But there we have it. We have used 3 operations, __M__ (meaure qubit), __X__ (flip the bit from 0 to 1 and from 1 to 0) and __H__ (Hadamard) which puts the Qubit into a super position. Getting stat like this is tiresome in this way, so lets do a run and make several measurements in one go and then count the number of 0s which should be approximately half that of number of times we loop around, set at __100__, but feel free to experiment and change it.

Now we update the code as follows for 100 samples


```
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

                for (test in 1..100)
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
```

That is it. You can now see we have simulated some quantum events using Q#. Enjoy and play with the code. 

















