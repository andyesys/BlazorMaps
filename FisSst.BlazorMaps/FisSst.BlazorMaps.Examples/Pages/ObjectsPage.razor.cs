using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class ObjectsPage
    {
        private readonly LatLng center;
        private readonly LatLng firstLatLng;
        private readonly LatLng secondLatLng;
        private readonly LatLng thirdLatLng;
        private readonly LatLng fourthLatLng;
        private readonly LatLng fifthLatLng;
        private readonly LatLng sixthLatLng;
        private readonly LatLng seventhLatLng;
        private readonly LatLng eighthLatLng;
        private readonly LatLng ninthLatLng;
        private readonly LatLng tenthLatLng;
        private readonly LatLng eleventhLatLng;
        private readonly LatLng twelfthLatLng;
        private readonly LatLng thirteenthLatLng;
        private readonly LatLng fourteenthLatLng;
        private readonly LatLng fifteenthLatLng;
        private readonly LatLng sixteenthLatLng;
        private readonly LatLng seventeenthLatLng;
        private readonly LatLng eighteenthLatLng;
        private Map mapRef;
        private Polyline polyline1;
        private Polyline polyline2;
        private Polygon polygon1;
        private Polygon polygon2;
        private CircleMarker circleMarker1;
        private CircleMarker circleMarker2;
        private Circle circle1;
        private Circle circle2;
        private readonly MapOptions mapOptions;
        private readonly PolylineOptions polylineOptions;
        private readonly PolylineOptions polylineOptions2;
        private readonly PolylineOptions polygonOptions;
        private readonly PolylineOptions polygonOptions2;
        private readonly CircleMarkerOptions circleMarkerOptionsInit;
        private readonly CircleMarkerOptions circleMarkerOptions;
        private readonly CircleMarkerOptions circleMarkerOptions2;
        private readonly CircleOptions circleOptionsInit;
        private readonly CircleOptions circleOptions;
        private readonly CircleOptions circleOptions2;

        public ObjectsPage()
        {
            center = new LatLng(50.279133, 18.685578);
            firstLatLng = new LatLng(50.284324, 18.664683);
            secondLatLng = new LatLng(50.285495, 18.691064);
            thirdLatLng = new LatLng(50.306061, 18.707469);
            fourthLatLng = new LatLng(50.279103, 18.685534);
            fifthLatLng = new LatLng(50.268534, 18.673535);
            sixthLatLng = new LatLng(50.268235, 18.695198);
            seventhLatLng = new LatLng(50.273202, 18.705697);
            eighthLatLng = new LatLng(50.2905456, 18.634743);
            ninthLatLng = new LatLng(50.287532, 18.615791);
            tenthLatLng = new LatLng(50.295247, 18.579297);
            eleventhLatLng = new LatLng(50.298249, 18.650836);
            twelfthLatLng = new LatLng(50.304129, 18.635537);
            thirteenthLatLng = new LatLng(50.304403, 18.613286);
            fourteenthLatLng = new LatLng(50.31915, 18.633894);
            fifteenthLatLng = new LatLng(50.276159, 18.599046);
            sixteenthLatLng = new LatLng(50.270142, 18.641009);
            seventeenthLatLng = new LatLng(50.263766, 18.705137);
            eighteenthLatLng = new LatLng(50.283783, 18.724827);
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
            polylineOptions = new PolylineOptions()
            {
                Weight = 10,
                Color = "red"
            };
            polylineOptions2 = new PolylineOptions()
            {
                Weight = 5,
                Color = "green"
            };
            polygonOptions = new PolylineOptions()
            {
                Fill = true,
                Weight = 10,
                Color = "red"
            };
            polygonOptions2 = new PolylineOptions()
            {
                Fill = true,
                Weight = 5,
                Color = "green"
            };
            circleMarkerOptionsInit = new CircleMarkerOptions()
            {
                Radius = 50
            };
            circleMarkerOptions = new CircleMarkerOptions()
            {
                Color = "red",
                Radius = 5
            };
            circleMarkerOptions2 = new CircleMarkerOptions()
            {
                Color = "green",
                Radius = 30
            };
            circleOptionsInit = new CircleOptions()
            {
                Radius = 100
            };
            circleOptions = new CircleOptions()
            {
                Color = "red"
            };
            circleOptions2 = new CircleOptions()
            {
                Color = "green"
            };
        }

        [Inject]
        private IPolylineFactory PolylineFactory { get; init; }
        [Inject]
        private IPolygonFactory PolygonFactory { get; init; }
        [Inject]
        private ICircleMarkerFactory CircleMarkerFactory { get; init; }
        [Inject]
        private ICircleFactory CircleFactory { get; init; }

        private async Task AddPolylines()
        {
            polyline1 = await PolylineFactory.CreateAndAddToMap(new List<LatLng> { firstLatLng, eighteenthLatLng, secondLatLng, thirdLatLng }, mapRef);
            polyline2 = await PolylineFactory.CreateAndAddToMap(new List<LatLng> { fourthLatLng, fifthLatLng }, mapRef);
        }

        private async Task ChangePolylineStyle()
        {
            await polyline1.SetStyle(polylineOptions);
            await polyline2.SetStyle(polylineOptions2);
        }

        private async Task DeletePolylines()
        {
            await polyline1.Remove();
            await polyline2.Remove();
        }

        private async Task AddPolygons()
        {
            polygon1 = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { eighthLatLng, ninthLatLng, tenthLatLng }, mapRef);
            polygon2 = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { eleventhLatLng, twelfthLatLng, thirteenthLatLng, fourteenthLatLng }, mapRef);
        }

        private async Task ChangePolygonStyle()
        {
            await polygon1.SetStyle(polygonOptions);
            await polygon2.SetStyle(polygonOptions2);
        }

        private async Task DeletePolygons()
        {
            await polygon1.Remove();
            await polygon2.Remove();
        }

        private async Task AddCircleMarkers()
        {
            circleMarker1 = await CircleMarkerFactory.CreateAndAddToMap(fifteenthLatLng, mapRef, circleMarkerOptionsInit);
            circleMarker2 = await CircleMarkerFactory.CreateAndAddToMap(sixteenthLatLng, mapRef);
        }

        private async Task ChangeCircleMarkerStyle()
        {
            await circleMarker1.SetStyle(circleMarkerOptions);
            await circleMarker2.SetStyle(circleMarkerOptions2);
        }

        private async Task DeleteCircleMarkers()
        {
            await circleMarker1.Remove();
            await circleMarker2.Remove();
        }

        private async Task AddCircles()
        {
            circle1 = await CircleFactory.CreateAndAddToMap(seventeenthLatLng, mapRef, circleOptionsInit);
            circle2 = await CircleFactory.CreateAndAddToMap(eighteenthLatLng, mapRef);
        }

        private async Task ChangeCircleStyle()
        {
            await circle1.SetStyle(circleOptions);
            await circle2.SetStyle(circleOptions2);
            await circle2.SetRadius(300);
        }

        private async Task DeleteCircles()
        {
            await circle1.Remove();
            await circle2.Remove();
        }
    }
}
