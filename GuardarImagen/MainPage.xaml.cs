using SQLite;
using Plugin.Media;
using System.Runtime.CompilerServices;
using GuardarImagen.Models;
using GuardarImagen.Views;

namespace GuardarImagen
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        Plugin.Media.Abstractions.MediaFile img = null;

        public byte[] imgToArrayByte()
        {
            if(img != null)
            {
                using (MemoryStream memory = new MemoryStream()) {
                    Stream stream = img.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    return data;
                }
            }
            return null;
        }

        private async void CargarImagen_Clicked(object sender, EventArgs e)
        {
            try
            {
                img = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "MyImages",
                    Name = "Img.jpg",
                    SaveToAlbum = true
                });

                if (img != null)
                {
                    imagenPreview.Source = ImageSource.FromStream(() =>
                    {
                        return img.GetStream();
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void GuardarImagen_Clicked (Object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(nombreEntry.Text) && !string.IsNullOrWhiteSpace(descripcionEntry.Text) && img != null)
            {
                var images = new Images
                {
                    name = nombreEntry.Text,
                    description = descripcionEntry.Text,
                    image = imgToArrayByte(),
                };

                await App.instance.addImage(images);
                await DisplayAlert("Éxito", "La imagen se ha guardado con éxito.", "OK");

                nombreEntry.Text = string.Empty;
                descripcionEntry.Text = string.Empty;
                imagenPreview.Source = null;
            }
            else
            {
                await DisplayAlert("Advertencia", "Por favor, carga la imegen, ingresa el nombre y la descripción de la imagen.", "OK");
            }
        }

        private async void VerListaImagenes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListImgPage());
        }

    }
}