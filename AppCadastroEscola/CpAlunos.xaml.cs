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
    public partial class CpAlunos : ContentPage
    {

        List<Aluno> alunos=new List<Aluno>();

        public CpAlunos()
        {
            InitializeComponent();

            lstAlunos.ItemsSource = alunos;
        }

        private void sbAlunos_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstAlunos.ItemsSource = alunos.Where(
                X => X.nome.ToUpper().Contains(sbAlunos.Text.ToUpper()));
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            Aluno A = new Aluno();
            A.nome = txtNome.Text.ToUpper();
            A.idade = int.Parse(txtIdade.Text);

            alunos.Add(A);

            lstAlunos.ItemsSource = null;
            lstAlunos.ItemsSource = alunos;

            txtNome.Text = "";
            txtIdade.Text = "";
            txtNome.Focus();
        }

        async void lstAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        var v=e.SelectedItem as Aluno;

            var resp = await DisplayAlert("Exclusão", "Deseja Excluir o(a) Aluno(a) " + v.nome + "?" , "Sim", "Não");

            if(resp)
            {
                var Item = alunos.Find(x => x.nome == v.nome);
                alunos.Remove(Item);
                lstAlunos.ItemsSource = null;
                lstAlunos.ItemsSource = alunos;
            }
        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}