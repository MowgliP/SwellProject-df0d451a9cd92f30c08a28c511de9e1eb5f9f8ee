using System;
using Xunit;

namespace RazorPagesTermTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var actual = GetIntFromString("32");

            //Act
            var expected = 32;

            //Assert
            Assert.Equal(expected, actual);
        
        }
    }
}
