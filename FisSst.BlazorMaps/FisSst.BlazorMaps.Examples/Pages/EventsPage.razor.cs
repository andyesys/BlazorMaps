using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class EventsPage
    {
        private readonly LatLng center;
        private Map mapRef;
        private Polygon polygon;
        private Circle circle;
        private Marker marker1;
        private Marker marker2;
        private Marker marker3;
        private readonly MapOptions mapOptions;

        public EventsPage()
        {
            center = new LatLng(50.279133, 18.685578);
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
        private IJSRuntime JsRuntime { get; init; }
        [Inject]
        private IMarkerFactory MarkerFactory { get; init; }
        [Inject]
        private IPolygonFactory PolygonFactory { get; init; }
        [Inject]
        private ICircleFactory CircleFactory { get; init; }

        private async Task AddMarkersToMap()
        {
            marker1 = await MarkerFactory.CreateAndAddToMap(new LatLng(50.278133, 18.683578), mapRef);
            marker2 = await MarkerFactory.CreateAndAddToMap(new LatLng(50.277133, 18.670578), mapRef);
            marker3 = await MarkerFactory.CreateAndAddToMap(new LatLng(50.255133, 18.66578), mapRef);
        }

        private async Task HandleMouseEvent(MouseEvent mouseEvent)
            => await JsRuntime.InvokeVoidAsync("alert", $"Event type: {mouseEvent.Type} Lat: {mouseEvent.LatLng.Lat}, Lng: {mouseEvent.LatLng.Lng}");

        private async Task AddPolygonToMap()
        {
            var FirstLatLng = new LatLng(50.2905456, 18.634743);
            var SecondLatLng = new LatLng(50.287532, 18.615791);
            var ThirdLatLng = new LatLng(50.295247, 18.579297);
            polygon = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { FirstLatLng, SecondLatLng, ThirdLatLng }, mapRef);
            await polygon.OnClick(async (MouseEvent mouseEvent) => await ChangePolygonStyle());
        }

        private async Task ChangePolygonStyle()
        {
            var polygonOptions = new PolylineOptions()
            {
                Fill = true,
                Weight = 5,
                Color = "green"
            };

            await polygon.SetStyle(polygonOptions);
        }

        private async Task AddCircleToMap()
        {
            var circleOptionsInit = new CircleOptions()
            {
                Radius = 300
            };

            circle = await CircleFactory.CreateAndAddToMap(new LatLng(50.263766, 18.705137), mapRef, circleOptionsInit);
            await circle.OnClick(async (MouseEvent mouseEvent) => await ChangeCircleStyle());
        }

        private async Task ChangeCircleStyle()
        {
            var circleOptions = new CircleOptions()
            {
                Color = "green"
            };

            await circle.SetLatLng(new LatLng(50.283783, 18.724827));
        }

        private async Task AddEventsToMarkers()
        {
            await marker1.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
            await marker2.OnContextMenu(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
            await marker3.OnDblClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
        }

        private async Task RemoveEventsFromMarkers()
        {
            await marker1.Off("click");
            await marker2.Off("contextmenu");
            await marker3.Off("dblclick");
        }

        private async Task AddEventsToMap()
            => await mapRef.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));

        private async Task RemoveEventsFromMap()
            => await mapRef.Off("click");
    }
}
