using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class PopupsPage
    {
        private readonly LatLng center;
        private readonly LatLng firstMarkerLatLng;
        private readonly LatLng secondMarkerLatLng;
        private Map mapRef;
        private bool firstRender = true;
        private Marker marker1;
        private Marker marker2;
        private readonly MapOptions mapOptions;

        public PopupsPage()
        {
            center = new LatLng(50.279133, 18.685578);
            firstMarkerLatLng = new LatLng(50.284324, 18.664683);
            secondMarkerLatLng = new LatLng(50.285495, 18.691064);
            mapOptions = new MapOptions()
            {
                DivId = "mapId",
                Center = center,
                Zoom = 13,
                UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                SubOptions = new TileLayerOptions()
                {
                    Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                    MaxZoom = 18,
                    TileSize = 512,
                    ZoomOffset = -1,
                }
            };
        }

        [Inject]
        private IMarkerFactory MarkerFactory { get; init; }

        protected async Task AddMarkers()
        {
            if (firstRender)
            {
                firstRender = false;
                marker1 = await MarkerFactory.CreateAndAddToMap(firstMarkerLatLng, mapRef);
                marker2 = await MarkerFactory.CreateAndAddToMap(secondMarkerLatLng, mapRef);
            }
        }

        private async Task BindPopup() => await marker1.BindPopup("Hi! This is a popup");

        private async Task BindTooltip() => await marker2.BindTooltip("And this is a tooltip");

        private async Task RemovePopup() => await marker1.UnbindPopup();

        private async Task RemoveTooltip() => await marker2.UnbindTooltip();

        private async Task UpdatePopup() => await marker1.SetPopupContent("Popup has changed its content");

        private async Task UpdateTooltip() => await marker2.SetTooltipContent("Tooltip has changed its content");

        private async Task TogglePopup() => await marker1.TogglePopup();

        private async Task ToggleTooltip() => await marker2.ToggleTooltip();
    }
}
