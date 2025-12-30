# `Unsafe.Unbox` Document is WRONG

## Content

Official API Docment of [Unsafe.Unbox\<T\>(Object)](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafe.unbox?view=net-10.0) Method says,

```csharp
// The following line is NOT SUPPORTED.
Unsafe.Unbox<int>(obj) = 30;
```

```csharp
// Resetting the reference to default(T) is NOT SUPPORTED.
Unsafe.Unbox<System.Drawing.Point>(obj) = default(System.Drawing.Point);

// Setting the reference to a completely new value is NOT SUPPORTED.
Unsafe.Unbox<System.Drawing.Point>(obj) = new System.Drawing.Point(50, 70);
```

But, In my test, these counterexamples work so well.

### Part of test code ([link](Nemonuri.UnsafeUnboxTest/Program.cs))

```csharp
public readonly struct MyStruct(int x, int y)
{
    public readonly int X = x, Y = y;

    public override string ToString() => $"X = {X}, Y = {Y}";
}

public class Program
{
    public static void Main()
    {
        // Program 1
        int v1 = 1;
        object o1 = v1;
        Unsafe.Unbox<int>(o1) = 2;
        Console.WriteLine("[Program 1]");
        Console.WriteLine(o1);

        Console.WriteLine();

        // Program 2
        MyStruct s1 = new(1, 2);
        object o2 = s1;
        Unsafe.Unbox<MyStruct>(o2) = new(3,4);
        Console.WriteLine("[Program 2]");
        Console.WriteLine(o2);
    }
}
```

### Output

- TargetFramework: net10.0
```
[Program 1]
2

[Program 2]
X = 3, Y = 4
```

- TargetFramework: net462
```
[Program 1]
2

[Program 2]
X = 3, Y = 4
```

What is the problem?

Am I missing something?

## How to run test?

### Prerequisite

1. .NET SDK 10
2. Windows OS, supports `.NetFramework v4.6.2` and PowerSehll

### How to

1. Run `run.ps1`
