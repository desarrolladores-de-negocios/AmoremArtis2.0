﻿using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DropDownMenu;
using System.Windows.Threading;


namespace AmoremArtis
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniciarReloj();

            var menuCursos = new List<SubItem>();
            menuCursos.Add(new SubItem("Instrumentos", new UserControlInstrumentos()));
            menuCursos.Add(new SubItem("Secciones", new UserControlSeccion()));
            menuCursos.Add(new SubItem("Solfeo", new UserControlSolfeo()));
            var item1 = new ItemMenu("Cursos", menuCursos, PackIconKind.Piano);

            var menuAlumnos = new List<SubItem>();
            menuAlumnos.Add(new SubItem("Alumno", new UserControlInstrumentos()));
            menuAlumnos.Add(new SubItem("Secciones"));
            menuAlumnos.Add(new SubItem("Padres"));
            menuAlumnos.Add(new SubItem("Solfeo"));
            menuAlumnos.Add(new SubItem("Pagos"));
            var item2 = new ItemMenu("Alumnos", menuAlumnos, PackIconKind.Person);

            var menuMaestros = new List<SubItem>();
            menuMaestros.Add(new SubItem("Maestros", new UserControlInstrumentos()));
            menuMaestros.Add(new SubItem("Secciones"));
            menuMaestros.Add(new SubItem("Solfeo"));
            menuMaestros.Add(new SubItem("Pagos"));
            var item3 = new ItemMenu("Maestros", menuMaestros, PackIconKind.Teacher);

            var menuUsuarios = new List<SubItem>();
            menuUsuarios.Add(new SubItem("Ver Usuarios", new UserControlInstrumentos()));
            menuUsuarios.Add(new SubItem("Agregar Usuario"));
            menuUsuarios.Add(new SubItem("Quitar Usuario"));
            var item4 = new ItemMenu("Usuarios", menuUsuarios, PackIconKind.User);

        /*    Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));*/

        }
        private void IniciarReloj()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            dateText.Text = DateTime.Now.ToString();
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(screen);
            }
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("Realmente desea cerrar sesion?", "Consulta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                log.Show();
                this.Close();
            }
            else
            {
                //No hace nada
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente desea salir?", "Consulta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
            else
            {
                //No hace nada
            }
        }
    }
}
