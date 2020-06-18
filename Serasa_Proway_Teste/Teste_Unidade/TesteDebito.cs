using Dominio.Modelos;
using System;
using Xunit;

namespace Teste_Unidade
{
    public class TesteDebito
    {
        [Fact]
        public void Caso_RatingMenor_Que_1_RetornarFalso()
        {
            Empresa empresa = new Empresa();
            empresa.SetUpParaTeste_Debito();

            var respota = empresa.AdicionarDebito();

            Assert.False(respota.sucesso);
        }

        [Fact]
        public void Caso_RatingMaior_Que_1_RetornarVerdadeiro()
        {
            Empresa empresa = new Empresa();
            var resposta = empresa.AdicionarDebito();

            Assert.True(resposta.sucesso);
        }
    }
}
