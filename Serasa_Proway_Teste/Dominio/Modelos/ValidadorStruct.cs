using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Modelos
{
    public struct ValidadorStruct
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public (string, bool) Validar(string mensagem, bool sucesso)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;

            return (Mensagem, Sucesso);
        }
    }
}
