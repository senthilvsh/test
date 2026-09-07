namespace Senthil.Comp.VirtualMachine;

public static class VirtualMachine
{
    private static byte[] _mem =
    {
        0x01, // Load
        0x00, // R0
        0x02, // 2
        0x01, // Load
        0x01, // R1
        0x03, // 3
        0x04, // Add
        0x00, // R0
        0x01, // R1
        0x00, // Halt
    };

    private static byte[] _r = { 0, 0 };
    private static byte _ip = 0;
    private static bool _running = true;

    public static void Main()
    {
        while (_running)
        {
            var instr = _mem[_ip];
            switch (instr)
            {
                case 0x00: Halt(); break;
                case 0x01: Load(); break;
                case 0x03: Add(); break;
                default: throw new Exception("Unknown OPCODE at location: " + _ip);
            }
        }

        Console.WriteLine(_r[0]);
        Console.WriteLine(_r[1]);
    }

    private static void Halt()
    {
        _ip++;
        _running = false;
    }

    private static void Load()
    {
        var regId = _mem[_ip + 1];
        var val = _mem[_ip + 2];
        _r[regId] = val;
        _ip += 3;
    }

    private static void Add()
    {
        var regId1 = _mem[_ip + 1];
        var regId2 = _mem[_ip + 2];
        _r[regId1] += _r[regId2];
        _ip += 3;
    }
}