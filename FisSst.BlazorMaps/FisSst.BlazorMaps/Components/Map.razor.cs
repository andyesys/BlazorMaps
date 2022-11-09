using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

public partial class Map : ComponentBase
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    [Inject]
    internal IMapJsInterop MapJsInterop { get; set; }

    [Inject]
    internal IEventedJsInterop EventedJsInterop { get; set; }

    internal MapEvented MapEvented { get; set; }

    [Parameter]
    public MapOptions MapOptions { get; set; }

    [Parameter]
    public EventCallback AfterRender { get; set; }

    [Parameter]
    public string Style { get; set; }

    internal IJSObjectReference MapReference { get; set; }

    private const string getCenter = "getCenter";
    private const string getZoom = "getZoom";
    private const string getMinZoom = "getMinZoom";
    private const string getMaxZoom = "getMaxZoom";
    private const string setView = "setView";
    private const string setZoom = "setZoom";
    private const string zoomIn = "zoomIn";
    private const string zoomOut = "zoomOut";
    private const string setZoomAround = "setZoomAround";
    private const string fitBounds = "fitBounds";
    private const string flyTo = "flyTo";
    private const string flyToBounds = "flyToBounds";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            MapReference = await MapJsInterop.Initialize(MapOptions);
            MapEvented = new MapEvented(MapReference, EventedJsInterop);
            await AfterRender.InvokeAsync();
        }
    }

    public async Task<LatLng> GetCenter() => await MapReference.InvokeAsync<LatLng>(getCenter);

    public async Task<int> GetZoom() => await MapReference.InvokeAsync<int>(getZoom);

    public async Task<int> GetMinZoom() => await MapReference.InvokeAsync<int>(getMinZoom);

    public async Task<int> GetMaxZoom() => await MapReference.InvokeAsync<int>(getMaxZoom);

    public async Task SetView(LatLng latLng, int? zoom = null) => await MapReference.InvokeAsync<IJSObjectReference>(setView, latLng, zoom, new { animate = true });

    public async Task SetZoom(int zoom) => await MapReference.InvokeAsync<IJSObjectReference>(setZoom, zoom);

    public async Task ZoomIn(int zoomDelta) => await MapReference.InvokeAsync<IJSObjectReference>(zoomIn, zoomDelta);

    public async Task ZoomOut(int zoomDelta) => await MapReference.InvokeAsync<IJSObjectReference>(zoomOut, zoomDelta);

    public async Task SetZoomAround(LatLng latLng, int zoom) => await MapReference.InvokeAsync<IJSObjectReference>(setZoomAround, latLng, zoom);

    public async Task FitBounds(LatLng[] bounds)
    {
        var boundsParam = await JsRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", bounds);
        await MapReference.InvokeAsync<IJSObjectReference>(fitBounds, boundsParam, new { animate = true });
        await boundsParam.DisposeAsync();
    }

    public async Task FlyTo(LatLng latLng, int zoom) => await MapReference.InvokeAsync<IJSObjectReference>(flyTo, latLng, zoom);

    public async Task FlyToBounds(LatLng[] bounds)
    {
        var boundsParam = await JsRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", bounds);
        await MapReference.InvokeAsync<IJSObjectReference>(flyToBounds, boundsParam);
        await boundsParam.DisposeAsync();
    }

    public async Task OnClick(Func<MouseEvent, Task> callback) => await MapEvented.OnClick(callback);

    public async Task OnDblClick(Func<MouseEvent, Task> callback) => await MapEvented.OnDblClick(callback);

    public async Task OnMouseDown(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseDown(callback);

    public async Task OnMouseUp(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseUp(callback);

    public async Task OnMouseOver(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOver(callback);

    public async Task OnMouseOut(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOut(callback);

    public async Task OnContextMenu(Func<MouseEvent, Task> callback) => await MapEvented.OnContextMenu(callback);

    public async Task Off(string eventType) => await MapEvented.Off(eventType);
}
