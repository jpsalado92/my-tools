# Introducing C# and . NET
- [Introducing C# and . NET](#introducing-c-and--net)
  - [Terms](#terms)
  - [CLI support](#cli-support)
  - [Setting up a project with multiple apps](#setting-up-a-project-with-multiple-apps)
  - [Example 1: Console application that gets and represents input (source)](#example-1-console-application-that-gets-and-represents-input-source)

## Terms

* **. NET** is a development framework that is used to build applications in Windows machines through its CLR (Common language runtime) and FCL (Framework Class Library).

* **. NET Core** is an open source . NET version that works in multiple platforms.

* **C#** is one of the languages in which applications are written in the . NET framework.

## CLI support

```powershell
dotnet --info  # To know more about your running .NET installation
dotnet --help  # List available SDK commands
dotnet new <template> # Create a new .NET project or file based on a template
dotnet restore # Restore dependencies specified in a .NET project.
dotnet build  # Builds a .NET project to produce a single compiled .dll binary file (assembly) that the computer is able to execute efficiently
dotnet run  # This command implicitly performs a dotnet "restore" and then a "build"
```

## Setting up a project with multiple apps

A common structure, for a project that has multiple sub-projects (apps), has the following look.

```powershell
PS> mkdir ReferenceProject
PS> cd ReferenceProject
PS> mkdir src
PS> mkdir test
PS> cd src
PS> dotnet new console -o GradeBook
PS> tree

ReferenceProject
├───src
│   └───GradeBook
│       ├───obj
│       ├───GradeBook.csproj
│       └───Program.cs
└───test
```   

Now, from the `GradeBook` directory, we can run the first application inside our project.

```powershell
PS> dotnet run
Hello, World!
```

After running the last command, a new `bin` folder appears in the project structure containing all the compiled resources.

```
ReferenceProject
├───src
│   └───GradeBook
│       ├───bin
│       ├───obj
│       ├───GradeBook.csproj
│       └───Program.cs
└───test
```
> Note that you can remove both the `obj` and `bin` directories, as they can be re-generated every time the project is build. The important files are the **source code** and the **.csproj file**.

## Example 1: Console application that gets and represents input [(source)](examples/01_console_input.cs)

```cs
using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // String concatenation way
                Console.WriteLine("Hello " + args[0] + "!");
                // String interpolation way
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
```

**Key takeaways:**
* When running a console application, it looks for the `Main` method, which will then by executed.
* The `args` word inside the Main function is a parameter, and it is defined as **string array** as the `string[]` word indicates.
* C# has zero-base indexing, so in every array, the first element is considered to be the one in position `0`.
* If you are using VS code to run the project, you can use the `launch.json` file under the `.vscode` folder to modify the arguments passed while debugging.
* In order to run apps with parameters, one way is to add two dashes between the call and the arguments as:

```powershell
dotnet run -- arg1 arg2
```
