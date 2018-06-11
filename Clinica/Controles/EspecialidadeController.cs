using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    class EspecialidadeController
    {
        Modelos.HospitalContext ctx = new Modelos.HospitalContext();

        public void createEspecialidade(String nome, float valor)
        {
            Modelos.Especialidade esp = new Modelos.Especialidade();
            esp.Nome = nome;
            esp.Valor = valor;

            ctx.Especialidades.Add(esp);
            ctx.SaveChanges();
        }

        public void populateEspecialidades()
        {
            this.createEspecialidade("Gastro", 7000);
            this.createEspecialidade("Cirurgião Plástico", 11000);
            this.createEspecialidade("Endocrino", 5000);
        }

        public IList<Modelos.Especialidade> readEspecialidades()
        {
            var especialidades = from especialidade in ctx.Especialidades select especialidade;
            return especialidades.ToList();
        }

        public Modelos.Especialidade getEspecialidade(int index)
        {
            var especialidades = from especialidade in ctx.Especialidades where especialidade.Id == index select especialidade;
            return (Modelos.Especialidade)especialidades;
        }

    }
}