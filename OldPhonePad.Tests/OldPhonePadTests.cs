using Xunit;
using OldPhonePad;

namespace OldPhonePad.Tests
{
    public class OldPhonePadTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        [InlineData("2 22 222#", "ABC")]
        [InlineData("*#", "")] // test backspace on empty
        [InlineData("2222#", "A")] // test wraparound on 4th press
        public void OldPhonePad_ReturnsExpectedOutput(string input, string expected)
        {
            var result = Program.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A#")]
        [InlineData("2A2#")]
        [InlineData("2-2#")]
        public void OldPhonePad_InvalidCharacters_ThrowsException(string input)
        {
            Assert.Throws<ArgumentException>(() => Program.OldPhonePad(input));
        }
    }
}