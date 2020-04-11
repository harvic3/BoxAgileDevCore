using System;
using System.Runtime.Serialization;

namespace BoxAgileDevUnitTests.TestClasses
{
    public class TestClasses
    {
        public enum DocumentType
        {
            Passport = 1,
            Card,
        };

        [Serializable]
        [DataContract]
        public class PersonDto
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "lastName")]
            public string LastName { get; set; }

            [DataMember(Name = "document")]
            public DocumentType Document { get; set; }
        }

        public class Person
        {
            public string Name { get; set; }

            public string LastName { get; set; }

            public DocumentType Document { get; set; }
        }

        public class Nacionality
        {
            public string Country { get; set; }

            public string State { get; set; }

            public string City { get; set; }
        }

        public class PersonWithNacionality : Person
        {
            public Nacionality Nacionality { get; set; }
        }

    }
}
