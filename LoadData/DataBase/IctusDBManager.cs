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

        public static bool DeleteIctusData(long pacienteID)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusData> collection = db.GetCollection<ictusData>("ictusdata");

                System.Threading.Tasks.Task <DeleteResult> tempResult = collection.DeleteOneAsync(x => x.pacienteID == pacienteID);
                
                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DeleteIctusData::Exception::" + exp.Message);
            }

            return result;
        }

        public static bool DropIctusData()
        {
            bool result = false;

            try
            {
                db.DropCollection("ictusdata");

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DropIctusData::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- ictusDataTMP ----------------------------------------------- //

        public static List<ictusDataTMP> GetAllictusDataTMP()
        {
            List<ictusDataTMP> ictusDataTMPList = new List<ictusDataTMP>();

            try
            {
                IMongoCollection<ictusDataTMP> collection = db.GetCollection<ictusDataTMP>("ictusDataTMP");

                if (collection != null)
                {
                    ictusDataTMPList = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllictusDataTMP::Exception::" + exp.Message);
            }

            return ictusDataTMPList;
        }

        public static bool NewIctusDataTMP(ictusDataTMP newIctusData)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusDataTMP> collection = db.GetCollection<ictusDataTMP>("ictusDataTMP");

                collection.InsertOneAsync(newIctusData);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewIctusDataTMP::Exception::" + exp.Message);
            }

            return result;
        }

        public static bool DeleteIctusDataTMP(long pacienteID)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusDataTMP> collection = db.GetCollection<ictusDataTMP>("ictusDataTMP");

                System.Threading.Tasks.Task<DeleteResult> tempResult = collection.DeleteOneAsync(x => x.pacienteID == pacienteID);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DeleteIctusDataTMP::Exception::" + exp.Message);
            }

            return result;
        }

        public static bool DropIctusDataTMP()
        {
            bool result = false;

            try
            {
                db.DropCollection("ictusDataTMP");

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DropIctusDataTMP::Exception::" + exp.Message);
            }

            return result;
        }

        //----------------------------------------------- ictusDataTMP2 ----------------------------------------------- //

        public static List<ictusDataTMP2> GetAllictusDataTMP2()
        {
            List<ictusDataTMP2> ictusDataTMP2List = new List<ictusDataTMP2>();

            try
            {
                IMongoCollection<ictusDataTMP2> collection = db.GetCollection<ictusDataTMP2>("ictusDataTMP2");

                if (collection != null)
                {
                    ictusDataTMP2List = collection.AsQueryable().ToList();
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("GetAllictusDataTMP2::Exception::" + exp.Message);
            }

            return ictusDataTMP2List;
        }

        public static bool NewIctusDataTMP2(ictusDataTMP2 newIctusData)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusDataTMP2> collection = db.GetCollection<ictusDataTMP2>("ictusDataTMP2");

                collection.InsertOneAsync(newIctusData);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("NewIctusDataTMP2::Exception::" + exp.Message);
            }

            return result;
        }

        public static bool DeleteIctusDataTMP2(long pacienteID)
        {
            bool result = false;

            try
            {
                IMongoCollection<ictusDataTMP2> collection = db.GetCollection<ictusDataTMP2>("ictusDataTMP2");

                System.Threading.Tasks.Task<DeleteResult> tempResult = collection.DeleteOneAsync(x => x.pacienteID == pacienteID);

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DeleteIctusDataTMP2::Exception::" + exp.Message);
            }

            return result;
        }

        public static bool DropIctusDataTMP2()
        {
            bool result = false;

            try
            {
                db.DropCollection("ictusDataTMP2");

                result = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("DropIctusDataTMP2::Exception::" + exp.Message);
            }

            return result;
        }

    }
}
