namespace FooClassLibrary
{
    public class Foo
    {
        // Must only contain letters
        private string name;

        // Must be between MinValue and MaxValue
        private int value;

        // The maximum value.
        public const int MaxValue = 100;

        // The minimum value.
        public const int MinValue = 0;

        /// Initializes a new instance of the class.
        public Foo()
        {
            this.name = string.Empty;
            this.value = 0;
        }


        /// Initializes a new instance of the class with name and value.
        public Foo(string name, int value)
        {
            // Name cannot be null.
            if (name == null)
            {
                throw new NullReferenceException("Name cannot be null.");
            }

            // Name must only contain characters

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    throw new FormatException(string.Format("{0} is not a letter.", c));
                }
            }

            this.name = name;

            // Value must be between MinValue and MaxValue

            if (value < Foo.MinValue)
            {
                throw new ArgumentOutOfRangeException(string.Format("Value less than {0}", Foo.MinValue));
            }

            if (value > Foo.MaxValue)
            {
                throw new ArgumentOutOfRangeException(string.Format("Value greater than {0}", Foo.MaxValue));
            }

            this.value = value;
        }


        // Initializes a new instance of the class from another instance.
        public Foo(Foo foo)
        {
            // Name cannot be null.
            if (foo == null)
            {
                throw new NullReferenceException("Foo cannot be null.");
            }

            this.Name = foo.name;
            this.Value = foo.value;
        }

        // Gets or sets the name.
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                // Name cannot be null
                if (value == null)
                {
                    throw new NullReferenceException("Name cannot be null.");
                }

                // Name must only contain characters
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new FormatException(string.Format("{0} is not a letter.", c));
                    }
                }

                this.name = value;
            }
        }

        // Gets or sets the value.
        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                // Value must be between MinValue and MaxValue
                if (value < Foo.MinValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value less than {0}", Foo.MinValue));
                }

                if (value > Foo.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value greater than {0}", Foo.MaxValue));
                }

                this.value = value;
            }
        }

        // Takes a string "Name,Value" and return new Foo.
        public static Foo Parse(string nameValueString)
        {
            Foo foo = new Foo();

            string[] s = nameValueString.Split(',');

            // If no comma throw FormatException
            if (s.Length != 2)
            {
                throw new FormatException("Name, value string not in correct format.");
            }

            foo.Name = s[0];
            foo.Value = int.Parse(s[1]);

            return foo;
        }

        // Trims input to valid value before assigning
        public void AssignTrimmedValue(int value)
        {
            if (value > Foo.MaxValue)
            {
                this.value = Foo.MaxValue;
            }
            else if (value < Foo.MinValue)
            {
                this.value = Foo.MinValue;
            }
            else
            {
                this.value = value;
            }
        }
    }
}
