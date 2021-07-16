using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps.Examples.Pages
{
    public partial class TestsPage
    {
        private readonly double firstLat;
        private readonly double secondLat;
        private readonly double firstLng;
        private readonly double secondLng;
        private readonly MatTheme matTheme;
        private Map mapRef;
        private List<Marker> markers = new List<Marker>();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly MapOptions mapOptions;

        public TestsPage()
        {
            firstLat = 50.24;
            secondLat = 50.30;
            firstLng = 18.62;
            secondLng = 18.75;
            matTheme = new MatTheme()
            {
                Primary = "#CBE54E"
            };
            mapOptions = new MapOptions()
            {
                DivId = "mapId",
                Center = new LatLng(50.279133, 18.685578),
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
        public int NumberOfMarkers { get; set; }

        private async Task AddMarkers()
        {
            var coordinates = GenerateListOfCoordinates();

            stopwatch.Restart();
            stopwatch.Start();

            for (var i = 0; i < NumberOfMarkers; i++)
            {
                var marker = await MarkerFactory.CreateAndAddToMap(coordinates[i], mapRef);
                markers.Add(marker);
            }

            stopwatch.Stop();
            StateHasChanged();
        }

        private void RemoveMarkers()
        {
            stopwatch.Restart();
            stopwatch.Start();
            markers.ForEach(async marker => await marker.Remove());
            stopwatch.Stop();
            markers = new List<Marker>();
            StateHasChanged();
        }

        private List<LatLng> GenerateListOfCoordinates()
        {
            var coordinates = new List<LatLng>();
            for (var i = 0; i < NumberOfMarkers; i++)
            {
                coordinates.Add(GetRandomLatLng());
            }

            return coordinates;
        }

        private LatLng GetRandomLatLng()
        {
            var random = new Random();
            var lat = random.NextDouble() * (secondLat - firstLat) + firstLat;
            var lng = random.NextDouble() * (secondLng - firstLng) + firstLng;
            return new LatLng(lat, lng);
        }
    }
}
