using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day14
    {
        public List<string> PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();
        }

        public long GetSumOfAllValuesLeft(List<string> data, Mask.MaskApplication application)
        {
            var mask = Mask.Create(data.First());
            var values = new Dictionary<long, long>();

            foreach (var instruction in data)
            {
                if (instruction.StartsWith("mask = ")) mask = Mask.Create(instruction);
                if (instruction.StartsWith("mem"))
                {
                    var mem = Mem.Create(instruction);

                    switch (application)
                    {
                        case Mask.MaskApplication.Address:
                            foreach (var address in mask.ApplyMaskOnAddress(mem))
                            {
                            
                                values[address] = mem.Value;
                            }
                            break;
                        case Mask.MaskApplication.Value:
                            values[mem.Address] = mask.ApplyMaskOnValue(mem.Value);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(application), application, null);
                    }
                }

            }

            return values.Values.Sum();
        }

        public class Mask
        {
            private string MaskValue { get; set; }

            private static readonly char[] BitPossibilities = new[] {'0','1'};

            public enum MaskApplication
            {
                Address,
                Value
            }

            public static Mask Create(string input)
            {
                return new Mask()
                {
                    MaskValue = input.Replace("mask = ", "").Trim(),
                };
            }

            public List<long> ApplyMaskOnAddress(Mem value)
            {
                var binary = Convert.ToString(value.Address, 2).PadLeft(36, '0').ToCharArray();

                for (var i = 35; i >= 0; i--)
                {
                    switch (MaskValue[i])
                    {
                        case '0':
                            binary[i] = binary[i];
                            break;
                        case '1':
                            binary[i] = '1';
                            break;
                        case 'X':
                            binary[i] = 'X';
                            break;
                    }
                }
                
                var addresses = ComputeAddresses(binary);

                return addresses;
            }

            public List<long> ComputeAddresses(char[] binary)
            {
                var list = new List<long>();
                if (binary.All(x => x != 'X'))
                {
                    list.Add((Convert.ToInt64(new string(binary), 2)));
                }
                else
                {
                    var indexOfNextX = Array.IndexOf(binary, 'X');

                    foreach (var possibility in BitPossibilities)
                    {
                        var array = (char[])binary.Clone();
                        array[indexOfNextX] = possibility;
                        list.AddRange( ComputeAddresses(array));                        
                    }
                }

                return list;
            }

            public long ApplyMaskOnValue(long value)
            {
                var binary = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();

                for (var i = 35; i >= 0; i--)
                {
                    if (MaskValue[i] != 'X') binary[i] = MaskValue[i];
                }

                return Convert.ToInt64(new string(binary), 2);
            }
        }

        public class Mem
        {
            public int Address { get; set; }
            public long Value { get; set; }

            public static Mem Create(string input)
            {
                var firstIndex = input.IndexOf('[') + 1;
                var secondIndex = input.IndexOf(']');

                var address = int.Parse(input.Substring(firstIndex, secondIndex - firstIndex));

                return new Mem()
                {
                    Address = address,
                    Value = long.Parse(input.Replace($"mem[{address}] =", "").Trim())
                };
            }
        }
    }
}

