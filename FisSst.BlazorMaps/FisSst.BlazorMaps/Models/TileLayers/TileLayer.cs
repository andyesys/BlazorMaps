using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is used to display clickable/draggable icons on the Map.
/// </summary>
public class TileLayer : Layer
{
    internal TileLayer(IJSObjectReference jsReference) => JsReference = jsReference;
}
