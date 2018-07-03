using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Controles
{
    public class PacienteController
    {
        HospitalContext ctx = new HospitalContext();

        public void createPaciente(Paciente Paciente)
        {
            Paciente tempPaciente = new Paciente();
            tempPaciente.Nome = Paciente.Nome;
            tempPaciente.Nascimento = Paciente.Nascimento;
            tempPaciente.Telefone = Paciente.Telefone;
            tempPaciente.CPF = Paciente.CPF;
            tempPaciente.Convenio = Paciente.Convenio;

            if (tempPaciente.Convenio != null) { ctx.Entry(tempPaciente.Convenio).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.Pacientes.Add(tempPaciente);
            ctx.SaveChanges();
        }

        public void deletePaciente(Paciente Paciente)
        {
            if (Paciente.PacienteId != 0)
            {
                ctx.Pacientes.Remove(Paciente);
                ctx.SaveChanges();
            }
        }

        public IList<Paciente> readPacientes()
        {
            var Pacientes = (from Paciente in ctx.Pacientes select Paciente).ToList();
            foreach (var pac in Pacientes)
            {
                pac.Convenio = (from pc in ctx.Pacientes
                                join cv in ctx.Convenios on pc.Convenio.Id equals cv.Id
                                where pc.PacienteId == pac.PacienteId
                                select cv).SingleOrDefault();
            }
            return Pacientes;
        }

        public Paciente readPaciente(int pacienteId)
        {
            var tmpPaciente = (from Paciente in ctx.Pacientes
                              where Paciente.PacienteId == pacienteId
                              select Paciente).SingleOrDefault();

            tmpPaciente.Convenio = (from pc in ctx.Pacientes
                                    join cv in ctx.Convenios on pc.Convenio.Id equals cv.Id
                                    where pc.PacienteId == pacienteId
                                    select cv).SingleOrDefault();
            return tmpPaciente;
        }

        public void updatePaciente(Paciente Paciente)
        {
            var tempPaciente = ctx.Pacientes.SingleOrDefault(c => c.PacienteId == Paciente.PacienteId);

            tempPaciente.Nome = Paciente.Nome;
            tempPaciente.Nascimento = Paciente.Nascimento;
            tempPaciente.Telefone = Paciente.Telefone;
            tempPaciente.CPF = Paciente.CPF;
            tempPaciente.Convenio = Paciente.Convenio;

            if (tempPaciente.Convenio != null) { ctx.Entry(tempPaciente.Convenio).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.SaveChanges();
        }
    }

}
