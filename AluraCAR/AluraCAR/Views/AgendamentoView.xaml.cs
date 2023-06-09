﻿using AluraCAR.Models;
using AluraCAR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraCAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
                () =>
                {
                    DisplayAlert("Agendamento",
                    string.Format(
                    @"Veiculo: {0}
					Nome: {1}
					Fone: {2}
					Email: {3}
					Data Agendamento: {4}
					Hora Agendamento: {5}",
                    ViewModel.Agendamento.Veiculo.Nome,
                    ViewModel.Agendamento.Nome,
                    ViewModel.Agendamento.Fone,
                    ViewModel.Agendamento.Email,
                    ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                    ViewModel.Agendamento.HoraAgendamento),
                    "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento"); 
        }
    }
}