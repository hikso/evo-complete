using NUnit.Framework;

namespace NUnitTest
{
    public class SomeClass
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SomeClass sc1 = new SomeClass()
            {
                Prop1 = 1,
                Prop2 = "Uno"
            };

            SomeClass sc2 = new SomeClass()
            {
                Prop1 = 1,
                Prop2 = "Uno"
            };

            //Assert.AreEqual(sc1, sc2) is the same as Assert.IsTrue(Object.Equals(sc1, sc2));
            //Assert.AreSame(sc2, sc2) is the same as Assert.IsTrue(Object.ReferenceEquals(sc1, sc2));

            //Differences between Object.ReferenceEquals and Object.Equals
            //https://stackoverflow.com/questions/3869601/c-sharp-equals-referenceequals-and-operator#:~:text=Equals()%20can%20return%20True,but%20this%20CAN%20be%20overridden.
            Assert.AreSame(sc1, sc2);
        }

        [Test]
        public void Test2()
        {
            SomeClass sc1 = new SomeClass()
            {
                Prop1 = 1,
                Prop2 = "Uno"
            };

            SomeClass sc2 = sc1;

            Assert.AreEqual(sc1, sc2);
            Assert.AreSame(sc1, sc2);
        }
    }
}