using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCadastroEscola
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnAluno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CpAlunos());
        }

        async void btnProfessores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CpProfessores());
        }

        async void btnCursos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CpCursos());
        }

        async void btnDisciplinas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CpDisciplinas());
        }
    }
}
