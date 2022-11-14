using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
		if (!isRandom)
		{
            double red = sldRed.Value;
            double green = sldGreen.Value;
            double blue = sldBlue.Value;


            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }


    }


	private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		lblHex.Text = color.ToHex();
		hexValue = color.ToHex();
	}

    void btnRandom_Clicked(System.Object sender, System.EventArgs e)
    {
		isRandom = true;
		var random = new Random();

		var color = Color.FromRgb(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256));

		SetColor(color);

		sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;

		isRandom = false;
    }

    private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color copied",
			CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
    }
}


