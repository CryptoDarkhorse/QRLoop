namespace MauiQRLoopDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

#if ANDROID
        var blazorWebView = (Microsoft.AspNetCore.Components.WebView.Maui.IBlazorWebView)Content;
        Content = new Platforms.Android.MauiBlazorWebView(blazorWebView.HostPage, blazorWebView.RootComponents);
#endif
    }
}
