using LoadData.DataBase;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.Tools
{
    public static class Util
    {
        public static List<usvb> usvbList = new List<usvb>();
        public static List<zbs> zbsList = new List<zbs>();
        public static List<hospital> hospitalList = new List<hospital>();
        public static List<umeDataTMP> umeDataTMPList = new List<umeDataTMP>();

        public static Dictionary<long, List<umeDataTMP>> ictusDataMap = new Dictionary<long, List<umeDataTMP>>();

        public static string[] ConvertToStringArray(System.Array array)
        {
            string[] stringArray = new string[array.Length];

            int cont = 0;

            foreach (object iter in array)
            {
                if (iter == null)
                {
                    stringArray[cont] = string.Empty;
                }
                else
                {
                    stringArray[cont] = iter.ToString();
                }

                ++cont;
            }

            return stringArray;
        }

        public static bool LoadUSVBList()
        {
            bool result = false;

            try
            {
                usvbList = IctusDBManager.GetAllUSVB();

                if (usvbList != null && usvbList.Count() != 0)
                {
                    result = true;
                }
                else
                {
                    ncLog.Error("LoadUSVBList::Unable to load USVB from database");
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadUSVBList::" + exp.Message);
            }

            return result;
        }

        public static bool LoadZBSList()
        {
            bool result = false;

            try
            {
                zbsList = IctusDBManager.GetAllZBS();

                if (zbsList != null && zbsList.Count() != 0)
                {
                    result = true;
                }
                else
                {
                    ncLog.Error("LoadZBSList::Unable to load ZBS from database");
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadZBSList::" + exp.Message);
            }

            return result;
        }

        public static bool LoadHospitalList()
        {
            bool result = false;

            try
            {
                hospitalList = IctusDBManager.GetAllHospitales();

                if (hospitalList != null && hospitalList.Count() != 0)
                {
                    result = true;
                }
                else
                {
                    ncLog.Error("LoadHospitalList::Unable to load Hospitales from database");
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadHospitalList::" + exp.Message);
            }

            return result;
        }

        public static bool LoadDataMasterList()
        {
            bool result = false;

            try
            {
                if(LoadUSVBList() && LoadZBSList() && LoadHospitalList())
                {
                    result = true;
                }
                else
                {
                    ncLog.Error("LoadDataMasterList::Unable to load mater list from database");
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadDataMasterList::" + exp.Message);
            }

            return result;
        }

        public static usvb FindUSVBByName(string usvbName)
        {
            usvb result = null;

            try
            {
                if (usvbList == null || usvbList.Count() == 0)
                {
                    if (LoadUSVBList() == false)
                    {
                        ncLog.Error("FindUSVBByName::Unable to load USVB");
                        return result;
                    }
                }

                result = usvbList.Where(x => x.recurso_nombre == usvbName).FirstOrDefault();

                if (result == null)
                {
                    result = new usvb();
                    result.recurso_nombre = usvbName;
                }
            }

            catch (Exception exp)
            {
                ncLog.Exception("FindUSVBByName::" + exp.Message);
            }

            return result;
        }

        public static zbs FindZBSByName(string zbsName)
        {
            zbs result = null;

            try
            {
                if (zbsList == null || zbsList.Count() == 0)
                {
                    if (LoadZBSList() == false)
                    {
                        ncLog.Error("FindZBSByName::Unable to load ZBS");
                        return result;
                    }
                }

                result = zbsList.Where(x => x.nombre == zbsName).FirstOrDefault();

                if (result == null)
                {
                    result = new zbs();
                    result.nombre = zbsName;
                }
            }

            catch (Exception exp)
            {
                ncLog.Exception("FindZBSByName::" + exp.Message);
            }

            return result;
        }

        public static hospital FindHospitalByName(string hospitalName)
        {
            hospital result = null;

            try
            {
                if (hospitalList == null || hospitalList.Count() == 0)
                {
                    if (LoadHospitalList() == false)
                    {
                        ncLog.Error("FindHospitalByName::Unable to load Hospital");
                        return result;
                    }
                }

                result = hospitalList.Where(x => x.recurso_nombre == hospitalName).FirstOrDefault();

                if (result == null)
                {
                    result = new hospital();
                    result.recurso_nombre = hospitalName;
                }
            }

            catch (Exception exp)
            {
                ncLog.Exception("FindHospitalByName::" + exp.Message);
            }

            return result;
        }


        public static string[] GetRange(string range, Worksheet excelWorksheet)
        {
            Microsoft.Office.Interop.Excel.Range workingRangeCells =
              excelWorksheet.get_Range(range, Type.Missing);

            System.Array array = (System.Array)workingRangeCells.Cells.Value2;
            string[] arrayS = Util.ConvertToStringArray(array);

            return arrayS;
        }

        public static void LoadTemporalData()
        {
            try
            {
                if (LoadDataMasterList())
                {
                    if (LoaumeDataTMP())
                    {
                        ncLog.Message("USVBList:[" + usvbList.Count() + "] - ZBSList:[" + zbsList.Count() +
                            "] - HospitalesList:[" + hospitalList.Count() + "] - umeDataTMPList:[" + umeDataTMPList.Count() + "]");

                        ictusDataMap.Clear();

                        Dictionary<long, List<umeDataTMP>> ictusDataMapTMP = new Dictionary<long, List<umeDataTMP>>();

                        ictusDataMapTMP = umeDataTMPFilters();

                        if(ictusDataMapTMP != null && ictusDataMapTMP.Count() > 0)
                        {
                            Dictionary<long, List<umeDataTMP>> ictusDataMapFinal = new Dictionary<long, List<umeDataTMP>>();

                            foreach (KeyValuePair<long, List<umeDataTMP>> iter in ictusDataMapTMP)
                            {
                                List<umeDataTMP> lista = RemoveDuplicates(iter.Key, iter.Value);

                                if (lista.Count() <= 2)
                                {
                                    if (!ictusDataMap.ContainsKey(iter.Key))
                                    {
                                        ictusDataMap[iter.Key] = lista;
                                    }
                                }
                            }

                            ncLog.Message("LoadTemporalData::ictusDataMap Rows:[" + ictusDataMap.Count() + "]");
                        }
                    }
                    else
                    {
                        ncLog.Error("LoadTemporalData::Unable to load umeDataTMP");
                    }
                }
                else
                {
                    ncLog.Error("LoadTemporalData::Unable to load maste list");
                }
            }
            catch(Exception exp)
            {
                ncLog.Exception("LoadTemporalData::" + exp.Message);
            }
        }

        public static bool LoaumeDataTMP()
        {
            bool result = false;

            try
            {
                umeDataTMPList = IctusDBManager.GetAllUmeDataTMP();

                if (umeDataTMPList != null && umeDataTMPList.Count() != 0)
                {
                    result = true;
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoaumeDataTMP::" + exp.Message);
            }

            return result;
        }


        private static Dictionary<long, List<umeDataTMP>> umeDataTMPFilters()
        {
            Dictionary<long, List<umeDataTMP>> result = new Dictionary<long, List<umeDataTMP>>();

            try
            {
                if (umeDataTMPList == null || umeDataTMPList.Count() == 0)
                {
                    ncLog.Error("umeDataTMPFilters::Null or empty umeDataTMPList!!");
                    return result;
                }

                //////////////////////////////////////Removing own names//////////////////////////////////////
                List<string> noNombresPropiosList = new List<string>() { "ACU ", "CG ", "CL ", "CS ", "EES1 ", "EES2 ", "HELICOP. ",
                        "HELICOPTERO ", "MEDICO ", "OTROS RECURSOS ", "PAC ", "PACIP ", "REFUERZO PUEBLA DE SANABRIA ", "REVE LEON ", "SUAP ",
                        "SVB ", "SVBC ", "UME ", "UVI ", "VIR " };

                List<umeDataTMP> auxUmeDataTMPList = umeDataTMPList.Where(r => noNombresPropiosList.Any(f => r.dim_recurso_nombreUSVB.StartsWith(f))).ToList();

                umeDataTMPList.Clear();
                umeDataTMPList = new List<umeDataTMP>(auxUmeDataTMPList);
                auxUmeDataTMPList.Clear();

                ncLog.Message("umeDataTMPFilters::Nº rows without own names:" + umeDataTMPList.Count);

                //////////////////////////////////////Removing dim_maquina_motivo_nombre = COMUNICACION, ASIGNACION, RECURSO INNECESARIO, INCIDENCIA
                List<string> maquinaMotivo2RemoveList = new List<string>() { "COMUNICACION", "ASIGNACION", "RECURSO INNECESARIO", "INCIDENCIA" };
                auxUmeDataTMPList = umeDataTMPList.Where(r => !maquinaMotivo2RemoveList.Contains(r.dim_maquina_motivo_nombre)).ToList();

                umeDataTMPList.Clear();
                umeDataTMPList = new List<umeDataTMP>(auxUmeDataTMPList);
                auxUmeDataTMPList.Clear();

                ncLog.Message("umeDataTMPFilters::Nº rows without COMUNICACION, ASIGNACION,RECURSO INNECESARIO and INCIDENCIA:" + umeDataTMPList.Count);

                //////////////////////////////Without all tims fields empty//////////////////////////////
                auxUmeDataTMPList = RemoveEmptyTimes(umeDataTMPList);

                umeDataTMPList.Clear();
                umeDataTMPList = new List<umeDataTMP>(auxUmeDataTMPList);
                auxUmeDataTMPList.Clear();

                ncLog.Message("umeDataTMPFilters::Nº rows without all time fields empty:" + umeDataTMPList.Count);

                //////////////////////////////Dictionary<inc_id, List<umeDataTMP>> => Mapa agrupado por inc_id//////////////////////////////
                result = umeDataTMPList.GroupBy(x => x.inc_id).ToDictionary(y => y.Key, y => y.ToList());

                ncLog.Message("umeDataTMPFilters::Nº rows grouped by inc_ic:" + result.Count());
            }
            catch (Exception exp)
            {
                ncLog.Exception("umeDataTMPFilters::" + exp.Message);
            }

            return result;
        }

        public static string GetCIECcode(List<umeDataTMP> list)
        {
            string result = string.Empty;

            try
            {
                umeDataTMP tempResult = null;

                //HELICO
                tempResult = list.Where(x => x.dim_responsable_nombre.Contains("MEDICO HELICO")).FirstOrDefault();

                if(tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //UME
                tempResult = list.Where(x => x.dim_responsable_nombre.Contains("MEDICO UME")).FirstOrDefault();

                if (tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //UVI
                tempResult = list.Where(x => x.dim_responsable_nombre.Contains("MEDICO UVI")).FirstOrDefault();

                if (tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //AE
                tempResult = list.Where(x => x.dim_responsable_nombre.Contains("MEDICO AE")).FirstOrDefault();

                if (tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //ap/privado/residencia
                List<String> filterAP = new List<string>() { "MEDICO AP", " MEDICO PRIVADO", "MEDICO RESIDENCIA" };
                tempResult = list.Where(x => filterAP.Contains(x.dim_responsable_nombre)).FirstOrDefault();

                if (tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //REGULADOR
                tempResult = list.Where(x => x.dim_responsable_nombre.Contains("REGULADOR")).FirstOrDefault();

                if (tempResult != null)
                {
                    result = tempResult.cie_codigo;
                    return result;
                }

                //DEFAULT
                result = list.FirstOrDefault().cie_codigo;
            }
            catch(Exception exp)
            {
                ncLog.Exception("GetCIECcode::" + exp.Message);
            }

            return result;
        }

        public static List<umeDataTMP> RemoveDuplicates(long ID, List<umeDataTMP> inputList)
        {
            List<umeDataTMP> result = null;

            try
            {
                string msg = "RemoveDuplicates:ID:[" + ID + "] - Year:[" + inputList.FirstOrDefault().inc_sello_temporal.Year + "] - Input Count:[" + inputList.Count() + "]";

                List <umeDataTMP>  tempResult = inputList.GroupBy(m => new { m.inc_id, m.inc_sello_temporal, m.dim_recurso_nombreUSVB,
                    m.act_tac, m.act_ttr, m.act_tes, m.act_tra, m.act_trf, m.dim_zbs_nombre, m.pac_sexo, m.edad
                }).Select(group => group.First()).ToList();


                msg += " - Without Duplicates:[" + tempResult.Count() + "]";

                string cie = GetCIECcode(tempResult);

                if(string.IsNullOrEmpty(cie))
                {
                    ncLog.Error("RemoveDuplicates::Unable to find cie code for dim_recurso_nombreUSVB:[" + inputList.FirstOrDefault().dim_recurso_nombreUSVB + 
                        "] - dim_zbs_nombre:[" + inputList.FirstOrDefault().dim_zbs_nombre + "]");
                }

                result = tempResult.Where(x => x.cie_codigo == cie).ToList();

                msg += " - After CIE:[" + result.Count() + "]";

                if (result.Count() > 2)
                {
                    result = FilterByHelicoptero(result.ToList());

                    msg += " - FilterByHelico:[" + result.Count() + "]";

                    if (result.Count() > 1)
                    {
                        ncLog.Message(msg);
                        PrintResults(ID, result);
                    }
                }

            }
            catch(Exception exp)
            {
                ncLog.Exception("RemoveDuplicates::" + exp.Message);
            }

            return result;
        }

        private static void PrintResults(long ID, List<umeDataTMP> inputList)
        {
            foreach(umeDataTMP iter in inputList)
            {
                ncLog.Message(ID + "," + iter.inc_sello_temporal.Year + "," + iter.dim_recurso_nombreUSVB
                    + "," + iter.act_tac + "," + iter.act_ttr + "," + iter.act_tes + "," + iter.act_tra + "," + iter.act_trf + ","
                    + iter.dim_zbs_nombre + "," + iter.pac_sexo + "," + iter.edad + "," + iter.cie_codigo + "," + iter.dim_responsable_nombre 
                    + "," + iter.dim_recurso_nombreHospital + "," + iter.dim_maquina_motivo_nombre);
            }
        }


        public static List<umeDataTMP> FilterByHelicoptero(List<umeDataTMP> inputList)
        {
            List<umeDataTMP> result = null;

            try
            {
                umeDataTMP helicoFound = inputList.Where(x => x.dim_recurso_nombreUSVB.Contains("HELICO")).FirstOrDefault();

                if(helicoFound == null) //No HELICO inside the input list
                {
                    result = inputList;
                }
                else
                {
                    result = new List<umeDataTMP>() { helicoFound };
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("FilterByHelicoptero::" + exp.Message);
            }

            return result;
        }

        public static List<umeDataTMP> RemoveEmptyTimes(List<umeDataTMP> inputList)
        {
            List<umeDataTMP> result = null;

            try
            {
                result = inputList.Where(m => (m.act_tac != 0) || (m.act_ttr != 0) || (m.act_tes != 0) || (m.act_tra != 0) || (m.act_trf != 0)).ToList();

                List<umeDataTMP> activTimeNoNZero = result.Where(m => (m.act_tac != 0) && (m.act_ttr == 0) && (m.act_tes == 0) && (m.act_tra == 0) && (m.act_trf == 0)).ToList();

                result = result.Except(activTimeNoNZero).ToList();
            }
            catch (Exception exp)
            {
                ncLog.Exception("RemoveEmptyTimes::" + exp.Message);
            }

            return result;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var known = new HashSet<TKey>();
            return source.Where(element => known.Add(keySelector(element)));
        }

        public static void CreateIctusDataTMPCollection()
        {
            List<ictusData> ictusDataList = IctusDBManager.GetAllictusData();

            if(ictusDataList != null && ictusDataList.Count() > 0)
            {
                ncLog.Message("Nº rows ictusDataList:" + ictusDataList.Count());
                int cont = 0;

                foreach (ictusData iter in ictusDataList)
                {
                    ictusDataTMP newIctusDataTMP = new ictusDataTMP(iter);

                    if (!newIctusDataTMP.IsOk())
                    {
                        ncLog.Error("Unable to create newIctusDataTMP for pacienteID:" + iter.pacienteID);
                    }
                    else
                    {
                        if (!IctusDBManager.NewIctusDataTMP(newIctusDataTMP))
                        {
                            ncLog.Error("Unable to insert newIctusDataTMP for pacienteID:" + newIctusDataTMP.pacienteID);
                        }
                        else
                        {
                            ++cont;
                            ncLog.Message("Inserted ictusDataTMP nº:" + cont);
                        }
                    }
                }
            }
        }

        public static void CreateIctusDataTMPCollection2()
        {
             List<ictusDataTMP> ictusDataList = IctusDBManager.GetAllictusDataTMP();

            if (ictusDataList != null && ictusDataList.Count() > 0)
            {
                ncLog.Message("Nº rows ictusDataList:" + ictusDataList.Count());
                int cont = 0;

                foreach (ictusDataTMP iter in ictusDataList)
                {
                    ictusDataTMP2 newIctusDataTMP = new ictusDataTMP2(iter);

                    if (!newIctusDataTMP.IsOk())
                    {
                        ncLog.Error("Unable to create newIctusDataTMP2 for pacienteID:" + iter.pacienteID);
                    }
                    else
                    {
                        if (!IctusDBManager.NewIctusDataTMP2(newIctusDataTMP))
                        {
                            ncLog.Error("Unable to insert newIctusDataTMP2 for pacienteID:" + newIctusDataTMP.pacienteID);
                        }
                        else
                        {
                            ++cont;
                            ncLog.Message("Inserted ictusDataTMP2 nº:" + cont);
                        }
                    }
                }
            }
        }

        public static void InfoDifferentCIE()
        {
            Dictionary<long, List<umeDataTMP>> result = new Dictionary<long, List<umeDataTMP>>();

            try
            {
                List<umeDataTMP> umeDataTMPList = IctusDBManager.GetAllUmeDataTMP();

                if (umeDataTMPList == null || umeDataTMPList.Count() == 0)
                {
                    ncLog.Error("InfoDifferentCIE::Null or empty umeDataTMPList!!");
                    return;
                }

                string msg = "ID,CIE1,Responsable1,CIE2, Responsable2";

                Dictionary<long, List<umeDataTMP>>  umeDataTMPMap = umeDataTMPList.GroupBy(x => x.inc_id).ToDictionary(y => y.Key, y => y.ToList());

                if(umeDataTMPMap != null && umeDataTMPMap.Count() != 0)
                {
                    foreach(KeyValuePair<long, List<umeDataTMP>> iter in umeDataTMPMap)
                    {
                        long pacienteID = iter.Key;

                        List<string> cieGroup = iter.Value.Select(x => x.cie_codigo).Distinct().ToList();

                        if(cieGroup != null && cieGroup.Count() > 1)
                        {
                            msg += "\r\n" + pacienteID;

                            int size = cieGroup.Count;
                            int counter = 1;

                            foreach (string iterCie in cieGroup)
                            {
                                if(size == 3)
                                {
                                    if(counter == 2)
                                    {
                                        ++counter;
                                        continue;
                                    }
                                }

                                umeDataTMP dataFound = iter.Value.Where(x => x.cie_codigo == iterCie).FirstOrDefault();

                                msg += "," + iterCie + "," + dataFound.dim_responsable_nombre;

                                ++counter;
                            }

                            msg += "," + iter.Value.FirstOrDefault().inc_sello_temporal.Year;
                        }
                            
                    }
                }

                ncLog.Message(msg);

                
            }
            catch (Exception exp)
            {
                ncLog.Exception("InfoDifferentCIE::" + exp.Message);
            }
        }

        public static void DifferentUSVB()
        {
            List<ictusDataTMP> ictusDataTMPList =  IctusDBManager.GetAllictusDataTMP();

            if(ictusDataTMPList != null && ictusDataTMPList.Count() > 0)
            {
                List<string> usbList = ictusDataTMPList.Select(x => x.usvb_nombre).Distinct().ToList();

                
                int svbN = ictusDataTMPList.Where(x => x.usvb_nombre.Contains("SVB") || x.usvb_nombre.Contains("ACU")).Count();
                int umeN = ictusDataTMPList.Where(x => x.usvb_nombre.Contains("UME") || x.usvb_nombre.Contains("UVI") || x.usvb_nombre.Contains("VIR")).Count();
                int heliN = ictusDataTMPList.Where(x => x.usvb_nombre.Contains("HELI")).Count();

                ncLog.Message("DifferentUSVB::svbN:" + svbN + " - umeN:" + umeN + "heliN:" + heliN);

                Dictionary<int, List< ictusDataTMP>> svbMpa =  ictusDataTMPList.Where(x => x.usvb_nombre.Contains("SVB") || x.usvb_nombre.Contains("ACU")).GroupBy(x => x.fecha.Year).ToDictionary(y => y.Key, y => y.ToList());
                Dictionary<int, List<ictusDataTMP>> umeMap = ictusDataTMPList.Where(x => x.usvb_nombre.Contains("UME") || x.usvb_nombre.Contains("UVI") || x.usvb_nombre.Contains("VIR")).GroupBy(x => x.fecha.Year).ToDictionary(y => y.Key, y => y.ToList());
                Dictionary<int, List<ictusDataTMP>> heliMap = ictusDataTMPList.Where(x => x.usvb_nombre.Contains("HELI")).GroupBy(x => x.fecha.Year).ToDictionary(y => y.Key, y => y.ToList());

                string msg = string.Empty;

                foreach(KeyValuePair<int, List<ictusDataTMP>> iter in svbMpa)
                {
                    msg += "\r\nAño:" + iter.Key + " - Nº Registrsos:" + iter.Value.Count();
                }

                ncLog.Message("SVBMap::" + msg);

                msg = string.Empty;

                foreach (KeyValuePair<int, List<ictusDataTMP>> iter in umeMap)
                {
                    msg += "\r\nAño:" + iter.Key + " - Nº Registrsos:" + iter.Value.Count();
                }

                ncLog.Message("umeMap::" + msg);

                msg = string.Empty;

                foreach (KeyValuePair<int, List<ictusDataTMP>> iter in heliMap)
                {
                    msg += "\r\nAño:" + iter.Key + " - Nº Registrsos:" + iter.Value.Count();
                }

                ncLog.Message("heliMap::" + msg);

                int a = 0;

            }
        }


    }
}
