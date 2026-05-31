using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.DAL;

namespace TrainReservationSystem.BAL
{
    public class TrainException : Exception
    {
        public TrainException(string message) : base(message)
        {
        }
    }
    public class TrainBAL
    {
        TrainDAL dal = new TrainDAL();

        public bool IsTrainExists(int trainNo)
        {
            if (trainNo <= 0)
                throw new TrainException("Invalid Train Number");

            return dal.IsTrainExists(trainNo);
        }
        public void GetStationsByTrain(int trainNo)
        {
            if (trainNo <= 0)
                throw new TrainException("Invalid Train Number");

            dal.GetStationsByTrain(trainNo);
        }
        public void GetAvailableTrains()
        {
            dal.GetAvailableTrains();
        }

        public void GetallStations()
        {
            dal.GetAllStations();
        }
        public void SearchTrain(int from, int to)
        {
            if (from == to)
                throw new TrainException("From and To stations cannot be same");

            dal.SearchTrain(from, to);
        }

        public void AddTrain(int trainNo, string name, int ac1, int ac3, int sleeper, int total)
        {
            if (trainNo <= 0 || total <= 0)
                throw new TrainException("Invalid train data");

            dal.AddTrain("Admin", trainNo, name, ac1, ac3, sleeper, total);
        }

        public void AddStation(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new TrainException("Station name required");

            dal.AddStation("Admin", name);
        }

        public void AddRoute(int trainNo, int stationId, int order, int distance, string arrTime, string depTime)
        {
            if (trainNo <= 0 || stationId <= 0)
                throw new TrainException("Invalid route details");

            dal.AddRoute("Admin", trainNo, stationId, order, distance,  arrTime,  depTime);
        }

        public void DeleteTrain(int trainNo)
        {
            dal.DeleteTrain("Admin", trainNo);
        }

        public void GetAllData()
        {
            dal.GetAllData("Admin");
        }
    }
}
