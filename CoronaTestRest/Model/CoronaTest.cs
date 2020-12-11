using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTestRest.Model
{
    public class CoronaTest
    {
        private int _testId;
        private string _machineName;
        private double _temperature;
        private string _location;
        private string _date;
        private string _time;

        public CoronaTest()
        {

        }

        public CoronaTest(int testId, string machineName, double temperature, string location, string date,
            string time)
        {
            _testId = testId;
            _machineName = machineName;
            _temperature = temperature;
            _location = location;
            _date = date;
            _time = time;
        }

        public int TestId
        {
            get => _testId;
            set
            {
                _testId = value;
            }
        }

        public string MachineName
        {
            get => _machineName;
            set
            {
                _machineName = value;
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        public string Time
        {
            get => _time;
            set
            {
                _time = value;
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(TestId)}: {_testId}, {nameof(MachineName)}: {_machineName}, " +
                $"{nameof(Temperature)}: {_temperature}, {nameof(Location)}: {_location}, " +
                $"{nameof(Date)}: {_date}, {nameof(Time)}: {_time}";
        }
    }
}
