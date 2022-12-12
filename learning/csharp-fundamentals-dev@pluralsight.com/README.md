Classes allow new types definition.

Type definitions members:
* Fields
* Methods
* Events

**Overloaded methods**

Multiple methods using the same name within the same type definition.

> **Method signature**: Unique identifier inside a type definition composed of the method name and the number and type of its parameters (the return type is not part of it). This opens the door to **overloaded methods**.

**Properties**

Similar to a field, as it can encapsulate "state" or "data" for an object, but with Set/Get methods to alter the now private field of the object.

Example:

```csharp
public string Name
{
    get
    {
        return name;
    }
    set
    {
        name = value;
    }
}
private string name;
```

For simple cases, you can use **auto-properties**, they look like this:

```csharp
public string Name
{
    get; set;
}
```

A reason to use properties instead of fields is that one can, for example, make the set private, so that would not be able to be modified from outside the scope of the type itself.

```csharp
public string Name
{
    get;
    private set;
}
```

**Readonly**

Fields that can only be setup in a constructor or a variable initializer. Implementations could be as in this example:

```csharp
public class Book
{
    public Book(string category)
    {
        readonly string category = category;
    }
}
```

Or this other.

```csharp
public class Book
{
    readonly string category = category;
}
```

It is a way to set some fields for an object that won't change once it has been initialized.

**Const**

Fields that are never changed. Conventionally written in uppercase. Makes sense to declare them as static fields.

> Static members cannot be accessed via an object reference they are accessed by using the type name. 

```csharp
const string CATEGORY = "Science";
```

**Delegates**



Delegates describe and build a new type for . NET.

Delegates are different to class definitions or struct definitions.

A delegate is a variable that can point to and invoke different methods. Delegates can only point to specific methods with a given structure that establishes specific inputs, returns.

Imagine a delegate that points to different kind of loggers. They all share the same structure but ultimately, they perform different operations. One might write to a file, another to console, etc.



```csharp
using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log = ReturnMessage;
            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }
    }
}
```

```csharp
using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello!");
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
    }
}
```


**Events**

Events are popular in forms and desktop programming.

Events in C# are build on top of what is known as **delegates**.

Events are useful when there are components of our application that need to know when some others are modified/updated. 

TODO WRITE AN EVENT

TODO ABSTRACT

TODO INTERFACES