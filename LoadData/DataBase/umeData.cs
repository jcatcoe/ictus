using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class umeData
    {

        public ObjectId Id { get; set; }
        public long inc_id { get; set; }
        public DateTime inc_sello_temporal { get; set; }
        public usvb usvb { get; set; }
        public int act_tac { get; set; }
        public int act_ttr { get; set; }
        public int act_tes { get; set; }
        public int act_tra { get; set; }
        public int act_trf { get; set; }
        public zbs zbs { get; set; }
        public string pac_sexo { get; set; }
        public int edad { get; set; }
        public double cie_codigo { get; set; }
        public string dim_responsable_nombre { get; set; }
        public hospital hospital { get; set; }
        public string dim_maquina_motivo_nombre { get; set; }

        internal bool ok { get; set; }

        public umeData() { }

        public umeData(long ninc_id, DateTime ninc_sello_temporal, usvb nusvb, int nact_tac, int nact_ttr, int nact_tes, int nact_tra, 
            int nact_trf, zbs nzbs, string npac_sexo, int nedad, double ncie_codigo, string ndim_responsable_nombre, 
            hospital nhospital,string ndim_maquina_motivo_nombre)
        {
            inc_id = ninc_id;
            inc_sello_temporal = ninc_sello_temporal;
            usvb = nusvb;
            act_tac = nact_tac;
            act_ttr = nact_ttr;
            act_tes = nact_tes;
            act_tra = nact_tra;
            act_trf = nact_trf;
            zbs = nzbs;
            pac_sexo = npac_sexo;
            edad = nedad;
            cie_codigo = ncie_codigo;
            dim_responsable_nombre = ndim_responsable_nombre;
            hospital = nhospital;
            dim_maquina_motivo_nombre = ndim_maquina_motivo_nombre;
        }

        public umeData(string[] inputArray)
        {
            try
            {
                ok = true;

                if (inputArray == null)
                {
                    ok = false;
                    ncLog.Error("umeData::Null input array");
                    return;
                }

                if (inputArray.Length != 15)
                {
                    ok = false;
                    ncLog.Error("umeData::Erroneous input format array with length:" + inputArray.Length);
                    return;
                }

                //if (string.IsNullOrEmpty(inputArray[10].Trim()) ||
                //    string.IsNullOrEmpty(inputArray[13].Trim()) ||
                //    string.IsNullOrEmpty(inputArray[15].Trim()))
                //{
                //    ok = false;
                //}
                //else
                {
                    if (string.IsNullOrEmpty(inputArray[0]))
                    {
                        inc_id = Int64.MinValue;
                    }
                    else
                    {
                        inc_id = Convert.ToInt64(inputArray[0]);
                    }

                    if (string.IsNullOrEmpty(inputArray[1]))
                    {
                        inc_sello_temporal = DateTime.MinValue;
                    }
                    else
                    {
                        inc_sello_temporal = Convert.ToDateTime(inputArray[1]);
                    }

                    usvb = Util.FindUSVBByName(inputArray[2]);

                    
                    if (string.IsNullOrEmpty(inputArray[3]))
                    {
                        act_tac = 0;
                    }
                    else
                    {
                        act_tac = Convert.ToInt32(inputArray[3]);
                    }

                    if (string.IsNullOrEmpty(inputArray[4]))
                    {
                        act_ttr = 0;
                    }
                    else
                    {
                        act_ttr = Convert.ToInt32(inputArray[4]);
                    }

                    if (string.IsNullOrEmpty(inputArray[5]))
                    {
                        act_tes = 0;
                    }
                    else
                    {
                        act_tes = Convert.ToInt32(inputArray[5]);
                    }

                    if (string.IsNullOrEmpty(inputArray[6]))
                    {
                        act_tra = 0;
                    }
                    else
                    {
                        act_tra = Convert.ToInt32(inputArray[6]);
                    }

                    if (string.IsNullOrEmpty(inputArray[7]))
                    {
                        act_trf = 0;
                    }
                    else
                    {
                        act_trf = Convert.ToInt32(inputArray[7]);
                    }

                    zbs = Util.FindZBSByName(inputArray[8]);

                    pac_sexo = inputArray[9].Trim();
                    
                    if (string.IsNullOrEmpty(inputArray[10]))
                    {
                        edad = Int32.MinValue;
                    }
                    else
                    {
                        edad = Convert.ToInt32(inputArray[10]);
                    }

                    if (string.IsNullOrEmpty(inputArray[11]))
                    {
                        cie_codigo = double.MinValue;
                    }
                    else
                    {
                        cie_codigo = Convert.ToDouble(inputArray[11]);
                    }

                    dim_responsable_nombre = inputArray[12].Trim();

                    hospital = Util.FindHospitalByName(inputArray[13]);

                    dim_maquina_motivo_nombre = inputArray[14].Trim();
                }
            }

            catch (Exception exp)
            {
                ok = false;
                ncLog.Exception("umeData::" + exp.Message);
            }
        }

        public bool IsOk()
        {
            return ok;
        }


    }
}
