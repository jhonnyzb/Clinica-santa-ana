using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_de_consulta.Models;

namespace gestion_de_consulta.AccesoDatos
{
    public class AccesoDatosMedico
    {

        public List<ConsultasGenerales> Consultar(int CedulaMedico)

        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {

                var citas = bdclinica.citas.Include("usuarios").Include("horarios").Where(f => f.cedula_medico == CedulaMedico && f.estado_cita == 1).Select(x => new ConsultasGenerales()
                {
                    Fecha = x.horarios.fecha_horario,
                    Hora = x.horarios.horario,
                    Identificacion = x.usuarios.cedula,
                    Nombres = x.usuarios.nombres + " " + x.usuarios.apellidos

                });

                return citas.ToList();
            }
        }

        public int N_citas_Medico(int cedula)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                string fecha = DateTime.Today.ToString("dd / MM / yyyy");
                int NumeroCitasMedico = bdclinica.horarios.Count(x => x.cedula_medico == cedula && x.fecha_horario == fecha && x.estado_horario == 0);
                return NumeroCitasMedico;
            }
        }

        public List<ConsultasGenerales> ConsultarHistoriales()

        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {

                var historiales = bdclinica.historial_clinico.Include("usuarios").Select(x => new ConsultasGenerales()
                {
                    Fecha = x.fecha_novedad,
                    Identificacion = x.cedula_paciente,
                    Nombres = x.usuarios.nombres,
                    Apellidos =x.usuarios.apellidos

                });

                return historiales.ToList();
            }
        }


        public List<ConsultasGenerales> ConsultarHistorial1(int CedulaPaciente)

        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {

                var historial = bdclinica.historial_clinico.Include("usuarios").Where(f => f.cedula_paciente == CedulaPaciente).Select(x => new ConsultasGenerales()
                {
                    Fecha = x.fecha_novedad,
                    Identificacion = x.cedula_paciente,
                    Motivo_Consulta = x.motivo_consulta,
                    Diagnostico =x.diagnostico,
                    Nombres = x.usuarios.nombres + " " + x.usuarios.apellidos
                });

                return historial.ToList();
            }
        }


        public IQueryable Medicamentos()
        {
            bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_();

            var query = from c in bdclinica.medicamentos
                        select new
                        {
                            Codigo = c.codigo_medicamento,
                            Nombre = c.nombre
                        };

            return query;

        }

        public IQueryable Examenes()
        {
            bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_();

            var query = from c in bdclinica.servicios
                        select new
                        {
                            Codigo = c.codigo_servicio,
                            Nombre = c.nombre_servicio
                        };

            return query;

        }

        public string GuardarHistorial(historial_clinico historial, int CedPaciente)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                historial_clinico histo = new historial_clinico
                {
                    cedula_paciente=CedPaciente,
                    antecedentes_familiares=historial.antecedentes_familiares,
                    antecedentes_personales=historial.antecedentes_personales,
                    cirugias=historial.cirugias,
                    enfermedades_cronicas=historial.enfermedades_cronicas,
                    fecha_novedad = DateTime.Today.ToString("dd / MM / yyyy"),
                    motivo_consulta=historial.motivo_consulta,
                    diagnostico=historial.diagnostico
            };
                bdclinica.historial_clinico.Add(histo);
                bdclinica.SaveChanges();
                return "s";
            }
        }
    }
}