using System;
using System.Windows;
using System.Windows.Controls;

namespace calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            crearBotones();
        }

        public void crearBotones()
        {
            // Crear botones para la calculadora: 3 columnas x 4 filas
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button boton = new Button
                    {
                        Width = 50,
                        Height = 40,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    if (i == 3)
                    {
                        // Última fila: botones especiales
                        switch (j)
                        {
                            case 0:
                                boton.Content = "=";
                                break;
                            case 1:
                                boton.Content = "0";
                                break;
                            case 2:
                                boton.Content = "C";
                                break;
                        }
                    }
                    else
                    {
                        // Botones del 1 al 9
                        int numero = (9 - (i * 3)) - (2 - j);
                        boton.Content = numero.ToString();
                    }

                    Grid.SetRow(boton, i);
                    Grid.SetColumn(boton, j);
                    contenedor.Children.Add(boton);
                }
            }
        }

        public void boton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic en los botones (pendiente de implementar)

        }
    }
}
