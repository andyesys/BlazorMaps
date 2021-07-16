using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal interface IBatchingJsInterop
    {
        ValueTask<long[]> CreateAndAddMarkersBatched(LayerGroup layer, LatLng[] latLngs, MarkerOptions[] options);
        ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][] latLngs, PolylineOptions[] options);
        ValueTask RemoveLayerIds(LayerGroup layer, long[] layerIds);
    }
}
