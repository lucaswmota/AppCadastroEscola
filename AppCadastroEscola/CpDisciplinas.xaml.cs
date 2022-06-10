using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCadastroEscola
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CpDisciplinas : ContentPage
    {

        List<Disciplina> disciplinas = new List<Disciplina>();

        public CpDisciplinas()
        {
            InitializeComponent();

            lstDisciplinas.ItemsSource=disciplinas;
        }

        private void sbDisciplinas_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstDisciplinas.ItemsSource = disciplinas.Where(
                x => x.disciplina.ToUpper().Contains(sbDisciplinas.Text.ToUpper()));
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            Disciplina D = new Disciplina();
            D.disciplina = txtDisciplina.Text.ToUpper();

            disciplinas.Add(D);

            lstDisciplinas.ItemsSource = null;
            lstDisciplinas.ItemsSource = disciplinas;

            txtDisciplina.Text = "";
            txtDisciplina.Focus();
        }

        async void lstDisciplinas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var v = e.SelectedItem as Disciplina;

            var resp = await DisplayAlert("Exclusão", "Deseja Excluir a Disciplina: " + v.disciplina + "?", "Sim", "Não");

            if(resp)
            {
                var item = disciplinas.Find(x => x.disciplina == v.disciplina);
                disciplinas.Remove(item);
                lstDisciplinas.ItemsSource = null;
                lstDisciplinas.ItemsSource= disciplinas;
            }
            txtDisciplina.Focus();
        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}