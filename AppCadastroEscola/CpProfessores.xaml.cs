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
    public partial class CpProfessores : ContentPage
    {
        List<Professor> professores =new List<Professor>();

        public CpProfessores()
        {
            InitializeComponent();

            lstProfessores.ItemsSource = professores;
        }

        private void sbProfessores_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstProfessores.ItemsSource = professores.Where(
               X => X.nome.ToUpper().Contains(sbProfessores.Text.ToUpper()));
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            Professor P = new Professor();
            P.nome = txtNome.Text.ToUpper();
            P.idade = int.Parse(txtIdade.Text);

            professores.Add(P);

            lstProfessores.ItemsSource = null;
            lstProfessores.ItemsSource = professores;

            txtNome.Text = "";
            txtIdade.Text = "";
            txtNome.Focus();


        }

        async void lstProfessores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var v = e.SelectedItem as Professor;

            var resp = await DisplayAlert("Exclusão", "Deseja Excluir o(a) Professor(a) " + v.nome + "?", "Sim", "Não");

            if(resp)
            {
                var item = professores.Find(x => x.nome == v.nome);
                professores.Remove(item);
                lstProfessores.ItemsSource = null;
                lstProfessores.ItemsSource = professores;
            }
        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}