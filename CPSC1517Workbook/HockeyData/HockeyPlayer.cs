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

        // Properties
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

        // Default constructor
        public HockeyPlayer()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Position = Position.Center;
            Shot = Shot.Left;
        }

        // Greedy constructor
        public HockeyPlayer(string firstName, string lastName, string birthPlace,
            DateOnly dateOfBirth, int weightInPounds, int heightInInches,
            Position position = Position.Center, 
            Shot shot = Shot.Left)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            DateOfBirth = dateOfBirth;
            Shot = shot;
            Position = position;
        }
    }
}