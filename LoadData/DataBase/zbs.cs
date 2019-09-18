using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class zbs
    {
        public ObjectId Id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int provincia_codigo { get; set; }
        public string area { get; set; }
        public int tis { get; set; }
        public string delimitacion { get; set; }

        internal bool ok { get; set; }

        public zbs() { }

        public zbs(int ncodigo, string nnombre, string ntipo, int nprovincia_codigo, string narea, int ntis, string ndelimitacion)
        {
            codigo = ncodigo;
            nombre = nnombre.Trim();
            tipo = ntipo.Trim();
            provincia_codigo = nprovincia_codigo;
            area = narea.Trim();
            tis = ntis;
            delimitacion = ndelimitacion.Trim();
        }

        public zbs(string[] inputArray)
        {
            try
            {
                ok = true;

                if (inputArray == null)
                {
                    ok = false;
                    ncLog.Error("ZBS::Null input array");
                    return;
                }

                if (inputArray.Length != 7)
                {
                    ok = false;
                    ncLog.Error("ZBS::Erroneous input format array with length:" + inputArray.Length);
                    return;
                }

                if (string.IsNullOrEmpty(inputArray[0]))
                {
                    codigo = Int32.MinValue;
                }
                else
                {
                    codigo = Convert.ToInt32(inputArray[0]);
                }

                nombre = inputArray[1].Trim();
                tipo = inputArray[2].Trim();

                if (string.IsNullOrEmpty(inputArray[3]))
                {
                    provincia_codigo = Int32.MinValue;
                }
                else
                {
                    provincia_codigo = Convert.ToInt32(inputArray[3]);
                }

                area = inputArray[4].Trim();

                if (string.IsNullOrEmpty(inputArray[5]))
                {
                    tis = Int32.MinValue;
                }
                else
                {
                    tis = Convert.ToInt32(inputArray[5]);
                }

                delimitacion = inputArray[6].Trim();
                
            }
            catch(Exception exp)
            {
                ok = false;
                ncLog.Exception("ZBS::" + exp.Message);
            }
        }

        public bool IsOk()
        {
            return ok;          
        }

    }
}
