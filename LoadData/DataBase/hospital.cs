using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class hospital
    {
        public ObjectId Id { get; set; }
        public int recurso_codigo { get; set; }
        public string recurso_nombre { get; set; }
        public int recurso_provincia_codigo { get; set; }
        public int recurso_municipio_codigo { get; set; }
        public string recurso_ccaa { get; set; }
        public string recurso_direccion { get; set; }
        public string recurso_ubicacion { get; set; }

        internal bool ok { get; set; }

        public hospital() { }

        public hospital(int nrecurso_codigo, string nrecurso_nombre, int nrecurso_provincia_codigo, int nrecurso_municipio_codigo,
            string nrecurso_ccaa, string nrecurso_direccion, string nrecurso_ubicacion)
        {
            recurso_codigo = nrecurso_codigo;
            recurso_nombre = nrecurso_nombre;
            recurso_provincia_codigo = nrecurso_provincia_codigo;
            recurso_municipio_codigo = nrecurso_municipio_codigo;
            recurso_ccaa = nrecurso_ccaa;
            recurso_direccion = nrecurso_direccion;
            recurso_ubicacion = nrecurso_ubicacion;
        }

        public hospital(string[] inputArray)
        {
            try
            {
                ok = true;

                if (inputArray == null)
                {
                    ok = false;
                    ncLog.Error("hospital::Null input array");
                    return;
                }

                if (inputArray.Length != 7)
                {
                    ok = false;
                    ncLog.Error("hospital::Erroneous input format array with length:" + inputArray.Length);
                    return;
                }
                
                if (string.IsNullOrEmpty(inputArray[0]))
                {
                    recurso_codigo = Int32.MinValue;
                }
                else
                {
                    recurso_codigo = Convert.ToInt32(inputArray[0]);
                }

                recurso_nombre = inputArray[1].Trim();

                if (string.IsNullOrEmpty(inputArray[2]))
                {
                    recurso_provincia_codigo = Int32.MinValue;
                }
                else
                {
                    recurso_provincia_codigo = Convert.ToInt32(inputArray[2]);
                }

                if (string.IsNullOrEmpty(inputArray[3]))
                {
                    recurso_municipio_codigo = Int32.MinValue;
                }
                else
                {
                    recurso_municipio_codigo = Convert.ToInt32(inputArray[3]);
                }

                recurso_ccaa = inputArray[4].Trim();
                recurso_direccion = inputArray[5].Trim();
                recurso_ubicacion = inputArray[6].Trim();
                
            }
            catch (Exception exp)
            {
                ok = false;
                ncLog.Exception("hospital::" + exp.Message);
            }
        }

        public bool IsOk()
        {
            return ok;
        }

    }
}
