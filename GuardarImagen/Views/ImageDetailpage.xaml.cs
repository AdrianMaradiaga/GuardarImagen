namespace GuardarImagen.Views;
using GuardarImagen.Controllers;
public partial class ImageDetailpage : ContentPage
{
    private byte[] imageBytes;

    public ImageDetailpage(byte[] image)
    {
        InitializeComponent();
        imageBytes = image;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (imageBytes != null)
        {
            fullScreenImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }

} 