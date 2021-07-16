using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal class CircleFactory : ICircleFactory
    {
        private const string create = "L.circle";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;

        public CircleFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }

        public async Task<Circle> Create(LatLng latLng)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng);
            return new Circle(jsReference, eventedJsInterop);
        }

        public async Task<Circle> Create(LatLng latLng, CircleOptions options)
        {
            var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, latLng, options);
            return new Circle(jsReference, eventedJsInterop);
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map)
        {
            var circle = await Create(latLng);
            await circle.AddTo(map);
            return circle;
        }

        public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options)
        {
            var circle = await Create(latLng, options);
            await circle.AddTo(map);
            return circle;
        }
    }
}
