using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Validators
{
    public class ClienteValidator
    {
        private Dictionary<String, String> messages { get; set; }

        public ClienteValidator()
        {
            messages = new Dictionary<string, string>();
        }

        public bool Pass(Cliente cliente, Cliente exist)
        {
            ValidarDniRuc(cliente);
            ValidarDniRucExist(cliente, exist);

            return messages.Count == 0;
        }

        private void ValidarDniRuc(Cliente cliente)
        {
            var numdni = cliente.DniRuc.Length;

            if (numdni != 11)
            {
                if (numdni != 8)
                {
                    messages.Add("DniRuc", "Numero incorrecto de caracteres");
                }
            }
        }

        public void ValidarDniRucExist(Cliente cliente, Cliente exist)
        {
            if (exist != null)
            {
                messages.Add("DniRuc", "DniRuc ya registrado");
            }
        }

        public Dictionary<String, String> GetMensajes()
        {
            return messages;
        }
    }
}
