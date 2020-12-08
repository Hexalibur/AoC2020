using System;
using System.Collections.Generic;

namespace Core2020
{
    public class Day8
    {
        public class Result
        {
            public int Accumulation { get; set; }
            public int Instruction { get; set; }
        }
        public IEnumerable<string> PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
        }

        public int TryRunGameProperly(IList<string> originalInstructions)
        {
            for (var i = 0; i < originalInstructions.Count; i++)
            {
                if (!originalInstructions[i].StartsWith("acc"))
                {
                    originalInstructions[i] = SwitchInstruction(originalInstructions[i]);

                    var result = RunGame(originalInstructions);

                    if (result.Instruction > originalInstructions.Count - 1) return result.Accumulation;

                    originalInstructions[i] = SwitchInstruction(originalInstructions[i]);
                }
            }

            return 0;
        }

        public string SwitchInstruction(string instruction)
        {
            if (instruction.StartsWith("jmp")) return instruction.Replace("jmp", "nop");
            if (instruction.StartsWith("nop")) return instruction.Replace("nop", "jmp");

            return instruction;
        }

        public Result RunGame(IList<string> instructions)
        {
            int currentAccumulation = 0;
            int currentInstruction = 0;
            var executedLines = new List<int>();

            var factory = new InstructionFactory();

            while (!executedLines.Contains(currentInstruction) && currentInstruction <= instructions.Count - 1)
            {
                executedLines.Add(currentInstruction);

                var instructionInfo = instructions[currentInstruction];
                var instruction = factory.CreateInstruction(instructionInfo);

                currentAccumulation = instruction.Accumulate(currentAccumulation);
                currentInstruction = instruction.MoveToNextInstruction(currentInstruction);
            }

            return new Result()
            {
                Accumulation = currentAccumulation,
                Instruction = currentInstruction
            };
        }

        public class InstructionFactory
        {
            public IInstruction CreateInstruction(string instruction)
            {

                if (instruction.StartsWith("nop")) return new Nop();
                if (instruction.StartsWith("acc")) return new Acc(instruction);
                if (instruction.StartsWith("jmp")) return new Jmp(instruction);

                throw new Exception($"Invalid instruction {instruction}");
            }
        }
        public interface IInstruction
        {
            int Accumulate(int currentValue);
            int MoveToNextInstruction(int currentInstruction);
        }

        public class Nop : IInstruction
        {
            public int Accumulate(int currentValue)
            {
                return currentValue;
            }

            public int MoveToNextInstruction(int currentInstruction)
            {
                return currentInstruction + 1;
            }
        }

        public class Acc : IInstruction
        {
            public int ValueIncrement { get; set; }
            public Acc(string instruction)
            {
                var infos = instruction.Split(' ');
                ValueIncrement = int.Parse(infos[1]);
            }
            public int Accumulate(int currentValue)
            {
                return currentValue + ValueIncrement;
            }

            public int MoveToNextInstruction(int currentInstruction)
            {
                return currentInstruction + 1;
            }
        }

        public class Jmp : IInstruction
        {
            public int InstructionIncrement { get; set; }
            public Jmp(string instruction)
            {
                var infos = instruction.Split(' ');
                InstructionIncrement = int.Parse(infos[1]);
            }
            public int Accumulate(int currentValue)
            {
                return currentValue;
            }

            public int MoveToNextInstruction(int currentInstruction)
            {
                return currentInstruction + InstructionIncrement;
            }
        }
    }
}
