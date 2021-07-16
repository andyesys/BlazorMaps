using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class PolylineFactory : IPolylineFactory
    {
        private const string create = "L.polyline";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public PolylineFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Polyline> Create(IEnumerable<LatLng> latLngs)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs);
            return new Polyline(jsReference, eventedJsInterop);
        }

        public async Task<Polyline> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLngs, options);
            return new Polyline(jsReference, eventedJsInterop);
        }

        public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
        {
            var polyline = await Create(latLngs);
            await polyline.AddTo(map);
            return polyline;
        }

        public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
        {
            var polyline = await Create(latLngs, options);
            await polyline.AddTo(map);
            return polyline;
        }
    }
}
