using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AluraCAR
{
    public class GreetPage : ContentPage
    {
        public GreetPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "oiis to Xamarin.Forms!" }
                }
            };
        }
    }
}