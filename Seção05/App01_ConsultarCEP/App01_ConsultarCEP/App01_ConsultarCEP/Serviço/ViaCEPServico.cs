using System;
using System.Collections.Generic;
using System.Text;
using System.Net; //serve para acessar dados na internet
using App01_ConsultarCEP.Serviço.Modelo;
using Newtonsoft.Json;//serve para deserializar

namespace App01_ConsultarCEP.Serviço
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
           
        
            return end;
        }
    }
}
