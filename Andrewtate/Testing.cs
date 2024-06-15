using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrewtate
{
    internal class Testing
    {
        [TestFixture]

        public class Test {
            [Test]
            public void CountTrains_ReturnCorrectNumberOfTrains()
            {
                var trainCount = new Functions();
                int result = trainCount.TrainCount();
                Assert.That(Equals(5, result));
            }

            [Test]
            public void CountTrains_ReturnCorrectNumberOfStations()
            {
                var stationCount = new Functions();
                int result = stationCount.TrainStationsCount();
                Assert.That(Equals(2, result));
            }
        }
    }
}
