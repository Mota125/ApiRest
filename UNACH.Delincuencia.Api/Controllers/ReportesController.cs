using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using UNACH.Delincuencia.Api.Models;
using System.Web.Http.Cors;

namespace UNACH.Delincuencia.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class ReportesController : ApiController
    {
        [Route("api/Reportes/ObtenerReportes")]
        [HttpGet]
        public List<table_reportes> GetTable_Reportes()
        {
            using (var conexion= new ModelDelincuencia())
            {
                var consulta =from r in conexion.table_reportes
                              select r;
                return consulta.ToList();
            }
        }

        [Route("api/Reportes/ObtenerPorFecha")]
        [HttpGet]
        public List<table_reportes>GetReportesOrdenados()
        {
            using(var conexion = new ModelDelincuencia())
            {
                var consulta = from r in conexion.table_reportes
                               orderby r.Fecha
                               select r;
                return consulta.ToList();
            }

        }

        [Route("api/Reportes/GuardarReporte")]
        [HttpPost]
        public bool PostDelincuencia(table_reportes Reportes)
        {
            try
            {
                using (var conexion = new ModelDelincuencia())
                {
                    conexion.table_reportes.Add(Reportes);
                    conexion.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        [Route("api/Reportes/ModificarReporte")]
        [HttpPut]
        public bool ModiReporte(table_reportes Reportes)
        {
            try
            {
                using (var conexion = new ModelDelincuencia())
                {
                    var consulta = (from r in conexion.table_reportes
                                    where r.Folio == Reportes.Folio
                                    select r).FirstOrDefault();

                    if (consulta != null)
                    {
                        consulta.Nombre = Reportes.Nombre;
                        consulta.Primer_ap = Reportes.Primer_ap;
                        consulta.Segundo_ap = Reportes.Segundo_ap;
                        consulta.Edad = Reportes.Edad;
                        consulta.Sexo = Reportes.Sexo;
                        consulta.Direccion = Reportes.Direccion;
                        consulta.Entidad = Reportes.Entidad;
                        consulta.Municipio = Reportes.Municipio;
                        consulta.Referencias = Reportes.Referencias;
                        consulta.Tipo = Reportes.Tipo;
                        consulta.Fecha = Reportes.Fecha;
                        consulta.Narracion = Reportes.Narracion;
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        [Route("api/Reportes/EliminarReporte")]
        [HttpDelete]
        public ReporteResponse DeleteReporte(int Folio)
        {
            ReporteResponse respuesta = new ReporteResponse();
            try
            {
                
                using (var conexion = new ModelDelincuencia())
                {
                    var consulta = (from r in conexion.table_reportes
                                    where r.Folio == Folio
                                    select r).FirstOrDefault();
                    if (consulta!=null)
                    {
                        conexion.table_reportes.Remove(consulta);
                        conexion.SaveChanges();
                        
                        respuesta.Exitoso = true;
                        respuesta.Mensaje="Se Elimino Correctamente el Reporte de: "+consulta.Nombre +" del Tipo "+ consulta.Tipo;
                        return respuesta;
                    }

                    else
                    {
                        respuesta.Exitoso = false;
                        respuesta.Mensaje = "El Reporte Solicitado No Se a Encontrado";
                        return respuesta;
                    }

                }

            }
            catch (Exception ex)
            {
                respuesta.Exitoso = false;
                respuesta.Mensaje = ex.Message;
                return respuesta;
            }
        }

    }
}
