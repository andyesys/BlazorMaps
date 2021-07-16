using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class LayerGroup : Layer
    {
        private readonly IBatchingJsInterop batchingJsInterop;

        internal LayerGroup(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop, IBatchingJsInterop batchingJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
            this.batchingJsInterop = batchingJsInterop;
        }

        public async Task RemoveLayerIds(long[] layerIds)
            => await batchingJsInterop.RemoveLayerIds(this, layerIds);

        public async Task<long[]> CreateAndAddMarkersBatched(LatLng[] latLngs, MarkerOptions[] options)
            => await batchingJsInterop.CreateAndAddMarkersBatched(this, latLngs, options);

        public async Task<long[]> CreateAndAddPolygonsBatched(LatLng[][] latLngs, PolylineOptions[] options)
            => await batchingJsInterop.CreateAndAddPolygonsBatched(this, latLngs, options);
    }
}
