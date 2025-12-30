using System;
using System.Runtime.CompilerServices;

namespace Nemonuri.UnsafeUnboxTest;

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