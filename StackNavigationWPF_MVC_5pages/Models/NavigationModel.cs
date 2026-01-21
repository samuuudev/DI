namespace StackNavigationWPF.Models
{
    // Modelo que podría guardar información sobre la navegación
    // Por ahora solo tiene la propiedad CanGoBack (no se usa visualmente)
    public class NavigationModel
    {
        public bool CanGoBack { get; set; } // Estado para volver atrás
    }
}