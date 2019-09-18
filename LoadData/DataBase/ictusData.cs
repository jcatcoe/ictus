using LoadData.Tools;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.DataBase
{
    public class ictusData
    {
        public ObjectId Id { get; set; }
        public long pacienteID { get; set; }
        public DateTime fecha { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string cie { get; set; }


        ////Hospital
       
        public hospital hospital { get; set; }

        ////ZBS
       
        public zbs zbs { get; set; }

        ////USVB
       
        public usvb usvb { get; set; }

        ////Tiempos UME
        
        public recurso umeRecurso { get; set; }

        ////Tiempo SVB
        
        public recurso svbRecurso { get; set; }

        ////Tiempo Helicoptero
        
        public recurso heliRecurso { get; set; }

        ////Tiempo Atencion Primaria y Otros
        
        public recurso attpriRecurso { get; set; }

        internal bool ok { get; set; }

        public ictusData(long npacienteID, umeDataTMP inputUmeDataTMP)
        {
            try
            {

                pacienteID = npacienteID;
                fecha = inputUmeDataTMP.inc_sello_temporal;
                sexo = inputUmeDataTMP.pac_sexo;
                edad = inputUmeDataTMP.edad;
                cie = inputUmeDataTMP.cie_codigo;


                //////////////////////////////////////HOSPITAL//////////////////////////////////////
                hospital hospitalFound = Util.FindHospitalByName(inputUmeDataTMP.dim_recurso_nombreHospital);

                if (hospitalFound == null)
                {
                    ncLog.Warning("ictusData::Unable to find hospital by name:" + inputUmeDataTMP.dim_recurso_nombreHospital);
                }
                else
                {
                    hospital = hospitalFound;
                }

                //////////////////////////////////////HOSPITAL//////////////////////////////////////

                //////////////////////////////////////ZBS//////////////////////////////////////
                zbs ZBSFound = Util.FindZBSByName(inputUmeDataTMP.dim_zbs_nombre);

                if (ZBSFound == null)
                {
                    ncLog.Warning("ictusData::Unable to find ZBS by name:" + inputUmeDataTMP.dim_zbs_nombre);
                }
                else
                {
                    zbs = ZBSFound;
                }

                //////////////////////////////////////ZBS//////////////////////////////////////



                //////////////////////////////////////USVB//////////////////////////////////////
                usvb USVBFound = Util.FindUSVBByName(inputUmeDataTMP.dim_recurso_nombreUSVB);

                if (USVBFound == null)
                {
                    ncLog.Warning("ictusData::Unable to find USVB by name:" + inputUmeDataTMP.dim_recurso_nombreUSVB);
                }
                else
                {
                    usvb = USVBFound;
                }

                //////////////////////////////////////USVB//////////////////////////////////////

                ////Tiempos UME
                if (inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("UME") ||
                    inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("UVI") ||
                    inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("VIR"))
                {
                    umeRecurso = new recurso("UME", inputUmeDataTMP.act_tac, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_tes, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_trf);
                }

                //////Tiempo SVB
                else if (inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("SVB") ||
                    inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("ACU") ||
                    inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("SVBC"))
                {
                    umeRecurso = new recurso("SVB", inputUmeDataTMP.act_tac, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_tes, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_trf);
                }

                //////Tiempo Helicoptero
                else if (inputUmeDataTMP.dim_recurso_nombreUSVB.Contains("HELICOP"))
                {
                    heliRecurso = new recurso("Helicoptero", inputUmeDataTMP.act_tac, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_tes, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_trf);
                }

                //////Tiempo Atencion Primaria y Otros ("", CG, CL, CS, EES1, EES2, MEDICO, OTROS RECURSOS, PAC, PACIP, REFUERZO PUEBLA DE SANABRIA, REVE LEON, SUAP)
                else
                {
                    attpriRecurso = new recurso("ATTPRI", inputUmeDataTMP.act_tac, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_tes, inputUmeDataTMP.act_tra, inputUmeDataTMP.act_trf);
                }

                ok = true;
            }
            catch (Exception exp)
            {
                ncLog.Exception("ictusData::Unable to create new ictusData for pacienteID:" + npacienteID + "::" + exp.Message);
            }           
        }

        public ictusData(long npacienteID, List<umeDataTMP> umeDataTMPList)
        {
            try
            {
                if (umeDataTMPList == null || umeDataTMPList.Count() == 0)
                {
                    ncLog.Error("ictusData::Null or empty input umeDataTMP list");
                    ok = false;
                    return;
                }

                pacienteID = npacienteID;
                fecha = umeDataTMPList.FirstOrDefault().inc_sello_temporal;
                sexo = umeDataTMPList.FirstOrDefault().pac_sexo;
                edad = umeDataTMPList.FirstOrDefault().edad;
                cie = Util.GetCIECcode(umeDataTMPList);

                foreach (umeDataTMP iter in umeDataTMPList)
                {
                    //////////////////////////////////////HOSPITAL//////////////////////////////////////
                    hospital hospitalFound = Util.FindHospitalByName(iter.dim_recurso_nombreHospital);

                    if (hospitalFound == null)
                    {
                        //ncLog.Warning("ictusData::Unable to find hospital by name:" + iter.dim_recurso_nombreHospital);
                    }
                    else
                    {
                        hospital = hospitalFound;
                    }
                    //////////////////////////////////////HOSPITAL//////////////////////////////////////

                    //////////////////////////////////////ZBS//////////////////////////////////////
                    zbs ZBSFound = Util.FindZBSByName(iter.dim_zbs_nombre);

                    if (ZBSFound == null)
                    {
                        //ncLog.Warning("ictusData::Unable to find ZBS by name:" + iter.dim_zbs_nombre);
                    }
                    else
                    {
                        zbs = ZBSFound;
                    }
                    //////////////////////////////////////ZBS//////////////////////////////////////



                    //////////////////////////////////////USVB//////////////////////////////////////
                    usvb USVBFound = Util.FindUSVBByName(iter.dim_recurso_nombreUSVB);

                    if (USVBFound == null)
                    {
                        //ncLog.Warning("ictusData::Unable to find USVB by name:" + iter.dim_recurso_nombreUSVB);
                    }
                    else
                    {
                        usvb = USVBFound;
                    }
                    //////////////////////////////////////USVB//////////////////////////////////////

                    ////Tiempos UME
                    if (iter.dim_recurso_nombreUSVB.Contains("UME") ||
                        iter.dim_recurso_nombreUSVB.Contains("UVI") ||
                        iter.dim_recurso_nombreUSVB.Contains("VIR"))
                    {
                        if(umeRecurso != null)
                        {
                            ncLog.Error("ictusData:UME is already assigned for pacienteID:" + pacienteID);
                            ok = false;
                            return;
                        }

                        umeRecurso = new recurso("UME", iter.act_tac, iter.act_tra, iter.act_tes, iter.act_tra, iter.act_trf);
                    }

                    //////Tiempo SVB
                    else if (iter.dim_recurso_nombreUSVB.Contains("SVB") ||
                        iter.dim_recurso_nombreUSVB.Contains("ACU") ||
                        iter.dim_recurso_nombreUSVB.Contains("SVBC"))
                    {
                        if (svbRecurso != null)
                        {
                            ncLog.Error("ictusData:SVB is already assigned for pacienteID:" + pacienteID);
                            ok = false;
                            return;
                        }

                        svbRecurso = new recurso("SVB", iter.act_tac, iter.act_tra, iter.act_tes, iter.act_tra, iter.act_trf);
                    }

                    //////Tiempo Helicoptero
                    else if (iter.dim_recurso_nombreUSVB.Contains("HELICOP"))
                    {
                        if (heliRecurso != null)
                        {
                            ncLog.Error("ictusData:Helicoptero is already assigned for pacienteID:" + pacienteID);
                            ok = false;
                            return;
                        }

                        heliRecurso = new recurso("Helicoptero", iter.act_tac, iter.act_tra, iter.act_tes, iter.act_tra, iter.act_trf);
                    }

                    //////Tiempo Atencion Primaria y Otros ("", CG, CL, CS, EES1, EES2, MEDICO, OTROS RECURSOS, PAC, PACIP, REFUERZO PUEBLA DE SANABRIA, REVE LEON, SUAP)
                    else
                    {
                        if (attpriRecurso != null)
                        {
                            ncLog.Error("ictusData:Primary care is already assigned for pacienteID:" + pacienteID);
                            ok = false;
                            return;
                        }

                        attpriRecurso = new recurso("ATTPRI", iter.act_tac, iter.act_tra, iter.act_tes, iter.act_tra, iter.act_trf);
                    }

                    ok = true;
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("ictusData::Unable to create new ictusData for pacienteID:" + npacienteID + "::" + exp.Message);
                ok = false;
            }
        }

        public bool IsOk()
        {
            return ok;
        }
    }


    public class tiempo
    {
        public ObjectId Id { get; set; }
        public string tipo { get; set; }
        public int valor { get; set; }

        public tiempo(string ntipo)
        {
            tipo = ntipo;
        }

        public tiempo(string ntipo, int nvalor)
        {
            tipo = ntipo;
            valor = nvalor;
        }
    }

    public class recurso
    {
        public ObjectId Id { get; set; }
        public string tipo { get; set; }
        public List<tiempo> tiempos { get; set; }

        public recurso(string ntipo)
        {
            tipo = ntipo;
            tiempos = new List<tiempo>(4) { new tiempo("UME"), new tiempo("SVB"), new tiempo("HELI"), new tiempo("ATTPRI") };

        }
        public recurso(string ntipo, int tmp_activacion, int tmp_trayecto, int tmp_estabilizacion, int tmp_traslado, int tmp_trasferencia)
        {
            tipo = ntipo;
            tiempos = new List<tiempo>();
            tiempo act = new tiempo("activacion", tmp_activacion);
            tiempos.Add(act);
            tiempo tray = new tiempo("trayecto", tmp_trayecto);
            tiempos.Add(tray);
            tiempo estab = new tiempo("estabilizacion", tmp_estabilizacion);
            tiempos.Add(estab);
            tiempo tras = new tiempo("traslado", tmp_traslado);
            tiempos.Add(tras);
            tiempo traf = new tiempo("trasferencia", tmp_trasferencia);
            tiempos.Add(traf);


        }
        public recurso(string ntipo, List<tiempo>ntiempos)
        {
            tipo = ntipo;
            tiempos = ntiempos;

        }
    }
}
