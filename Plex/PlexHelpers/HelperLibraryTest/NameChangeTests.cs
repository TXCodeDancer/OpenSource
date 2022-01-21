using System.Collections.Generic;
using Xunit;

namespace HelperLibraryTest
{
    public class NameChangeTests
    {
        public static IEnumerable<object[]> GetNames()
        {
            yield return new object[] { "Star Trek - s02e02 Who Mourns for Adonais_.mp4", "Star.Trek.s02e02.Who.Mourns.for.Adonais.mp4" };
        }

        [Theory]
        [MemberData(nameof(GetNames))]
        public void ConvertSpacesToDots(string input, string expected)
        {
            Assert.Equal(expected, input);
        }
    }
}
