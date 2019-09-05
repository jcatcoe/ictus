using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class umeDataTMP// : IEquatable<umeDataTMP>
    {
        public ObjectId Id { get; set; }
        public long inc_id { get; set; }
        public DateTime inc_sello_temporal { get; set; }
        public string dim_recurso_nombreUSVB { get; set; }
        public int act_tac { get; set; }
        public int act_ttr { get; set; }
        public int act_tes { get; set; }
        public int act_tra { get; set; }
        public int act_trf { get; set; }
        public string dim_zbs_nombre { get; set; }
        public string pac_sexo { get; set; }
        public int edad { get; set; }
        public string cie_codigo { get; set; }
        public string dim_responsable_nombre { get; set; }
        public string dim_recurso_nombreHospital { get; set; }
        public string dim_maquina_motivo_nombre { get; set; }

        public umeDataTMP(string[] inputArray)
        {
            try
            {
                if (inputArray == null)
                {
                    ncLog.Error("umeDataTMP::Null input array");
                    return;
                }

                if (inputArray.Length != 15)
                {
                    ncLog.Error("umeDataTMP::Erroneous input format array with length:" + inputArray.Length);
                    return;
                }

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

                dim_recurso_nombreUSVB = inputArray[2].Trim();
                    
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

                dim_zbs_nombre = inputArray[8].Trim();

                pac_sexo = inputArray[9].Trim();

                if (string.IsNullOrEmpty(inputArray[10]))
                {
                    edad = 0;
                }
                else
                {
                    edad = Convert.ToInt32(inputArray[10]);
                }

                
                cie_codigo = inputArray[11].Trim();

                dim_responsable_nombre = inputArray[12].Trim();

                dim_recurso_nombreHospital = inputArray[13].Trim();

                dim_maquina_motivo_nombre = inputArray[14].Trim();
                
            }

            catch (Exception exp)
            {
                ncLog.Exception("umeData:TMP:" + exp.Message);
                inc_id = Int64.MinValue;
            }
        }

        //public bool Equals(umeDataTMP other)
        //{

        //    //Check whether the compared object is null. 
        //    if (Object.ReferenceEquals(other, null)) return false;

        //    //Check whether the compared object references the same data. 
        //    if (Object.ReferenceEquals(this, other)) return true;

        //    //Check whether the products' properties are equal. 
        //    return act_tac.Equals(other.act_tac) &&
        //           act_ttr.Equals(other.act_ttr) &&
        //           act_tes.Equals(other.act_tes) &&
        //           act_tra.Equals(other.act_tra) &&
        //           act_trf.Equals(other.act_trf) &&
        //           dim_zbs_nombre.Equals(other.dim_zbs_nombre) &&
        //           pac_sexo.Equals(other.pac_sexo) &&
        //           edad.Equals(other.edad) &&
        //           cie_codigo.Equals(other.cie_codigo);

        //}

        //public override int GetHashCode()
        //{

        //    return act_tac.GetHashCode() ^
        //        act_ttr.GetHashCode() ^
        //        act_tes.GetHashCode() ^
        //        act_tra.GetHashCode() ^
        //        act_trf.GetHashCode() ^
        //        dim_zbs_nombre.GetHashCode() ^
        //        pac_sexo.GetHashCode() ^
        //        edad.GetHashCode() ^
        //        cie_codigo.GetHashCode();
        //}

    }
}
