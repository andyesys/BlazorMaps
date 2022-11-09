using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// Can be a graphical representation of an object on a Map.
/// </summary>
public class DivIcon : Icon
{
    internal DivIcon(IJSObjectReference jsReference) : base(jsReference) { }
}
