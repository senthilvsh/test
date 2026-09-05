namespace Senthil.Comp.VirtualMachine;

public static class VirtualMachine
{
    static byte[] mem =
    {
        0x01, // Load
        0x00, // R0
        0x02, // 2
        0x01, // Load
        0x01, // R1
        0x03, // 3
        0x03, // Add
        0x00, // R0
        0x01, // R1
        0x00, // Halt
    };

    public static void Main()
    {
        byte[] R = { 0, 0 };
        byte IP = 0;
        bool running = true;
        while (running)
        {
            byte instr = mem[IP];
            switch (instr)
            {
                case 0x00:
                    IP++;
                    running = false;
                    break;
                case 0x01:
                    byte regId = mem[IP + 1];
                    byte val = mem[IP + 2];
                    R[regId] = val;
                    IP += 3;
                    break;
                case 0x03:
                    byte regId1 = mem[IP + 1];
                    byte regId2 = mem[IP + 2];
                    R[regId1] += R[regId2];
                    IP += 3;
                    break;
                default: throw new Exception("Unknown Instruction");
            }
        }

        Console.WriteLine(R[0]);
        Console.WriteLine(R[1]);
    }
}