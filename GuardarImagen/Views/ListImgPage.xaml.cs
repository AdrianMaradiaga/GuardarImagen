using GuardarImagen.Models;

namespace GuardarImagen.Views;

public partial class ListImgPage : ContentPage
{
    List<Images> imagesList;
    public static byte[] tempImg;


    public ListImgPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        imagesList = await App.instance.getImages();
        imageCollection.ItemsSource = imagesList;
    }



    private void OnViewImageClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedItem = button?.BindingContext as Images;

        if (selectedItem != null)
        {
            Navigation.PushAsync(new ImageDetailpage(selectedItem.image));
        }
    }
}