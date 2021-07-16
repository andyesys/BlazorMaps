using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class MarkerFactory : IMarkerFactory
    {
        private const string create = "L.marker";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public MarkerFactory(IJSRuntime jsRuntime, IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Marker> Create(LatLng latLng)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng);
            return new Marker(jsReference, eventedJsInterop);
        }

        public async Task<Marker> Create(LatLng latLng, MarkerOptions options)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng, options);
            return new Marker(jsReference, eventedJsInterop);
        }

        public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options)
        {
            var marker = await Create(latLng, options);
            await marker.AddTo(map);
            return marker;
        }
    }
}
