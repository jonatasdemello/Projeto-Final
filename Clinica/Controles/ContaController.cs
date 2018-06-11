﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    public class ContaController
    {
        Modelos.HospitalContext ctx = new Modelos.HospitalContext(); 
        
        public void createConta(String banco, String cc, int agencia)
        {
            Modelos.Conta c = new Modelos.Conta();
            c.Banco = banco;
            c.ContaCorrente = cc;
            c.Agencia = agencia;

            ctx.Contas.Add(c);
            ctx.SaveChanges();
        }

        public void populateContas()
        {
            this.createConta("BB", "1234", 1);
            this.createConta("Santander", "2345", 2);
            this.createConta("Bradesco", "3456", 3);
            this.createConta("Itaú", "4567", 4);
        }

        public IList<Modelos.Conta> readContas()
        {
            var contas = from conta in ctx.Contas select conta;
            return contas.ToList();
        }
    }

}
