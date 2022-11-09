using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

public class TileLayerFactory : ITileLayerFactory
{
    private const string create = "L.tileLayer";
    private readonly IJSRuntime jsRuntime;

    public TileLayerFactory(IJSRuntime jsRuntime) => this.jsRuntime = jsRuntime;

    public async Task<TileLayer> Create(string urlTemplate, TileLayerOptions options)
    {
        var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, urlTemplate, options);
        return new TileLayer(jsReference);
    }
}
