#if ANDROID
using Android.Graphics;
using Android.OS;
using Android.Webkit;
using Microsoft.AspNetCore.Components.WebView.Maui;
using static Android.Webkit.WebChromeClient;

using AView = Android.Views.View;
using AWebView = Android.Webkit.WebView;

namespace MauiQRLoopDemo.Platforms.Android;

// https://github.com/dotnet/maui/issues/6565

public class MauiBlazorWebView : BlazorWebView
{
    public MauiBlazorWebView()
    {
        BlazorWebViewInitialized += (_, args) =>
        {
            // TODO: Check what's obsolete to be set explicitly.
            args.WebView.Settings.AllowFileAccess = true;
            args.WebView.Settings.DatabaseEnabled = true;
            args.WebView.Settings.MediaPlaybackRequiresUserGesture = false;
            args.WebView.Settings.MixedContentMode = MixedContentHandling.AlwaysAllow;
            args.WebView.Settings.SafeBrowsingEnabled = false;
            args.WebView.Settings.SetGeolocationEnabled(true);
            //args.WebView.Settings.SetGeolocationDatabasePath(args.WebView.Context!.FilesDir!.Path);
            args.WebView.SetWebChromeClient(new MauiBlazorWebChromeClient(args.WebView.WebChromeClient!));
        };
    }

    public MauiBlazorWebView(string? hostPage, RootComponentsCollection rootComponents) : this()
    {
        HostPage = hostPage;
        foreach (var component in rootComponents)
        {
            RootComponents.Add(component);
        }
    }

    private class MauiBlazorWebChromeClient : WebChromeClient
    {
        public MauiBlazorWebChromeClient(WebChromeClient client) => Client = client;

        private WebChromeClient Client { get; }

        // TODO: Override with Project style's video placeholder/poster image.
        public override Bitmap? DefaultVideoPoster => Client.DefaultVideoPoster;

        // TODO: Override with Project style's video buffering view.
        public override AView? VideoLoadingProgressView => Client.VideoLoadingProgressView;

        public override void GetVisitedHistory(IValueCallback? callback) => Client.GetVisitedHistory(callback);

        public override void OnCloseWindow(AWebView? window) => Client.OnCloseWindow(window);

        public override bool OnConsoleMessage(ConsoleMessage? consoleMessage) => Client.OnConsoleMessage(consoleMessage);

        public override bool OnCreateWindow(AWebView? view, bool isDialog, bool isUserGesture, Message? resultMsg) => Client.OnCreateWindow(view, isDialog, isUserGesture, resultMsg);

        public override void OnGeolocationPermissionsHidePrompt() => Client.OnGeolocationPermissionsHidePrompt();

        public override void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback) => callback?.Invoke(origin, true, true);

        public override void OnHideCustomView() => Client.OnHideCustomView();

        public override bool OnJsAlert(AWebView? view, string? url, string? message, JsResult? result) => Client.OnJsAlert(view, url, message, result);

        public override bool OnJsBeforeUnload(AWebView? view, string? url, string? message, JsResult? result) => Client.OnJsBeforeUnload(view, url, message, result);

        public override bool OnJsConfirm(AWebView? view, string? url, string? message, JsResult? result) => Client.OnJsConfirm(view, url, message, result);

        public override bool OnJsPrompt(AWebView? view, string? url, string? message, string? defaultValue, JsPromptResult? result) => Client.OnJsPrompt(view, url, message, defaultValue, result);

        public override void OnPermissionRequest(PermissionRequest? request) => request?.Grant(request.GetResources());

        public override void OnPermissionRequestCanceled(PermissionRequest? request) => Client.OnPermissionRequestCanceled(request);

        public override void OnProgressChanged(AWebView? view, int newProgress) => Client.OnProgressChanged(view, newProgress);

        public override void OnReceivedIcon(AWebView? view, Bitmap? icon) => Client.OnReceivedIcon(view, icon);

        public override void OnReceivedTitle(AWebView? view, string? title) => Client.OnReceivedTitle(view, title);

        public override void OnReceivedTouchIconUrl(AWebView? view, string? url, bool precomposed) => Client.OnReceivedTouchIconUrl(view, url, precomposed);

        public override void OnRequestFocus(AWebView? view) => Client.OnRequestFocus(view);

        public override void OnShowCustomView(AView? view, ICustomViewCallback? callback) => Client.OnShowCustomView(view, callback);

        public override bool OnShowFileChooser(AWebView? webView, IValueCallback? filePathCallback, FileChooserParams? fileChooserParams) => Client.OnShowFileChooser(webView, filePathCallback, fileChooserParams);
    }
}
#endif