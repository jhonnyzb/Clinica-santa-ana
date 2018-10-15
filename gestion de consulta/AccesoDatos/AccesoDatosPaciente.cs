using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_de_consulta.Models;

namespace gestion_de_consulta.AccesoDatos
{
    public class AccesoDatosPaciente
    {
       
        public string Agregar(usuarios usuario)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                var v_cedula = bdclinica.usuarios.Any(c => c.cedula == usuario.cedula);
                if (v_cedula)
                {
                    return "ya existe";
                }
                else
                {
                    bdclinica.usuarios.Add(usuario);
                    bdclinica.SaveChanges();
                    return "Save";
                }
            }
        }


        public IQueryable Horarios(horarios fecha)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                var query = from c in bdclinica.horarios
                            where c.estado_horario == 1 && c.fecha_horario == fecha.fecha_horario
                            select new
                            {
                                Codigo = c.id,
                                Nombre = c.horario
                            };


                return query;
            }
        }

        public string Agendar(horarios h, int cedula)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                horarios u = bdclinica.horarios.SingleOrDefault(x => x.fecha_horario == h.fecha_horario && x.horario == h.horario);
                usuarios m = bdclinica.usuarios.SingleOrDefault(x => x.cedula == u.cedula_medico);
                citas cita = new citas()
                {
                    cedula_usuario = cedula,
                    id_horario = u.id,
                    estado_cita = 1,
                    cedula_medico = u.cedula_medico
                };
                u.estado_horario = 0;
                bdclinica.citas.Add(cita);
                bdclinica.SaveChanges();
                return "Su cita quedo para el dia: " + h.fecha_horario + " Hora: " + h.horario + " no olvide llegar 30 minutos antes";
            }
        }


        public usuarios Obtener_usuario(int ced)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                usuarios usu = bdclinica.usuarios.SingleOrDefault(x => x.cedula == ced);
                return usu;
            }
        }


        public int ActualizarUsuario(usuarios usuario)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                usuarios u = bdclinica.usuarios.Find(usuario.cedula);
                u.nombres = usuario.nombres;
                u.apellidos = usuario.apellidos;
                u.clave = usuario.clave;
                u.telefono = usuario.telefono;
                u.correo = usuario.correo;
                bdclinica.SaveChanges();
                return 1;

            }
        }

        public int NumeroCitas(int cedula)
        {
            using (bd_clinicaEntities_ bdclinica = new bd_clinicaEntities_())
            {
                int NumeroCitas = bdclinica.citas.Count(x => x.cedula_usuario == cedula);

                return NumeroCitas;
            }
        }

        

    }
}