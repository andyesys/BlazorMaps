using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    /// <summary>
    /// A set of methods from the Layer base class that all Leaflet layers (e.g. Marker, Circle) use.
    /// </summary>
    public abstract class Layer : Evented
    {
        private const string AddToJsFunction = "addTo";
        private const string RemoveJsFunction = "remove";
        private const string RemoveFromJsFunction = "removeFrom";
        private const string BindPopupJsFunction = "bindPopup";
        private const string UnbindPopupJsFunction = "unbindPopup";
        private const string OpenPopupJsFunction = "openPopup";
        private const string ClosePopupJsFunction = "closePopup";
        private const string TogglePopupJsFunction = "togglePopup";
        private const string IsPopupOpenJsFunction = "isPopupOpen";
        private const string SetPopupContentJsFunction = "setPopupContent";
        private const string BindTooltipJsFunction = "bindTooltip";
        private const string UnbindTooltipJsFunction = "unbindTooltip";
        private const string OpenTooltipJsFunction = "openTooltip";
        private const string CloseTooltipJsFunction = "closeTooltip";
        private const string ToggleTooltipJsFunction = "toggleTooltip";
        private const string IsTooltipOpenJsFunction = "isTooltipOpen";
        private const string SetTooltipContentJsFunction = "setTooltipContent";

        public async Task<Layer> AddTo(Map map)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(AddToJsFunction, map.MapReference);
            return this;
        }

        public async Task<Layer> Remove()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(RemoveJsFunction);
            await JsReference.DisposeAsync();
            return this;
        }

        public async Task<Layer> RemoveFrom(Map map)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(RemoveFromJsFunction, map.MapReference);
            return this;
        }

        public async Task<Layer> BindPopup(string content)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(BindPopupJsFunction, content);
            return this;
        }

        public async Task<Layer> UnbindPopup()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(UnbindPopupJsFunction);
            return this;
        }

        public async Task<Layer> OpenPopup(LatLng? latLng)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(OpenPopupJsFunction, latLng);
            return this;
        }

        public async Task<Layer> ClosePopup()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(ClosePopupJsFunction);
            return this;
        }

        public async Task<Layer> TogglePopup()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(TogglePopupJsFunction);
            return this;
        }

        public async Task<bool> IsPopupOpen()
            => await JsReference.InvokeAsync<bool>(IsPopupOpenJsFunction);

        public async Task<Layer> SetPopupContent(string content)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(SetPopupContentJsFunction, content);
            return this;
        }

        public async Task<Layer> BindTooltip(string content)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(BindTooltipJsFunction, content);
            return this;
        }

        public async Task<Layer> UnbindTooltip()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(UnbindTooltipJsFunction);
            return this;
        }

        public async Task<Layer> OpenTooltip(LatLng? latLng)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(OpenTooltipJsFunction, latLng);
            return this;
        }

        public async Task<Layer> CloseTooltip()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(CloseTooltipJsFunction);
            return this;
        }

        public async Task<Layer> ToggleTooltip()
        {
            await JsReference.InvokeAsync<IJSObjectReference>(ToggleTooltipJsFunction);
            return this;
        }

        public async Task<bool> IsTooltipOpen()
            => await JsReference.InvokeAsync<bool>(IsTooltipOpenJsFunction);

        public async Task<Layer> SetTooltipContent(string content)
        {
            await JsReference.InvokeAsync<IJSObjectReference>(SetTooltipContentJsFunction, content);
            return this;
        }
    }
}
