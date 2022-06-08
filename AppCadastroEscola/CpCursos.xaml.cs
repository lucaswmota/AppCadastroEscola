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
    public partial class CpCursos : ContentPage
    {

        List<Curso> cursos = new List<Curso>();

        public CpCursos()
        {
            InitializeComponent();

            lstCursos.ItemsSource = cursos;
        }

        private void sbCursos_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstCursos.ItemsSource=cursos.Where(
                x=>x.curso.ToUpper().Contains(sbCursos.Text.ToUpper()));
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            Curso C = new Curso();
            C.curso = txtCurso.Text.ToUpper();

            cursos.Add(C);

            lstCursos.ItemsSource = null;
            lstCursos.ItemsSource = cursos;

            txtCurso.Text = "";
            txtCurso.Focus();
        }

        async void lstCursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var v = e.SelectedItem as Curso;

            var resp = await DisplayAlert("Exclusão", "Deseja Excluir o Curso: " + v.curso + "?", "Sim", "Não");

            if(resp)
            {
                var item = cursos.Find(x => x.curso == v.curso);
                cursos.Remove(item);
                lstCursos.ItemsSource = null;
                lstCursos.ItemsSource = cursos;
            }
            txtCurso.Focus();

        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}