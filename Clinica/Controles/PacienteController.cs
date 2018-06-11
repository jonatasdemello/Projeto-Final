using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    class PacienteController
    {
        Modelos.HospitalContext ctx = new Modelos.HospitalContext();

        public void createPaciente(Modelos.Paciente Paciente)
        {
            Modelos.Paciente p = new Modelos.Paciente();
            p.Nome = Paciente.Nome;
            p.Nascimento = Paciente.Nascimento;
            p.Telefone = Paciente.Telefone;
            p.CPF = Paciente.CPF;
            p.Convenio = Paciente.Convenio;

            ctx.Pacientes.Add(p);
            ctx.SaveChanges();
        }

        public void deletePaciente(Modelos.Paciente Paciente)
        {
            if (Paciente.PacienteId != 0)
            {
                ctx.Pacientes.Remove(Paciente);
                ctx.SaveChanges();
            }
        }

        public IList<Modelos.Paciente> readPacientes()
        {
            var Pacientes = from Paciente in ctx.Pacientes select Paciente;
            return Pacientes.ToList();
        }

        public void updatePaciente(Modelos.Paciente Paciente)
        {
            var tempPaciente = ctx.Pacientes.SingleOrDefault(c => c.PacienteId == Paciente.PacienteId);
            tempPaciente.Nome = Paciente.Nome;
            tempPaciente.Nascimento = Paciente.Nascimento;
            tempPaciente.Telefone = Paciente.Telefone;
            tempPaciente.CPF = Paciente.CPF;
            tempPaciente.Convenio = Paciente.Convenio;
            ctx.SaveChanges();
        }
    }

}
