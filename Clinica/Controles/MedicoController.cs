﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Controles
{
    public class MedicoController
    {
        private HospitalContext ctx = new HospitalContext();

        public void createMedico(Medico medico)
        {
            if (medico.conta != null) { ctx.Entry(medico.conta).State = System.Data.Entity.EntityState.Unchanged; }
            if (medico.Especialidade != null) { ctx.Entry(medico.Especialidade).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.Medicos.Add(medico);
            ctx.SaveChanges();
        }

        public void createMedico(String nome, DateTime nasc, String fone, String cpf, Conta conta, string crm, Especialidade especialidade, String turno)
        {
            var tempEspecialidade = ctx.Especialidades.SingleOrDefault(c => c.Id == especialidade.Id);
            var tempConta = ctx.Contas.SingleOrDefault(c => c.Id == conta.Id);

            Medico tempMedico = new Medico();
            tempMedico.Nome = nome;
            tempMedico.Nascimento = nasc;
            tempMedico.Telefone = fone;
            tempMedico.CPF = cpf;
            tempMedico.conta = conta;
            tempMedico.CRM = crm;
            tempMedico.Especialidade = especialidade;
            tempMedico.Turno = turno;

            ctx.Medicos.Add(tempMedico);

            if (tempMedico.conta != null) { ctx.Entry(tempMedico.conta).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempMedico.Especialidade != null) { ctx.Entry(tempMedico.Especialidade).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.SaveChanges();
        }

        public void deleteMedico(Medico medico)
        {
            if (medico.MedicoId != 0)
            {
                ctx.Medicos.Remove(medico);
                ctx.SaveChanges();
            }
        }

        public Medico readMedico(int medicoId)
        {
            var tempMedico = (from medico in ctx.Medicos
                             where medico.MedicoId == medicoId
                             select medico).SingleOrDefault();

            tempMedico.conta = (from conta in ctx.Contas
                                join medico in ctx.Medicos on conta.Id equals medico.conta.Id
                                where medico.MedicoId == medicoId
                                select conta).SingleOrDefault();

            tempMedico.Especialidade = (from especialidade in ctx.Especialidades
                                        join medico in ctx.Medicos on especialidade.Id equals medico.Especialidade.Id
                                        where medico.MedicoId == medicoId
                                        select especialidade).SingleOrDefault();

            return tempMedico;
        }

        public IList<Medico> readMedicos()
        {
            var medicos = (from medico in ctx.Medicos select medico).ToList();

            //foreach (var med in medicos)
            //{
            //    med.conta = (from conta in ctx.Contas
            //                 join medico in ctx.Medicos on conta.Id equals medico.conta.Id
            //                 where medico.MedicoId == med.MedicoId
            //                 select conta).SingleOrDefault();
            //    med.Especialidade = (from especialidade in ctx.Especialidades
            //                         join medico in ctx.Medicos on especialidade.Id equals medico.Especialidade.Id
            //                         where medico.MedicoId == med.MedicoId
            //                         select especialidade).SingleOrDefault();
            //}

            return medicos;
        }

        public void updateMedico(Medico medico)
        {
            var tempMedico = ctx.Medicos.SingleOrDefault(c => c.MedicoId == medico.MedicoId);

            tempMedico.Nome = medico.Nome;
            tempMedico.Nascimento = medico.Nascimento;
            tempMedico.Telefone = medico.Telefone;
            tempMedico.CPF = medico.CPF;
            tempMedico.conta = medico.conta;
            tempMedico.CRM = medico.CRM;
            tempMedico.Especialidade = medico.Especialidade;
            tempMedico.Turno = medico.Turno;

            if (tempMedico.conta != null) { ctx.Entry(tempMedico.conta).State = System.Data.Entity.EntityState.Unchanged; }
            if (tempMedico.Especialidade != null) { ctx.Entry(tempMedico.Especialidade).State = System.Data.Entity.EntityState.Unchanged; }

            ctx.SaveChanges();
        }
    }

}
