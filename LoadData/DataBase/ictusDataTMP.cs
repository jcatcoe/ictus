using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class ictusDataTMP
    {
        public ObjectId Id { get; set; }
        public long pacienteID { get; set; }
        public DateTime fecha { get; set; }
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

        public ictusDataTMP(ictusData ictusData)
        {
            try
            {
                pacienteID = ictusData.pacienteID;
                fecha = ictusData.fecha;
                sexo = ictusData.sexo;
                edad = ictusData.edad;
                cie = ictusData.cie;

                //Hospital

                if (ictusData.hospital != null)
                {
                    hospital_codigo = ictusData.hospital.recurso_codigo;
                    hospital_nombre = ictusData.hospital.recurso_nombre;
                    hospital_provincia_codigo = ictusData.hospital.recurso_provincia_codigo;
                    hospital_municipio_codigo = ictusData.hospital.recurso_municipio_codigo;
                    hospital_ccaa = ictusData.hospital.recurso_ccaa;
                    hospital_direccion = ictusData.hospital.recurso_direccion;
                    hospital_ubicacion = ictusData.hospital.recurso_ubicacion;
                }

                //ZBS

                if (ictusData.zbs != null)
                {
                    zbs_codigo = ictusData.zbs.codigo;
                    zbs_nombre = ictusData.zbs.nombre;
                    zbs_tipo = ictusData.zbs.tipo;
                    zbs_provincia_codigo = ictusData.zbs.provincia_codigo;
                    zbs_area = ictusData.zbs.area;
                    zbs_tis = ictusData.zbs.tis;
                    zbs_delimitacion = ictusData.zbs.delimitacion;
                }

                //USVB

                if (ictusData.usvb != null)
                {
                    usvb_codigo = ictusData.usvb.recurso_codigo;
                    usvb_nombre = ictusData.usvb.recurso_nombre;
                    usvb_provincia_codigo = ictusData.usvb.recurso_provincia_codigo;
                    usvb_municipio_codigo = ictusData.usvb.recurso_municipio_codigo;
                    usvb_rural_urbano = ictusData.usvb.recurso_rural_urbano;
                    usvb_direccion = ictusData.usvb.recurso_direccion;
                }

                //Tiempos UME
                if (ictusData.umeRecurso != null)
                {
                    ume_tmp_activacion = ictusData.umeRecurso.tiempos.Where(x => x.tipo == "activacion").FirstOrDefault().valor;
                    ume_tmp_trayecto = ictusData.umeRecurso.tiempos.Where(x => x.tipo == "trayecto").FirstOrDefault().valor;
                    ume_tmp_estabilizacion = ictusData.umeRecurso.tiempos.Where(x => x.tipo == "estabilizacion").FirstOrDefault().valor;
                    ume_tmp_traslado = ictusData.umeRecurso.tiempos.Where(x => x.tipo == "traslado").FirstOrDefault().valor;
                    ume_tmp_trasferencia = ictusData.umeRecurso.tiempos.Where(x => x.tipo == "trasferencia").FirstOrDefault().valor;
                }

                //Tiempo SVB

                if (ictusData.svbRecurso != null)
                {
                    svb_tmp_activacion = ictusData.svbRecurso.tiempos.Where(x => x.tipo == "activacion").FirstOrDefault().valor;
                    svb_tmp_trayecto = ictusData.svbRecurso.tiempos.Where(x => x.tipo == "trayecto").FirstOrDefault().valor;
                    svb_tmp_estabilizacion = ictusData.svbRecurso.tiempos.Where(x => x.tipo == "estabilizacion").FirstOrDefault().valor;
                    svb_tmp_traslado = ictusData.svbRecurso.tiempos.Where(x => x.tipo == "traslado").FirstOrDefault().valor;
                    svb_tmp_trasferencia = ictusData.svbRecurso.tiempos.Where(x => x.tipo == "trasferencia").FirstOrDefault().valor;
                }

                //Tiempo Helicoptero

                if (ictusData.heliRecurso != null)
                {
                    heli_tmp_activacion = ictusData.heliRecurso.tiempos.Where(x => x.tipo == "activacion").FirstOrDefault().valor;
                    heli_tmp_trayecto = ictusData.heliRecurso.tiempos.Where(x => x.tipo == "trayecto").FirstOrDefault().valor;
                    heli_tmp_estabilizacion = ictusData.heliRecurso.tiempos.Where(x => x.tipo == "estabilizacion").FirstOrDefault().valor;
                    heli_tmp_traslado = ictusData.heliRecurso.tiempos.Where(x => x.tipo == "traslado").FirstOrDefault().valor;
                    heli_tmp_trasferencia = ictusData.heliRecurso.tiempos.Where(x => x.tipo == "trasferencia").FirstOrDefault().valor;
                }

                //Tiempo Atencion Primaria y Otros

                if (ictusData.attpriRecurso != null)
                {
                    attpri_tmp_activacion = ictusData.attpriRecurso.tiempos.Where(x => x.tipo == "activacion").FirstOrDefault().valor;
                    attpri_tmp_trayecto = ictusData.attpriRecurso.tiempos.Where(x => x.tipo == "trayecto").FirstOrDefault().valor;
                    attpri_tmp_estabilizacion = ictusData.attpriRecurso.tiempos.Where(x => x.tipo == "estabilizacion").FirstOrDefault().valor;
                    attpri_tmp_traslado = ictusData.attpriRecurso.tiempos.Where(x => x.tipo == "traslado").FirstOrDefault().valor;
                    attpri_tmp_trasferencia = ictusData.attpriRecurso.tiempos.Where(x => x.tipo == "trasferencia").FirstOrDefault().valor;
                }

                ok = true;
            }
            catch(Exception exp)
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
