using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day10Tests
    {
        [TestClass]
        public class GetDifferenceProduct
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            { 
                var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
                var instance = new Core2020.Day10();
                var list = instance.PrepareData(input);
                var result = instance.GetDifferenceProduct(list);
                result.Should().Be(22 * 10);
            }
        }

        [TestClass]
        public class GetNumberOfWays
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            { 
                var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
                var instance = new Core2020.Day10();
                var list = instance.PrepareData(input);
                var result = instance.GetNumberOfWays(list);
                result.Should().Be(19208);
            }
        }
    }
}
