using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// It is used to display clickable/draggable icons on the Map.
    /// </summary>
    public class Marker : InteractiveLayer
    {
        private const string GetLatLngJsFunction = "getLatLng";
        private const string SetLatLngJsFunction = "setLatLng";
        private const string SetZIndexOffsetJsFunction = "setZIndexOffset";
        private const string GetIconJsFunction = "getIcon";
        private const string SetIconJsFunction = "setIcon";
        private const string SetOpacityJsFunction = "setOpacity";

        internal Marker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
        }

        public async Task<LatLng> GetLatLng()
            => await JsReference.InvokeAsync<LatLng>(GetLatLngJsFunction);

        public async Task<IJSObjectReference> SetLatLng(LatLng latLng)
            => await JsReference.InvokeAsync<IJSObjectReference>(SetLatLngJsFunction, latLng);

        public async Task<IJSObjectReference> SetZIndexOffset(int number)
            => await JsReference.InvokeAsync<IJSObjectReference>(SetZIndexOffsetJsFunction, number);

        public async Task<Icon> GetIcon()
            => await JsReference.InvokeAsync<Icon>(GetIconJsFunction);

        public async Task<IJSObjectReference> SetIcon(Icon icon)
            => await JsReference.InvokeAsync<IJSObjectReference>(SetIconJsFunction, icon);

        public async Task<IJSObjectReference> SetOpacity(int number)
            => await JsReference.InvokeAsync<IJSObjectReference>(SetOpacityJsFunction, number);
    }
}
