using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

/// <summary>
/// A class for drawing polyline overlays on a Map.
/// </summary>
public class Polyline : Path
{
    private const string ToGeoJSONJsFunction = "toGeoJSON";
    private const string SetLatLngsJsFunction = "setLatLngs";
    private const string IsEmptyJsFunction = "isEmpty";
    private const string GetCenterJsFunction = "getCenter";
    private const string AddLatLngJsFunction = "addLatLng";

    internal Polyline(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
    {
        EventedJsInterop = eventedJsInterop;
        JsReference = jsReference;
    }

    public async Task<object> ToGeoJSON() => await JsReference.InvokeAsync<object>(ToGeoJSONJsFunction);

    public async Task<Polyline> SetLatLngs(IEnumerable<LatLng> latLngs)
    {
        await JsReference.InvokeAsync<IJSObjectReference>(SetLatLngsJsFunction, latLngs);
        return this;
    }

    public async Task<bool> IsEmpty() => await JsReference.InvokeAsync<bool>(IsEmptyJsFunction);

    public async Task<LatLng> GetCenter() => await JsReference.InvokeAsync<LatLng>(GetCenterJsFunction);

    public async Task<Polyline> AddLatLng(LatLng latLng)
    {
        await JsReference.InvokeAsync<IJSObjectReference>(AddLatLngJsFunction, latLng);
        return this;
    }

    public async Task<Polyline> AddLatLng(LatLng latLng, IEnumerable<LatLng> latLngs)
    {
        await JsReference.InvokeAsync<IJSObjectReference>(AddLatLngJsFunction, latLng, latLngs);
        return this;
    }
}
