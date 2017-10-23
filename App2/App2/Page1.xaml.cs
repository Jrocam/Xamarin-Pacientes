using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public String nombrePaciente;
        public List<string> listDiagnosticos;
        public int id = 0;
        public Label n1, label;
        public Entry respuestaPj;
        IList<Diagnostico> diagnosticosList = new ObservableCollection<Diagnostico>();

        public Page1 (String nombre, List<String> diagnosticos)
		{

            nombrePaciente = nombre;
            listDiagnosticos = diagnosticos;
            BindingContext = diagnosticosList;

            foreach (var diagnostico in listDiagnosticos)
            {
                diagnosticosList.Add(new Diagnostico() { textoDiagnostico = diagnostico });
            }
            InitializeComponent ();
 
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            diagnosticosList.Add(new Diagnostico() { textoDiagnostico = "Allright allright allright" });
            id++;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }
            Diagnostico data = e.SelectedItem as Diagnostico;
            DisplayAlert("Diagnostico", "x:" + data.textoDiagnostico, "Ok");
            ((ListView)sender).SelectedItem = null;
            
        }

    }
}