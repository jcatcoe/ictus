using LoadData.Tools;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public static class IctusDBManager
    {
        static string connectionString = "mongodb://localhost:27017";
        static MongoClient client = new MongoClient(connectionString);
        static IMongoDatabase db = client.GetDatabase("ictus");

        //----------------------------------------------- ZBS ----------------------------------------------- //

        public static List<zbs> GetAllZBS()
        {
            List<zbs> zbsList = new List<zbs>();

            try
            {
                IMongoCollection<zbs> collection = db.GetCollection<zbs>("zbs");

                if (collection != null)
                {
                    zbsList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllZBS::Exception::" + exp.Message);
            }

            return zbsList;
        }

        public static bool NewZBS(zbs newZBS)
        {
            bool result = false;

            try
            {
                IMongoCollection<zbs> collection = db.GetCollection<zbs>("zbs");

                collection.InsertOneAsync(newZBS);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewZBSb::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- USVB ----------------------------------------------- //

        public static List<usvb> GetAllUSVB()
        {
            List<usvb> usvbList = new List<usvb>();

            try
            {
                IMongoCollection<usvb> collection = db.GetCollection<usvb>("usvb");

                if (collection != null)
                {
                    usvbList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllUSVB::Exception::" + exp.Message);
            }

            return usvbList;
        }

        public static bool NewUSVB(usvb newUSVB)
        {
            bool result = false;

            try
            {
                IMongoCollection<usvb> collection = db.GetCollection<usvb>("usvb");

                collection.InsertOneAsync(newUSVB);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewUSVB::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- HOSPITAL ----------------------------------------------- //

        public static List<hospital> GetAllHospitales()
        {
            List<hospital> hospitalList = new List<hospital>();

            try
            {
                IMongoCollection<hospital> collection = db.GetCollection<hospital>("hospital");

                if (collection != null)
                {
                    hospitalList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllHospitales::Exception::" + exp.Message);
            }

            return hospitalList;
        }

        public static bool NewHospital(hospital newHospital)
        {
            bool result = false;

            try
            {
                IMongoCollection<hospital> collection = db.GetCollection<hospital>("hospital");

                collection.InsertOneAsync(newHospital);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("newHospital::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- umeData ----------------------------------------------- //

        public static List<umeData> GetAllUmeData()
        {
            List<umeData> umeDataList = new List<umeData>();

            try
            { 
                IMongoCollection<umeData> collection = db.GetCollection<umeData>("umeData");

                if (collection != null)
                {
                    umeDataList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllUmeData::Exception::" + exp.Message);
            }

            return umeDataList;
        }

        public static bool NewUmeData(umeData newumeData)
        {
            bool result = false;

            try
            {
                IMongoCollection<umeData> collection = db.GetCollection<umeData>("umeData");

                collection.InsertOneAsync(newumeData);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewUmeData::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- umeDataTMP ----------------------------------------------- //

        public static List<umeDataTMP> GetAllUmeDataTMP()
        {
            List<umeDataTMP> umeDataTMPList = new List<umeDataTMP>();

            try
            {
                IMongoCollection<umeDataTMP> collection = db.GetCollection<umeDataTMP>("umeDataTMP");

                if (collection != null)
                {
                    umeDataTMPList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllUmeData::Exception::" + exp.Message);
            }

            return umeDataTMPList;
        }

        public static bool NewUmeDataTMP(umeDataTMP newumeDataTMP)
        {
            bool result = false;

            try
            {
                IMongoCollection<umeDataTMP> collection = db.GetCollection<umeDataTMP>("umeDataTMP");

                collection.InsertOneAsync(newumeDataTMP);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewUmeData::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- ictusData ----------------------------------------------- //

        public static List<ictusData> GetAllictusData()
        {
            List<ictusData> ictusDataList = new List<ictusData>();

            try
            {
                IMongoCollection<ictusData> collection = db.GetCollection<ictusData>("ictusdata");

                if (collection != null)
                {
                    ictusDataList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllictusData::Exception::" + exp.Message);
            }

            return ictusDataList;
        }

        public static bool NewIctusData(ictusData newIctusData)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusData> collection = db.GetCollection<ictusData>("ictusdata");

                collection.InsertOneAsync(newIctusData);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewIctusData::Exception::" + exp.Message);
            }

            return result;
        }











    }
}
