using AppMatriculaV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMatriculaV5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

        public class ListMenu : Menu
        {

            public string Titulo { get; set; }
            public Page Pagina { get; set; }
        }

        public partial class MasterPage : MasterDetailPage
    {
        

            public MasterPage()
            {
            
                InitializeComponent();
                MainMenu();


           
            }


        public void MainMenu()
        {
            Detail = new NavigationPage(new MainPage());
            List<Menu> LMenu = new List<Menu>
            {
                new ListMenu { Pagina = new MainPage(), Titulo = "Gestion Estudiantes"}
            };
            ListViewMenu.ItemsSource = LMenu;
        }


        private void ListViewMenu_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

            var Menu = e.SelectedItem as ListMenu;
            if (Menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(Menu.Pagina);
            }

            ListViewMenu.SelectedItem = null;
        }


    }








    //ListMenu = new List<Menu>();
    //        ListMenu Page1 = new ListMenu() { Titulo = "Agregar Estudiante", Pagina = typeof(MainPage) };
    //ListMenu.Add(Page1);

    //        this.ListViewMenu.ItemsSource = ListMenu;

    //        Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
}