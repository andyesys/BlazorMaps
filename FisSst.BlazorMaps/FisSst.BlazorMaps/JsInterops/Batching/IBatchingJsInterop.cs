using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    internal interface IBatchingJsInterop
    {
        ValueTask<long[]> CreateAndAddMarkersBatched(LayerGroup layer, LatLng[] latLngs, MarkerOptions[] options, IconOptions[] iconOptions = null);
        ValueTask<long[]> CreateAndAddDivMarkersBatched(LayerGroup layer, LatLng[] latLngs, MarkerOptions[] options, DivIconOptions[] iconOptions);
        ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][] latLngs, PolylineOptions[] options);
        ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][][] latLngs, PolylineOptions[] options);
        ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][][][] latLngs, PolylineOptions[] options);
        ValueTask RemoveLayerIds(LayerGroup layer, long[] layerIds);
    }
}
