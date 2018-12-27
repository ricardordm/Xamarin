using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //toda a lógica aqui
            //validar dados
            string cep = CEP.Text.Trim();// retira os espaços em branco
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end.cep == null)
                    {
                        DisplayAlert("Erro", "Cep inválido pra " + CEP.Text, "ok");
                      
                    }
                    else
                    RESULTADO.Text = string.Format("Endereço \nBairro: {3} \nCidade: {0},{1}\nRua: {2} ", end.localidade, end.uf, end.logradouro, end.bairro);
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO", e.Message, "OK");

                }
            }
        }
    private bool isValidCEP(string cep)
    {
            bool valido = true;
            if (cep.Length != 8)
            {
                //erro
                DisplayAlert("Erro", "CEP inválido. O cep deve ter 8 caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))//checa se é numerico e se for retorna na variavel novocep
            {
                //erro
                DisplayAlert("Erro", "CEP inválido. CEP deve conter apenas números", "OK");
                valido = false;
            }
            return valido;
    }
    }
}
