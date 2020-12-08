using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core2020
{
    public class Day4
    {

        public string[] PrepareData(string raw)
        {
            var input = raw;

            input = input.Replace("\r\n", ";");
            input = input.Replace(";;", "/");
            input = input.Replace(" ", ";");

            return input.Split('/');
        }
        public int ValidatePassports(IEnumerable<string> passports, bool onlyMandatory)
        {
            var passportList = passports.Select(p => new Passport(p));

            return passportList.Count(p => p.IsValid(onlyMandatory));
        }

        public class Passport
        {
            
            public readonly string[] mandatory = new[]
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"/*,
            "cid"*/
            };

            public readonly Dictionary<string, bool> infos = new Dictionary<string, bool>();
            public Passport(string value)
            {
                var list = value.Split(';');
                var factory = new PassportInfoFactory();
                foreach (var info in list)
                {
                    var items = info.Split(':');
                    infos.Add(items[0], factory.CreateInfo(info).IsValid(items[1]));
                }
            }

            public bool IsValid(bool onlyMandatory)
            {
                var valid= mandatory.All(m => infos.ContainsKey(m));

                if (onlyMandatory) return valid;

                return valid && infos.All(b => b.Value);
            }
        }

        public interface IPassportInfo
        {
            bool IsValid(string value);
        }

        public class PassportInfoFactory
        {
            public IPassportInfo CreateInfo(string info)
            {
                var items = info.Split(':');

                switch (items[0].Trim())
                {
                    case "byr": return new Byr();
                    case "iyr": return new Iyr();
                    case "eyr": return new Eyr();
                    case "hgt": return new Hgt();
                    case "hcl": return new Hcl();
                    case "ecl": return new Ecl();
                    case "pid": return new Pid();
                    case "cid": return new Cid();
                }

                return new Inv();
            }
        }

        public class Byr : IPassportInfo
        {
            public bool IsValid(string value)
            {
                if (int.TryParse(value, out var result))
                {
                    return result >= 1920 && result <= 2002;
                }

                return false;
            }
        }

        public class Iyr : IPassportInfo
        {
            public bool IsValid(string value)
            {
                if (int.TryParse(value, out var result))
                {
                    return result >= 2010 && result <= 2020;
                }

                return false;
            }
        }

        public class Eyr : IPassportInfo
        {
            public bool IsValid(string value)
            {
                if (int.TryParse(value, out var result))
                {
                    return result >= 2020 && result <= 2030;
                }

                return false;
            }
        }

        public class Hgt : IPassportInfo
        {
            public bool IsValid(string value)
            {
                if (value.Trim().EndsWith("cm")) return ValidateCm(value);
                if (value.Trim().EndsWith("in")) return ValidateIn(value);
                
                return false;
            }

            public bool ValidateCm(string value)
            {
                if (int.TryParse(value.Trim().Replace("cm", ""), out var result))
                {
                    return result >= 150 && result <= 193;
                }

                return false;
            }

            public bool ValidateIn(string value)
            {
                if (int.TryParse(value.Trim().Replace("in", ""), out var result))
                {
                    return result >= 59 && result <= 76;
                }

                return false;
            }
        }

        public class Hcl : IPassportInfo
        {
            public bool IsValid(string value)
            {
                return Regex.IsMatch(value.Trim(), @"^#[0-9a-f]{6}");
            }
        }

        public class Ecl : IPassportInfo
        {
            public readonly string[] listValue = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            public bool IsValid(string value)
            {
                return listValue.Any(x => x == value.Trim());
            }
        }

        public class Pid : IPassportInfo
        {
            public bool IsValid(string value)
            {
                return value.Trim().Length == 9 && int.TryParse(value.Trim(), out var result);
            }
        }

        public class Cid : IPassportInfo
        {
            public bool IsValid(string value)
            {
                return true;
            }
        }

        public class Inv : IPassportInfo
        {
            public bool IsValid(string value)
            {
                return true;
            }
        }
    }
}
