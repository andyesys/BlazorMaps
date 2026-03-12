namespace FisSst.BlazorMaps;

/// <summary>
/// Determines Map's properties.
/// </summary>
public class MapOptions
{
    /// <summary>
    /// Instantiates a map object given the DOM ID of a div element.
    /// </summary>
    public string DivId { get; set; }

    /// <summary>
    /// Initial geographic center of the map.
    /// </summary>
    public LatLng Center { get; set; }

    /// <summary>
    /// Initial map zoom level.
    /// </summary>
    public int Zoom { get; set; }

    /// <summary>
    /// The URL template for the initial tile layer to be added to the map.
    /// </summary>
    public string UrlTileLayer { get; set; }

    /// <summary>
    /// Tile layer options for the initial tile layer.
    /// </summary>
    public TileLayerOptions SubOptions { get; set; }

    /// <summary>
    /// Whether a scale control is added to the map by default.
    /// </summary>
    public bool ShowScale { get; set; }

    /// <summary>
    /// Whether a attribution control is added to the map by default.
    /// </summary>
    public bool AttributionControl { get; set; } = true;

    /// <summary>
    /// Whether a zoom control is added to the map by default.
    /// </summary>
    public bool ZoomControl { get; set; } = true;

    /// <summary>
    /// Set it to false if you don't want popups to close when user clicks the map.
    /// </summary>
    public bool ClosePopupOnClick { get; set; } = true;

    /// <summary>
    /// Whether the map can be zoomed to a rectangular area specified by dragging the mouse while pressing the shift key.
    /// </summary>
    public bool BoxZoom { get; set; } = true;

    /// <summary>
    /// Whether the map can be zoomed in by double clicking on it and zoomed out by double clicking while holding shift.
    /// </summary>
    public bool DoubleClickZoom { get; set; } = true;

    /// <summary>
    /// Whether the map is draggable with mouse/touch or not.
    /// </summary>
    public bool Dragging { get; set; } = true;

    /// <summary>
    /// Forces the map's zoom level to always be a multiple of this, particularly right after a fitBounds() or a pinch-zoom.
    /// </summary>
    public double ZoomSnap { get; set; } = 1;

    /// <summary>
    /// Controls how much the map's zoom level will change after a zoomIn(), zoomOut(), pressing + or - on the keyboard, or using the zoom controls.
    /// </summary>
    public double ZoomDelta { get; set; } = 1;

    /// <summary>
    /// Whether the map automatically handles browser window resize to update itself.
    /// </summary>
    public bool TrackResize { get; set; } = true;

    /// <summary>
    /// Makes the map focusable and allows users to navigate the map with keyboard arrows and +/- keys.
    /// </summary>
    public bool Keyboard { get; set; } = true;

    /// <summary>
    /// Whether the map can be zoomed by using the mouse wheel.
    /// </summary>
    public bool ScrollWheelZoom { get; set; } = true;

    /// <summary>
    /// Minimum zoom level of the map.
    /// </summary>
    public int? MinZoom { get; set; }

    /// <summary>
    /// Maximum zoom level of the map.
    /// </summary>
    public int? MaxZoom { get; set; }
}
