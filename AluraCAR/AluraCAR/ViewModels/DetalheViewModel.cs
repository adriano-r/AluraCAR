﻿using AluraCAR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraCAR.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS => string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
        public string TextoArCondicionado => string.Format("Ar Condicionado- R$ {0}", Veiculo.AR_CONDICIONADO);
        public string TextoMP3Player => string.Format("MP3 Player - R$ {0}", Veiculo.MP3_PLAYER);

        public bool TemFreioABS
        {
            get { return Veiculo.TemFreioABS; }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get { return Veiculo.TemArCondicionado; }
            set
            {
                TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMP3Player
        {
            get { return Veiculo.TemMP3Player; }
            set
            {
                Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new ICommand(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            })
        }
        public ICommand ProximoCommand { get; set; }

    }
}
