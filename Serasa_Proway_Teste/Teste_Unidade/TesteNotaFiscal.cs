using Dominio.Modelos;
using System;
using Xunit;

namespace Teste_Unidade
{
    public class TesteNotaFiscal
    {
        [Fact]
        public void Caso_RatingMaior_Que_100_RetornarFalso()
        {
            Empresa empresa = new Empresa();
            empresa.SetUpParaTeste_NotaFiscal();

            var respota = empresa.AdicionarNotaFiscal();

            Assert.False(respota.sucesso);
        }

        [Fact]
        public void Caso_RatingMenor_Que_100_RetornarVerdadeiro()
        {
            Empresa empresa = new Empresa();
            var resposta = empresa.AdicionarNotaFiscal();

            Assert.True(resposta.sucesso);
        }
    }
}
