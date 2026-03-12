export function initialize(mapOptions) {
    const options = {
        attributionControl: mapOptions.attributionControl,
        zoomControl: mapOptions.zoomControl,
        closePopupOnClick: mapOptions.closePopupOnClick,
        boxZoom: mapOptions.boxZoom,
        doubleClickZoom: mapOptions.doubleClickZoom,
        dragging: mapOptions.dragging,
        zoomSnap: mapOptions.zoomSnap,
        zoomDelta: mapOptions.zoomDelta,
        trackResize: mapOptions.trackResize,
        keyboard: mapOptions.keyboard,
        scrollWheelZoom: mapOptions.scrollWheelZoom
    };

    if (mapOptions.minZoom !== null && mapOptions.minZoom !== undefined) {
        options.minZoom = mapOptions.minZoom;
    }
    if (mapOptions.maxZoom !== null && mapOptions.maxZoom !== undefined) {
        options.maxZoom = mapOptions.maxZoom;
    }

    const map = L.map(mapOptions.divId, options).setView(mapOptions.center, mapOptions.zoom);
    if (mapOptions.urlTileLayer)
        L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(map);
    if (mapOptions.showScale)
        L.control.scale().addTo(map);
    return map;
}