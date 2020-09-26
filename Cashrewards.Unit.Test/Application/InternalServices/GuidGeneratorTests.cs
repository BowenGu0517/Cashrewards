using Cashrewards.Application.InternalServices;
using FluentAssertions;
using System;
using Xunit;

namespace Cashrewards.Unit.Test.Application.InternalServices
{
    public class GuidGeneratorTests
    {
        private readonly GuidGenerator _guidGenerator;
        public GuidGeneratorTests()
        {
            _guidGenerator = new GuidGenerator();
        }

        [Fact]
        public void ShouldGenerateGuidCorrectly()
        {
            var result = _guidGenerator.Generate();

            Guid.TryParse(result, out _).Should().BeTrue();
        }
    }
}
