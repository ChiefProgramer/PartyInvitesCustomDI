namespace RepositoryMemory.Test
{
	using Contracts;
	using Entities;
	using FluentAssertions;
	using Xunit;

	public class TestRepositoryMemory
	{
		private GuestResponse MakeNewRecord()
		{
			GuestResponse vResult = new GuestResponse
			{
				Email = "Some@Email.com"
				, Name = "Some Name"
				, Phone = "123-4567"
				, WillAttend = true
			};
			return vResult;
		}

		[Fact]
		public void TestAdd()
		{
			// Arrange
			int vExpected = 1;
			IPartyInvitesR vRepository = new PartyInvitesR();
			int vCount = vRepository.Count();
			GuestResponse vRecord = MakeNewRecord();

			// Act
			vRepository.Add(vRecord);
			int vResult = vRepository.Count();

			// Assert
			vResult.Should().Be(vExpected);
		}

	}
}