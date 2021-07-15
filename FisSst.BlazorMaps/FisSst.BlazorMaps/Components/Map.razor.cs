using FisSst.BlazorMaps.JsInterops.Events;
using FisSst.BlazorMaps.JsInterops.Maps;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
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
                this.MapReference = await this.MapJsInterop.Initialize(this.MapOptions);
                this.MapEvented = new MapEvented(this.MapReference, this.EventedJsInterop);
                await this.AfterRender.InvokeAsync();
            }
        }

        public async Task<LatLng> GetCenter()
        {
            return await this.MapReference.InvokeAsync<LatLng>(getCenter);
        }

        public async Task<int> GetZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getZoom);
        }

        public async Task<int> GetMinZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMinZoom);
        }

        public async Task<int> GetMaxZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMaxZoom);
        }

        public async Task SetView(LatLng latLng, int? zoom = null)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setView, latLng, zoom, new { animate = true });
        }

        public async Task SetZoom(int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoom, zoom);
        }

        public async Task ZoomIn(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomIn, zoomDelta);
        }

        public async Task ZoomOut(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomOut, zoomDelta);
        }

        public async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoomAround, latLng, zoom);
        }

        public async Task FitBounds(LatLng[] bounds)
        {
            IJSObjectReference boundsParam = await this.JsRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", bounds);
            await this.MapReference.InvokeAsync<IJSObjectReference>(fitBounds, boundsParam, new { animate = true });
            await boundsParam.DisposeAsync();
        }

        public async Task FlyTo(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(flyTo, latLng, zoom);
        }

        public async Task FlyToBounds(LatLng[] bounds)
        {
            IJSObjectReference boundsParam = await this.JsRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", bounds);
            await this.MapReference.InvokeAsync<IJSObjectReference>(flyToBounds, boundsParam);
            await boundsParam.DisposeAsync();
        }

        public async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnClick(callback);
        }
        public async Task OnDblClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnDblClick(callback);
        }

        public async Task OnMouseDown(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseDown(callback);
        }

        public async Task OnMouseUp(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseUp(callback);
        }

        public async Task OnMouseOver(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOver(callback);
        }

        public async Task OnMouseOut(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOut(callback);
        }

        public async Task OnContextMenu(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnContextMenu(callback);
        }

        public async Task Off(string eventType)
        {
            await this.MapEvented.Off(eventType);
        }
    }
}
