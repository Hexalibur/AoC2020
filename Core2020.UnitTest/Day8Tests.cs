using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day8Tests
    {
        [TestClass]
        public class TryRunGameProperly
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var instance = new Day8();
                var instructions = instance.PrepareData(@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6").ToList();

                var result = instance.TryRunGameProperly(instructions);
                result.Should().Be(8);
            }
        }

        [TestClass]
        public class RunGame
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var instance = new Day8();
                var instructions = instance.PrepareData(@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6").ToList();

                var result = instance.RunGame(instructions);
                var expected = new Day8.Result()
                {
                    Accumulation =  5,
                    Instruction = 1
                };
                result.Should().BeEquivalentTo(expected);
            }
        }

        [TestClass]
        public class InstructionFactoryTests
        {
            [TestClass]
            public class CreateInstruction
            {
                [TestMethod]
                [DataRow("acc +0", typeof(Day8.Acc))]
                [DataRow("nop +1", typeof(Day8.Nop))]
                [DataRow("jmp -1", typeof(Day8.Jmp))]
                public void When_AnyInstruction_Expect_InstructionCreated(string instruction, Type expected)
                {
                    var instance = new Day8.InstructionFactory();
                    
                    var result = instance.CreateInstruction(instruction);
                    result.Should().BeOfType(expected);
                }
                
                [TestMethod]
                public void When_AnyWrongInstruction_Expect_Exception()
                {
                    var instruction = "any +0";
                    var instance = new Day8.InstructionFactory();
                    
                    Action act = () => instance.CreateInstruction(instruction);
                    act.Should().Throw<Exception>().Which.Message.Should().Contain(instruction);
                }
            }
        }

        [TestClass]
        public class NopTests
        {
            [TestClass]
            public class Accumulate
            {
                [TestMethod]
                public void When_AnyInstruction_Expect_AccumulateReturnSameValue()
                {
                    var currentAccumulation = 0;

                    var instance = new Day8.Nop();
                    var result = instance.Accumulate(currentAccumulation);
                    result.Should().Be(0);
                }

                [TestMethod]
                public void When_AnyInstruction_Expect_MoveToNextInstructionReturnIncrementOfOne()
                {
                    var currentInstruction = 0;

                    var instance = new Day8.Nop();
                    var result = instance.MoveToNextInstruction(currentInstruction);
                    result.Should().Be(1);
                }
            }
        }

        [TestClass]
        public class AccTests
        {
            [TestClass]
            public class Accumulate
            {
                [TestMethod]
                [DataRow("acc +0", 0)]
                [DataRow("acc +1", 1)]
                [DataRow("acc -1", -1)]
                public void When_AnyInstruction_Expect_AccumulateReturnSameValue(string instruction, int expected)
                {
                    var currentAccumulation = 0;

                    var instance = new Day8.Acc(instruction);
                    var result = instance.Accumulate(currentAccumulation);
                    result.Should().Be(expected);
                }

                [TestMethod]
                [DataRow("acc +0", 1)]
                [DataRow("acc +1", 1)]
                [DataRow("acc -1", 1)]
                public void When_AnyInstruction_Expect_MoveToNextInstructionReturnIncrementOfOne(string instruction, int expected)
                {
                    var currentInstruction = 0;

                    var instance = new Day8.Acc(instruction);
                    var result = instance.MoveToNextInstruction(currentInstruction);
                    result.Should().Be(expected);
                }
            }
        }

        [TestClass]
        public class JmpTests
        {
            [TestClass]
            public class Accumulate
            {
                [TestMethod]
                [DataRow("jmp +0", 0)]
                [DataRow("jmp +1", 0)]
                [DataRow("jmp -1", 0)]
                public void When_AnyInstruction_Expect_AccumulateReturnSameValue(string instruction, int expected)
                {
                    var currentAccumulation = 0;

                    var instance = new Day8.Jmp(instruction);
                    var result = instance.Accumulate(currentAccumulation);
                    result.Should().Be(expected);
                }

                [TestMethod]
                [DataRow("jmp +0", 0)]
                [DataRow("jmp +1", 1)]
                [DataRow("jmp -1", -1)]
                public void When_AnyInstruction_Expect_MoveToNextInstructionReturnIncrementOfOne(string instruction, int expected)
                {
                    var currentInstruction = 0;

                    var instance = new Day8.Jmp(instruction);
                    var result = instance.MoveToNextInstruction(currentInstruction);
                    result.Should().Be(expected);
                }
            }
        }
    }
}
