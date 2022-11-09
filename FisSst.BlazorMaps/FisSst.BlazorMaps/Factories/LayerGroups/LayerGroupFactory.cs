using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

internal class LayerGroupFactory : ILayerGroupFactory
{
    private const string create = "L.layerGroup";
    private readonly IJSRuntime jsRuntime;
    private readonly IEventedJsInterop eventedJsInterop;
    private readonly IBatchingJsInterop batchingJsInterop;

    public LayerGroupFactory(IJSRuntime jsRuntime, IEventedJsInterop eventedJsInterop, IBatchingJsInterop batchingJsInterop)
    {
        this.jsRuntime = jsRuntime;
        this.eventedJsInterop = eventedJsInterop;
        this.batchingJsInterop = batchingJsInterop;
    }

    public async Task<LayerGroup> Create(LayerOptions layerOptions = null)
    {
        var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, layerOptions);
        return new LayerGroup(jsReference, eventedJsInterop, batchingJsInterop);
    }

    public async Task<LayerGroup> CreateAndAddToMap(Map map, LayerOptions layerOptions = null)
    {
        var layerGroup = await Create(layerOptions);
        await layerGroup.AddTo(map);
        return layerGroup;
    }
}
