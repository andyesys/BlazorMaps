using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class MarkersPage
    {
        private readonly LatLng center;
        private readonly LatLng firstMarkerLatLng;
        private readonly LatLng secondMarkerLatLng;
        private readonly LatLng thirdMarkerLatLng;
        private readonly LatLng markerWithOptionsLatLng;
        private Map mapRef;
        private Marker markerWithOptions;
        private Marker marker1;
        private Marker marker2;
        private Marker marker3;
        private readonly MapOptions mapOptions;

        public MarkersPage()
        {
            center = new LatLng(50.279133, 18.685578);
            firstMarkerLatLng = new LatLng(50.284324, 18.664683);
            secondMarkerLatLng = new LatLng(50.285495, 18.691064);
            thirdMarkerLatLng = new LatLng(50.279103, 18.685534);
            markerWithOptionsLatLng = new LatLng(50.273103, 18.684534);
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
        [Inject]
        private IIconFactory IconFactory { get; init; }

        private async Task AddMarkers()
        {
            marker1 = await MarkerFactory.CreateAndAddToMap(firstMarkerLatLng, mapRef);
            marker2 = await MarkerFactory.CreateAndAddToMap(secondMarkerLatLng, mapRef);
            marker3 = await MarkerFactory.CreateAndAddToMap(thirdMarkerLatLng, mapRef);
        }

        private async Task RemoveMarkers()
        {
            await marker1.Remove();
            await marker2.Remove();
            await marker3.Remove();
        }

        private async Task AddMarkerWithOptions()
        {
            var iconOptions = new IconOptions()
            {
                IconUrl = "http://leafletjs.com/examples/custom-icons/leaf-green.png",
                IconSize = new Point(38, 95),
                IconAnchor = new Point(22, 94),
                ShadowUrl = "http://leafletjs.com/examples/custom-icons/leaf-shadow.png",
                ShadowSize = new Point(50, 64),
                ShadowAnchor = new Point(4, 61),
                PopupAnchor = new Point(-3, -76),
            };

            var markerOptions = new MarkerOptions()
            {
                Opacity = 0.5,
                Draggable = true,
                IconRef = await IconFactory.Create(iconOptions),
            };

            markerWithOptions = await MarkerFactory.CreateAndAddToMap(markerWithOptionsLatLng, mapRef, markerOptions);
        }

        private async Task RemoveMarkerWithOptions()
            => await markerWithOptions.Remove();
    }
}
