using Utils;

namespace Hockey.Data
{
    /// <summary>
    /// An instance of this class will hold data about a hockey
    /// player.
    /// </summary>
    public class HockeyPlayer
    {
        // Data fields
        private string _birthPlace;
        private string _firstName;
        private string _lastName;
        private int _heightInInches;
        private int _weightInPounds;
        private DateOnly _dateOfBirth;
        private int _jerseyNumber;

        // Properties
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birth place cannot be null or empty.");
                }

                _birthPlace = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }

                _lastName = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }

            private set
            {
                if (Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Height must be positive.");
                }

                _heightInInches = value;
            }
        }
        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }

            private set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Weight must be positive.");
                }

                _weightInPounds = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            private set
            {
                if (Utilities.IsInTheFuture(value))
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }

                _dateOfBirth = value;
            }
        }

        public Position Position { get; set; }

        public Shot Shot { get; set; }

        // Greedy constructor
        public HockeyPlayer(string firstName, string lastName, string birthPlace,
            DateOnly dateOfBirth, int weightInPounds, int heightInInches, int jerseyNumber,
            Position position = Position.Center, 
            Shot shot = Shot.Left)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            DateOfBirth = dateOfBirth;
            JerseyNumber = jerseyNumber;
            Shot = shot;
            Position = position;
        }

        public int JerseyNumber
        {
            get
            {
                return _jerseyNumber;
            }

            set
            {
                if (value < 1 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("Jersey number must be between 1 and 98.",
                        new ArgumentException());
                }

                _jerseyNumber = value;
            }
        }

        public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        // Override ToString
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}