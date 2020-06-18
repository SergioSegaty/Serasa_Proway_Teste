using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dominio.Modelos
{
    public class Empresa : Base
    {
        public Empresa()
        {
            Rating = 50;
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; protected set; }
        [Column(TypeName = "varchar(55)")]
        public string Nome { get; set; }

        public int NotasEsteMes { get; private set; }
        public int DebitosEsteMes { get; private set; }

        public ICollection<Debito> Debitos { get; set; }
        public ICollection<NotaFiscal> NotasFicais { get; set; }

        public (string mensagem, bool sucesso) AdicionarDebito()
        {
            var validador = new ValidadorStruct();

            if (Rating <= 1)
            {
                Rating = 1;
                return validador.Validar("Debito adicionado, mas a Pontuação não pode ser menor que 1", false);
            }

            Rating = Math.Round((Rating * 0.96m), MidpointRounding.ToPositiveInfinity);
            return validador.Validar("Debito adicionado, Pontuação recalculada", true);
        }

        public void ContarNotasEDebitos()
        {
            NotasEsteMes = NotasFicais.Where(n => n.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).Count();
            DebitosEsteMes = Debitos.Where(d => d.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).Count();
        }
       

        public (string mensagem, bool sucesso) AdicionarNotaFiscal()
        {
            var validador = new ValidadorStruct();

            if (Rating >= 100)
            {
                Rating = 100;
                return validador.Validar("Nota Fiscal adiconada, mas a Pontuação não pode ser maior que 100", false);
            }

            Rating = Math.Round((Rating * 1.02m), MidpointRounding.ToNegativeInfinity);
            return validador.Validar("Nota Fiscal adicionada, Pontuação recalculada", true);
        }

        public void SetUpParaTeste_Debito()
        {
            Rating = 1;
        }

        public void SetUpParaTeste_NotaFiscal()
        {
            Rating = 100;
        }
    }
}
