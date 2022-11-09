using FisSst.BlazorMaps.JsInterops.IconFactories;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

internal class DivIconFactory : IDivIconFactory
{
    private const string create = "L.divIcon";
    private readonly IJSRuntime jsRuntime;
    private readonly IIconFactoryJsInterop iconFactoryJsInterop;

    public DivIconFactory(
        IJSRuntime jsRuntime,
        IIconFactoryJsInterop iconFactoryJsInterop)
    {
        this.jsRuntime = jsRuntime;
        this.iconFactoryJsInterop = iconFactoryJsInterop;
    }

    public async Task<DivIcon> Create(DivIconOptions options)
    {
        var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, options);
        return new DivIcon(jsReference);
    }

    public async Task<DivIcon> CreateDefault()
    {
        var jsReference = await iconFactoryJsInterop.CreateDefaultIcon();
        return new DivIcon(jsReference);
    }
}
