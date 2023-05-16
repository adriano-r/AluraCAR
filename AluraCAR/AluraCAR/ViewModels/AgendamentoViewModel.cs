using AluraCAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraCAR.ViewModels
{
    public class AgendamentoViewModel
    {
        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agedamento, "Agendamento");
            })
        }
        public ICommand AgendarCommand { get; set; }
    }
}
