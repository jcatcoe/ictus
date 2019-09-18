using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class ictusDataTMP2
    {
        public ObjectId Id { get; set; }
        public long pacienteID { get; set; }
        public int anyo{ get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string cie { get; set; }

        //Hospital
        public int hospital_codigo { get; set; }
        public string hospital_nombre { get; set; }
        public int hospital_provincia_codigo { get; set; }
        public int hospital_municipio_codigo { get; set; }
        public string hospital_ccaa { get; set; }
        public string hospital_direccion { get; set; }
        public string hospital_ubicacion { get; set; }

        //ZBS
        public int zbs_codigo { get; set; }
        public string zbs_nombre { get; set; }
        public string zbs_tipo { get; set; }
        public int zbs_provincia_codigo { get; set; }
        public string zbs_area { get; set; }
        public int zbs_tis { get; set; }
        public string zbs_delimitacion { get; set; }

        //USVB
        public int usvb_codigo { get; set; }
        public string usvb_nombre { get; set; }
        public int usvb_provincia_codigo { get; set; }
        public int usvb_municipio_codigo { get; set; }
        public string usvb_rural_urbano { get; set; }
        public string usvb_direccion { get; set; }

        //Tiempos UME
        public int ume_tmp_activacion { get; set; }
        public int ume_tmp_trayecto { get; set; }
        public int ume_tmp_estabilizacion { get; set; }
        public int ume_tmp_traslado { get; set; }
        public int ume_tmp_trasferencia { get; set; }

        //Tiempo SVB
        public int svb_tmp_activacion { get; set; }
        public int svb_tmp_trayecto { get; set; }
        public int svb_tmp_estabilizacion { get; set; }
        public int svb_tmp_traslado { get; set; }
        public int svb_tmp_trasferencia { get; set; }

        //Tiempo Helicoptero
        public int heli_tmp_activacion { get; set; }
        public int heli_tmp_trayecto { get; set; }
        public int heli_tmp_estabilizacion { get; set; }
        public int heli_tmp_traslado { get; set; }
        public int heli_tmp_trasferencia { get; set; }

        //Tiempo Atencion Primaria y Otros
        public int attpri_tmp_activacion { get; set; }
        public int attpri_tmp_trayecto { get; set; }
        public int attpri_tmp_estabilizacion { get; set; }
        public int attpri_tmp_traslado { get; set; }
        public int attpri_tmp_trasferencia { get; set; }

        internal bool ok { get; set; }

        public ictusDataTMP2(ictusDataTMP ictusData)
        {
            try
            {
                pacienteID = ictusData.pacienteID;
                anyo = ictusData.fecha.Year;
                sexo = ictusData.sexo;
                edad = ictusData.edad;
                cie = ictusData.cie;


                hospital_codigo = ictusData.hospital_codigo;
                hospital_nombre = ictusData.hospital_nombre;
                hospital_provincia_codigo = ictusData.hospital_provincia_codigo;
                hospital_municipio_codigo = ictusData.hospital_municipio_codigo;
                hospital_ccaa = ictusData.hospital_ccaa;
                hospital_direccion = ictusData.hospital_direccion;
                hospital_ubicacion = ictusData.hospital_ubicacion;


                zbs_codigo = ictusData.zbs_codigo;
                zbs_nombre = ictusData.zbs_nombre;
                zbs_tipo = ictusData.zbs_tipo;
                zbs_provincia_codigo = ictusData.zbs_provincia_codigo;
                zbs_area = ictusData.zbs_area;
                zbs_tis = ictusData.zbs_tis;
                zbs_delimitacion = ictusData.zbs_delimitacion;


                usvb_codigo = ictusData.usvb_codigo;
                usvb_nombre = ictusData.usvb_nombre;
                usvb_provincia_codigo = ictusData.usvb_provincia_codigo;
                usvb_municipio_codigo = ictusData.usvb_municipio_codigo;
                usvb_rural_urbano = ictusData.usvb_rural_urbano;
                usvb_direccion = ictusData.usvb_direccion;


                ume_tmp_activacion = ictusData.ume_tmp_activacion;
                ume_tmp_trayecto = ictusData.ume_tmp_trayecto;
                ume_tmp_estabilizacion = ictusData.ume_tmp_estabilizacion;
                ume_tmp_traslado = ictusData.ume_tmp_traslado;
                ume_tmp_trasferencia = ictusData.ume_tmp_trasferencia;


                svb_tmp_activacion = ictusData.svb_tmp_activacion;
                svb_tmp_trayecto = ictusData.svb_tmp_trayecto;
                svb_tmp_estabilizacion = ictusData.svb_tmp_estabilizacion;
                svb_tmp_traslado = ictusData.svb_tmp_traslado;
                svb_tmp_trasferencia = ictusData.svb_tmp_trasferencia;


                heli_tmp_activacion = ictusData.heli_tmp_activacion;
                heli_tmp_trayecto = ictusData.heli_tmp_trayecto;
                heli_tmp_estabilizacion = ictusData.heli_tmp_estabilizacion;
                heli_tmp_traslado = ictusData.heli_tmp_traslado;
                heli_tmp_trasferencia = ictusData.heli_tmp_trasferencia;


                attpri_tmp_activacion = ictusData.attpri_tmp_activacion;
                attpri_tmp_trayecto = ictusData.attpri_tmp_trayecto;
                attpri_tmp_estabilizacion = ictusData.attpri_tmp_estabilizacion;
                attpri_tmp_traslado = ictusData.attpri_tmp_traslado;
                attpri_tmp_trasferencia = ictusData.attpri_tmp_trasferencia;

                ok = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("ictusDataTMP::" + exp.Message);
                ok = false;
            }
        }

        public bool IsOk()
        {
            return ok;
        }
    }
}
