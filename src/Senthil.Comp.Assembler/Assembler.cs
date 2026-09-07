namespace Senthil.Comp.Assembler;

using Senthil.Comp.Shared;

public static class Assembler
{
    public static void Main()
    {
        Console.WriteLine((byte)OpCode.HLT);
        Console.WriteLine((byte)OpCode.ADD);
        Console.WriteLine((byte)OpCode.SUB);
    }
}