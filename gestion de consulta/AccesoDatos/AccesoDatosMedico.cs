﻿using System;
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

    }
}