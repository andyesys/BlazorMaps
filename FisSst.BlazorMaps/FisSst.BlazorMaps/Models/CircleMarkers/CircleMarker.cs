﻿using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

/// <summary>
/// A circle of a fixed size with radius specified in pixels.
/// </summary>
public class CircleMarker : Path
{
    private const string ToGeoJSONJsFunction = "toGeoJSON";
    private const string SetLatLngJsFunction = "setLatLng";
    private const string GetLatLngJsFunction = "getLatLng";
    private const string SetRadiusJsFunction = "setRadius";
    private const string GetRadiusJsFunction = "getRadius";

    internal CircleMarker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
    {
        JsReference = jsReference;
        EventedJsInterop = eventedJsInterop;
    }

    public async Task<object> ToGeoJSON() => await JsReference.InvokeAsync<object>(ToGeoJSONJsFunction);

    public async Task<CircleMarker> SetLatLng(LatLng latLng)
    {
        await JsReference.InvokeAsync<IJSObjectReference>(SetLatLngJsFunction, latLng);
        return this;
    }

    public async Task<LatLng> GetLatLng() => await JsReference.InvokeAsync<LatLng>(GetLatLngJsFunction);

    public async Task<CircleMarker> SetRadius(LatLng latLng)
    {
        await JsReference.InvokeAsync<IJSObjectReference>(SetRadiusJsFunction, latLng);
        return this;
    }

    public async Task<double> GetRadius() => await JsReference.InvokeAsync<double>(GetRadiusJsFunction);
}
