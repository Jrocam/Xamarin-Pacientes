using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{

    public partial class MainPage : ContentPage
    {
        public float clickTotal = 0;
        public string partidas = "";
        public Label label;
        public Picker partidasPicker;
        public Entry nombreEntry;
        public int id = 0;
        IList<Paciente> pacientesList = new ObservableCollection<Paciente>();

        public MainPage(Boolean gano, string partidas, int puntos )
        {

            BindingContext = pacientesList;
            InitializeComponent();
            //ListView pacientesView= new ListView();

            //pacientesView.ItemsSource = pacientesList;

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var list = new List<string>
            {
                " Es un primate! "
            };
            pacientesList.Add(new Paciente() { Nombre = "Mr. Mono "+ id, UltimoDiagnos = "Whatever", Diagnosticos = list });
            id++;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }
            Paciente data = e.SelectedItem as Paciente;
            //DisplayAlert("Paciente", "nombre:" + data.Nombre, "Ir");
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new Page1(data.Nombre, data.Diagnosticos));
        }
    }

}
