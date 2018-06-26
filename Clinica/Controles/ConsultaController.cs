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
            Consulta c = new Consulta();
            c.Hora = consulta.Hora;
            c.Medico = consulta.Medico;
            c.Paciente = consulta.Paciente;
            c.Secretaria = consulta.Secretaria;

            ctx.Consultas.Add(c);
            ctx.SaveChanges();
        }

        public IList<Consulta> readConsulta()
        {
            var consultas = from consulta in ctx.Consultas select consulta;
            return consultas.ToList();
        }

        public void updateConsulta(Consulta Consulta)
        {
            var tempConsulta = ctx.Consultas.SingleOrDefault(c => c.Id == Consulta.Id);
            tempConsulta.Medico = Consulta.Medico;
            tempConsulta.Paciente = Consulta.Paciente;
            tempConsulta.Secretaria = Consulta.Secretaria;
            tempConsulta.Hora = Consulta.Hora;
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
