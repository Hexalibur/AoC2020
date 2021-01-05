using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2015
{
    public class Day7
    {

        public interface IInstruction
        {
            void Run(Dictionary<string, int> wires);
        }

        public class SignalInstruction : IInstruction
        {
            public string Wire { get; set; }
            public int Value { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[Wire] = Value;
            }

            public static SignalInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                return new SignalInstruction()
                {
                    Wire = parts[1],
                    Value = int.Parse(parts[0])
                };
            }
        }

        public class BitwiseAndInstruction : IInstruction
        {
            public string WireDestination { get; set; }
            public string WireLeft { get; set; }
            public string WireRight { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[WireDestination] = wires[WireLeft] & wires[WireRight];
            }

            public static BitwiseAndInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                var each = parts[0].Replace(" AND ", ";").Split(';');

                return new BitwiseAndInstruction()
                {
                    WireDestination = parts[1],
                    WireLeft = each[0],
                    WireRight = each[1]
                };
            }
        }

        public class BitwiseOrInstruction : IInstruction
        {
            public string WireDestination { get; set; }
            public string WireLeft { get; set; }
            public string WireRight { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[WireDestination] = wires[WireLeft] ^ wires[WireRight];
            }

            public static BitwiseOrInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                var each = parts[0].Replace(" OR ", ";").Split(';');

                return new BitwiseOrInstruction()
                {
                    WireDestination = parts[1],
                    WireLeft = each[0],
                    WireRight = each[1]
                };
            }
        }

        public class BitwiseLShiftInstruction : IInstruction
        {
            public string WireDestination { get; set; }
            public string Wire { get; set; }
            public int Value { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[WireDestination] = wires[Wire] << Value;
            }

            public static BitwiseLShiftInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                var each = parts[0].Replace(" LSHIFT ", ";").Split(';');

                return new BitwiseLShiftInstruction()
                {
                    WireDestination = parts[1],
                    Wire = each[0],
                    Value = int.Parse(each[1])
                };
            }
        }

        public class BitwiseRShiftInstruction : IInstruction
        {
            public string WireDestination { get; set; }
            public string Wire { get; set; }
            public int Value { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[WireDestination] = wires[Wire] >> Value;
            }

            public static BitwiseRShiftInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                var each = parts[0].Replace(" RSHIFT ", ";").Split(';');

                return new BitwiseRShiftInstruction()
                {
                    WireDestination = parts[1],
                    Wire = each[0],
                    Value = int.Parse(each[1])
                };
            }
        }
        public class BitwiseNotInstruction : IInstruction
        {
            public string WireDestination { get; set; }
            public string Wire { get; set; }
            public void Run(Dictionary<string, int> wires)
            {
                wires[WireDestination] = ~wires[Wire];
            }

            public static BitwiseRShiftInstruction Create(string input)
            {
                var parts = input.Replace(" -> ", ";").Split(';');

                var wire = parts[0].Replace("NOT ", "");

                return new BitwiseRShiftInstruction()
                {
                    WireDestination = parts[1],
                    Wire = wire,
                };
            }
        }

        public class InstructionFactory
        {
            public IInstruction Create(string input)
            {

                var parts = input.Replace(" -> ", ";").Split(';');

                var type = "Signal";
                if (parts.Contains("AND")) return BitwiseAndInstruction.Create(input);
                if (parts.Contains("OR")) return BitwiseOrInstruction.Create(input);
                if (parts.Contains("LSHIFT")) return BitwiseLShiftInstruction.Create(input);
                if (parts.Contains("RSHIFT")) return BitwiseRShiftInstruction.Create(input);
                if (parts.Contains("NOT")) type = "Not";

                return SignalInstruction.Create(input);
            }
        }
        public List<IInstruction> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            var factory = new InstructionFactory();

            return list.Select(factory.Create).ToList();
        }

        public int GetSignalProvidedToWire(List<IInstruction> data, string wire)
        {
            var wires = new Dictionary<string, int>();

            data.ForEach(x => x.Run(wires));

            return wires[wire];
        }

        public object DoSomethingElse(object data)
        {
            return 0;
        }
    }
}

