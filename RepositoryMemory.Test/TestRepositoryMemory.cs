namespace RepositoryMemory.Test
{
    using Contracts;
    using Entities;
    using FluentAssertions;
    using Xunit;

    public class TestRepositoryMemory
    {
        private Guest MakeNewRecord()
        {
            Guest vResult = new Guest
            {
                Email = "Some@Email.com"
                ,
                Name = "Some Name"
                ,
                Phone = "123-4567"
                ,
                WillAttend = true
            };
            return vResult;
        }

        [Fact]
        public void TestAdd()
        {
            // Arrange
            int vExpected = 1;
            IGuestR vRepository = new GuestRepositoryMemory();
            int vCount = vRepository.Count();
            Guest vRecord = MakeNewRecord();

            // Act
            vRepository.Add(vRecord);
            int vResult = vRepository.Count();

            // Assert
            vResult.Should().Be(vExpected);
        }

    }
}