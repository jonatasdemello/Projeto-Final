using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    class ConsultaController
    {
        Modelos.HospitalContext ctx = new Modelos.HospitalContext();

        public void createConsulta(Modelos.Consulta consulta)
        {
            Modelos.Consulta c = new Modelos.Consulta();
            c.Hora = consulta.Hora;
            c.Medico = consulta.Medico;
            c.Paciente = consulta.Paciente;
            c.Secretaria = consulta.Secretaria;

            ctx.Consultas.Add(c);
            ctx.SaveChanges();
        }

        public IList<Modelos.Consulta> readConsulta()
        {
            var consultas = from consulta in ctx.Consultas select consulta;
            return consultas.ToList();
        }

        public void updateConsulta(Modelos.Consulta Consulta)
        {
            var tempConsulta = ctx.Consultas.SingleOrDefault(c => c.Id == Consulta.Id);
            tempConsulta.Medico = Consulta.Medico;
            tempConsulta.Paciente = Consulta.Paciente;
            tempConsulta.Secretaria = Consulta.Secretaria;
            tempConsulta.Hora = Consulta.Hora;
            ctx.SaveChanges();
        }

        public void deleteConsulta(Modelos.Consulta Consulta)
        {
            if (Consulta.Id != 0)
            {
                ctx.Consultas.Remove(Consulta);
                ctx.SaveChanges();
            }
        }
    }

}
