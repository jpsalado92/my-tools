# Syntax

## Variable initialization.

### Explicit or Implicit

```csharp
// Implicitly sets the variable type based on the context
var x = 34.1;
// Explicitly sets the variable type
double x = 34.1;
```

### Arrays

```csharp
// Arcaic way
double[] numbers = new double[3];
numbers[0] = 12.7;
numbers[1] = 10.3;
numbers[2] = 6.11;

// Initialization sintax
var numbers = new[] {12.7, 10.3, 6.11};

```

## Loops

### foreach

```csharp
var numbers = new[] { 12.7, 10.3, 6.11 };
var result = 0.0;
foreach (double number in numbers)
{
    result += number;
}
```

## Example 2: External references [(source)](examples/02_external_ref.cs)

```csharp
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Explicit init
            List<double> grades = new List<double>();
            // Implicit init
            var grades = new List<double>();
            grades.Add(1.3);
            grades[0];
            // Implicit init with content
            var grades = new List<double>() { 12.7, 10.3, 6.11 };

            var result = 0.0;
            foreach (double number in numbers)
            {
                result += number;
            }
            var average = 0.0;
            average = result / grades.Count;
            Console.WriteLine($"The average grade us {average:N2}");
        }
    }
}
```

**Key takeaways:**
* Some classes and types require additional information on how you are using that type. Here, in order to use the List class, we have to specify a **type argument**, in this case, a double.
* The number of decimal numbers to show when printing to the console can be adjusted using `:NX` where X is a number.