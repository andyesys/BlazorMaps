using FisSst.BlazorMaps.JsInterops.IconFactories;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

internal class IconFactory : IIconFactory
{
    private const string create = "L.icon";
    private readonly IJSRuntime jsRuntime;
    private readonly IIconFactoryJsInterop iconFactoryJsInterop;

    public IconFactory(
        IJSRuntime jsRuntime,
        IIconFactoryJsInterop iconFactoryJsInterop)
    {
        this.jsRuntime = jsRuntime;
        this.iconFactoryJsInterop = iconFactoryJsInterop;
    }

    public async Task<Icon> Create(IconOptions options)
    {
        var jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, options);
        return new Icon(jsReference);
    }

    public async Task<Icon> CreateDefault()
    {
        var jsReference = await iconFactoryJsInterop.CreateDefaultIcon();
        return new Icon(jsReference);
    }
}
