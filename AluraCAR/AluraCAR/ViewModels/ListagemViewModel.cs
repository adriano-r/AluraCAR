using AluraCAR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace AluraCAR.ViewModels
{
    public class ListagemViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        public List<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get {  return veiculoSelecionado;}
            set 
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var veiculoJson in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo { Nome = veiculoJson.nome, Preco = veiculoJson.preco });
            }
        }
    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
