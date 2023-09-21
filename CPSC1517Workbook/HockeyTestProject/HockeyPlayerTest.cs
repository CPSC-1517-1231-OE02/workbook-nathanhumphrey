using FluentAssertions;
using Hockey.Data;
using System.Collections;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        // Constants for a test player
        const string FirstName = "Connor";
        const string LastName = "Brown";
        const string BirthPlace = "Toronto, ON, CAN";
        const int HeightInInches = 72;
        const int WeightInPounds = 188;
        const int JerseyNumber = 28;
        const Position PlayerPosition = Position.Center;
        const Shot PlayerShot = Shot.Left;
        static readonly DateOnly DateOfBirth = new DateOnly(1994, 01, 14);
        const string ToStringValue = $"{FirstName} {LastName}";
        readonly int Age = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        //[Fact]
        //public void Age_IsCorrect()
        //{
        //    Age.Should().Be(29);
        //}

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds,
                HeightInInches, JerseyNumber, PlayerPosition, PlayerShot);
        }

        // Test data generateor for class data (see line 85 below)
        private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                // First Name tests
                new object[]{"", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{" ", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{null, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },

                // TODO: complete remaining private set tests
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // Alternative test data generator for member data (see line 97 below)
        public static IEnumerable<object[]> GoodHockeyPlayerTestDataGenerator()
        {
            // Yield as many test objects as desired/required
            yield return new object[]
            {
               FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot,
            };
        }

        [Theory]
        [MemberData(nameof(GoodHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ReturnHockeyPlayer(string firstName, string lastName, string birthPlace,
            DateOnly dateOfBirth, int heighInInces, int weightInPounds, int jerseryNumber, Position position, Shot shot)
        {
            HockeyPlayer actual;

            actual = new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, heighInInces, weightInPounds, 
                jerseryNumber, position, shot);

            actual.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        public void HockeyPlayer_JerseyNumber_BadSetThrows(int value)
        {
            HockeyPlayer player = CreateTestHockeyPlayer();

            Action act = () => player.JerseyNumber = value;

            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Jersey number must be between 1 and 98.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(98)]
        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;

            actual.Should().Be(value);
        }

        [Fact]
        public void HockeyPlayer_Age_ReturnsCorrectValue()
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual;

            actual = player.Age;

            actual.Should().Be(Age);
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnsCorrectValue()
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            string actual;

            actual = player.ToString();

            actual.Should().Be(ToStringValue);
        }
    }
}