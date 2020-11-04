using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMatriculaV5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        FirebaseHelper FireBaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var AllEstudiantes = await FireBaseHelper.GetAllEstudiantes().ConfigureAwait(true);
            ListEstudiantes.ItemsSource = AllEstudiantes;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await FireBaseHelper.AddEstudiante(Convert.ToInt32(txtId.Text), txtName.Text, txtApellido.Text, txtEnfermedad.Text, DateTime.Parse(txtNacimiento.Text), Convert.ToInt32(txtCedula.Text), Convert.ToInt32(txtTelefono.Text), txtCurso.Text, Convert.ToInt32(txtMonto.Text)).ConfigureAwait(true);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEnfermedad.Text = string.Empty;
            txtNacimiento.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCurso.Text = string.Empty;
            txtMonto.Text = string.Empty;

            await DisplayAlert("Exito", message: "Estudiante agregado exitosamente", "Ok").ConfigureAwait(true);
            var AllEstudiantes = await FireBaseHelper.GetAllEstudiantes().ConfigureAwait(true);
            ListEstudiantes.ItemsSource = AllEstudiantes;

        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var Estudiante = await FireBaseHelper.GetEstudiante(Convert.ToInt32(txtCedula)).ConfigureAwait(true);
            if (Estudiante != null)
            {
                txtId.Text = Estudiante.EstudianteId.ToString();
                txtName.Text = Estudiante.Nombre;
                txtApellido.Text = Estudiante.Apellido;
                txtEnfermedad.Text = Estudiante.Enfermedad;
                txtNacimiento.Text = Estudiante.FechaNacimiento.ToString();
                txtCedula.Text = Estudiante.Cedula.ToString();
                txtTelefono.Text = Estudiante.Telefono.ToString();
                txtCurso.Text = Estudiante.Curso;
                txtMonto.Text = Estudiante.MontoMatricula.ToString();

                await DisplayAlert("Exito", message: "Estudiante encontrado exitosamente", "Ok").ConfigureAwait(true);

            }
            else
            {

                await DisplayAlert("Exito", message: "No se ha encontrado estudiante", "Ok").ConfigureAwait(true);

            }

        
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {

            await FireBaseHelper.UpdateEstudiante(Convert.ToInt32(txtId.Text), txtName.Text, txtApellido.Text, txtEnfermedad.Text, DateTime.Parse(txtNacimiento.Text), Convert.ToInt32(txtCedula.Text), Convert.ToInt32(txtTelefono.Text), txtCurso.Text, Convert.ToInt32(txtMonto.Text)).ConfigureAwait(true);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEnfermedad.Text = string.Empty;
            txtNacimiento.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCurso.Text = string.Empty;
            txtMonto.Text = string.Empty;

            await DisplayAlert("Exito", message: "Estudiante actualizado con exito", "Ok").ConfigureAwait(true);
            var AllEstudiantes = await FireBaseHelper.GetAllEstudiantes().ConfigureAwait(true);
            ListEstudiantes.ItemsSource = AllEstudiantes;

        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {

            await FireBaseHelper.DeleteEstudiante(Convert.ToInt32(txtCedula.Text)).ConfigureAwait(true);
            await DisplayAlert("Exito", message: "Estudiante eliminado con exito", "Ok").ConfigureAwait(true);
            var AllEstudiantes = await FireBaseHelper.GetAllEstudiantes().ConfigureAwait(true);
            ListEstudiantes.ItemsSource = AllEstudiantes;
        }



    }
}
