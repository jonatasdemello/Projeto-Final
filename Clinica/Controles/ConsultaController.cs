using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Controles
{
    public class ConsultaController
    {
        HospitalContext ctx = new HospitalContext();

        public void createConsulta(Consulta consulta)
        {
            Consulta tempConsulta = new Consulta();
            tempConsulta.Hora = consulta.Hora;
            tempConsulta.Medico = consulta.Medico;
            tempConsulta.Paciente = consulta.Paciente;
            tempConsulta.Secretaria = consulta.Secretaria;

            if (tempConsulta.Medico != null) { ctx.Entry(tempConsulta.Medico).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempConsulta.Paciente != null) { ctx.Entry(tempConsulta.Paciente).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempConsulta.Secretaria != null) { ctx.Entry(tempConsulta.Secretaria).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.Consultas.Add(tempConsulta);
            ctx.SaveChanges();
        }

        public IList<Consulta> readConsultas()
        {
            var consultas = (from consulta in ctx.Consultas select consulta).ToList();

            foreach (var ct in consultas)
            {
                ct.Medico = (from cs in ctx.Consultas
                             join med in ctx.Medicos on cs.Medico.MedicoId equals med.MedicoId
                             where cs.Id == ct.Id
                             select med).SingleOrDefault();

                ct.Secretaria = (from cs in ctx.Consultas
                                 join sc in ctx.Secretarias on cs.Secretaria.SecretariaId equals sc.SecretariaId
                                 where cs.Id == ct.Id
                                 select sc).SingleOrDefault();

                ct.Paciente = (from cs in ctx.Consultas
                               join pc in ctx.Pacientes on cs.Paciente.PacienteId equals pc.PacienteId
                               where cs.Id == ct.Id
                               select pc).SingleOrDefault();
            }

            return consultas;
        }

        public Consulta readConsulta(int consultaId)
        {
            var tempConsulta = (from consulta in ctx.Consultas
                            where consulta.Id == consultaId
                            select consulta).SingleOrDefault();

            tempConsulta.Medico = (from cs in ctx.Consultas
                                   join med in ctx.Medicos on cs.Medico.MedicoId equals med.MedicoId
                                   where cs.Id == consultaId
                                   select med).SingleOrDefault();

            tempConsulta.Secretaria = (from cs in ctx.Consultas
                                     join sc in ctx.Secretarias on cs.Secretaria.SecretariaId equals sc.SecretariaId
                                     where cs.Id == consultaId
                                     select sc).SingleOrDefault();

            tempConsulta.Paciente = (from cs in ctx.Consultas
                                       join pc in ctx.Pacientes on cs.Paciente.PacienteId equals pc.PacienteId
                                       where cs.Id == consultaId
                                       select pc).SingleOrDefault();


            return tempConsulta;
        }

        public void updateConsulta(Consulta Consulta)
        {
            //var tempMedico = ctx.Medicos.SingleOrDefault(c => c.MedicoId == Consulta.Medico.MedicoId);
            //var tempPaciente = ctx.Pacientes.SingleOrDefault(c => c.PacienteId == Consulta.Paciente.PacienteId);
            //var tempSecretaria = ctx.Secretarias.SingleOrDefault(c => c.SecretariaId == Consulta.Secretaria.SecretariaId);

            //ctx.Consultas.Attach(Consulta);
            //ctx.Entry(Consulta).State = System.Data.Entity.EntityState.Unchanged;

            var tempConsulta = ctx.Consultas.SingleOrDefault(c => c.Id == Consulta.Id);

            tempConsulta.Medico = Consulta.Medico;
            tempConsulta.Paciente = Consulta.Paciente;
            tempConsulta.Secretaria = Consulta.Secretaria;
            tempConsulta.Hora = Consulta.Hora;

            ctx.Medicos.Attach(Consulta.Medico);
            ctx.Pacientes.Attach(Consulta.Paciente);
            ctx.Secretarias.Attach(Consulta.Secretaria);

            if (tempConsulta.Medico != null) { ctx.Entry(tempConsulta.Medico).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempConsulta.Paciente != null) { ctx.Entry(tempConsulta.Paciente).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempConsulta.Secretaria != null) { ctx.Entry(tempConsulta.Secretaria).State = System.Data.Entity.EntityState.Unchanged; }

            //if (Consulta.Medico != null) { ctx.Entry(Consulta.Medico).State = System.Data.Entity.EntityState.Unchanged; }
            //if (Consulta.Paciente != null) { ctx.Entry(Consulta.Paciente).State = System.Data.Entity.EntityState.Unchanged; }
            //if (Consulta.Secretaria != null) { ctx.Entry(Consulta.Secretaria).State = System.Data.Entity.EntityState.Unchanged; }

            //ctx.Entry(Consulta).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }

        public void deleteConsulta(Consulta Consulta)
        {
            if (Consulta.Id != 0)
            {
                ctx.Consultas.Remove(Consulta);
                ctx.SaveChanges();
            }
        }
    }

}
