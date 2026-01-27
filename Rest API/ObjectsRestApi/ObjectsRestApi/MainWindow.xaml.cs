using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObjectRestApi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            // URL de la API
            string apiUrl = "https://api.restful-api.dev/objects";

            try
            {
                ResultsListBox.Items.Clear();
                ResultsListBox.Items.Add("Cargando datos...");

                // Realizar la solicitud HTTP
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Leer y deserializar los datos JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiObject>>(jsonResponse);

                    // Limpiar y cargar datos en el ListBox
                    ResultsListBox.Items.Clear();
                    foreach (var obj in objects)
                    {
                        ResultsListBox.Items.Add($"ID: {obj.Id}, Name: {obj.Name}");
                    }
                }
                else
                {
                    ResultsListBox.Items.Clear();
                    ResultsListBox.Items.Add($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                ResultsListBox.Items.Clear();
                ResultsListBox.Items.Add($"Error al obtener datos: {ex.Message}");
            }
        }

        private async void AddObjectButton_Click(object sender, RoutedEventArgs e)
        {
            string apiUrl = "https://api.restful-api.dev/objects";

            // Datos del objeto a enviar
            var newObject = new
            {
                name = "Corsair Black Devil",
                data = new
                {
                    year = 2020,
                    price = 3600,
                    CPU_model = "Intel Core i9",
                    Hard_disk_size = "2 TB"
                }
            };

            try
            {
                HttpClient client = new HttpClient();
                //Serialización del objeto para realizar la llamada
                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(newObject);


                // Crear el contenido de la solicitud POST
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PostResultTextBox.Text = $"Objeto añadido correctamente: {jsonResponse}";
                }
                else
                {
                    PostResultTextBox.Text = $"Error al añadir objeto: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                PostResultTextBox.Text = $"Error: {ex.Message}";
            }
        }

        private async void DeleteObjectByPostButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultsListBox.SelectedItem != null)
            {
                // Obtener el ID del objeto seleccionado
                string selectedItem = ResultsListBox.SelectedItem.ToString();
                string objectId = selectedItem.Split(':')[1].Trim();
                objectId = objectId.Split(',')[0].Trim();


                string apiUrl = $"https://api.restful-api.dev/objects/{objectId}";

                try
                {
                    HttpClient client = new HttpClient();
                    // Crear un contenido vacío para la solicitud POST
                    StringContent content = new StringContent("", Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST para eliminar
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        PostResultTextBox.Text = $"Objeto con ID {objectId} eliminado correctamente: {jsonResponse}";

                        // Remover el objeto eliminado del ListBox
                        ResultsListBox.Items.Remove(objectId);
                    }
                    else
                    {
                        PostResultTextBox.Text = $"Error al eliminar objeto: {response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    PostResultTextBox.Text = $"Error: {ex.Message}";
                }
            }
        }
    }

    // Clase para deserializar los datos de la API
    public class ApiObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
