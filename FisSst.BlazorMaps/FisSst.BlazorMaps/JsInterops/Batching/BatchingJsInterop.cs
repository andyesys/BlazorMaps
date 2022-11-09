using FisSst.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

internal class BatchingJsInterop : BaseJsInterop, IBatchingJsInterop
{
    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.BatchingFile}";
    private const string removeLayerIds = nameof(removeLayerIds);
    private const string createAndAddMarkersBatched = nameof(createAndAddMarkersBatched);
    private const string createAndAddDivMarkersBatched = nameof(createAndAddDivMarkersBatched);
    private const string createAndAddPolygonsBatched = nameof(createAndAddPolygonsBatched);

    public BatchingJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath) { }

    public async ValueTask RemoveLayerIds(LayerGroup layer, long[] layerIds)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync(removeLayerIds, layer.JsReference, layerIds);
    }

    public async ValueTask<long[]> CreateAndAddMarkersBatched(LayerGroup layer, LatLng[] latLngs, MarkerOptions[] options, IconOptions[] iconOptions)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<long[]>(createAndAddMarkersBatched, layer.JsReference, latLngs, options, iconOptions);
    }

    public async ValueTask<long[]> CreateAndAddDivMarkersBatched(LayerGroup layer, LatLng[] latLngs, MarkerOptions[] options, DivIconOptions[] iconOptions)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<long[]>(createAndAddDivMarkersBatched, layer.JsReference, latLngs, options, iconOptions);
    }

    public async ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][] latLngs, PolylineOptions[] options)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<long[]>(createAndAddPolygonsBatched, layer.JsReference, latLngs, options);
    }

    public async ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][][] latLngs, PolylineOptions[] options)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<long[]>(createAndAddPolygonsBatched, layer.JsReference, latLngs, options);
    }

    public async ValueTask<long[]> CreateAndAddPolygonsBatched(LayerGroup layer, LatLng[][][][] latLngs, PolylineOptions[] options)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<long[]>(createAndAddPolygonsBatched, layer.JsReference, latLngs, options);
    }
}
