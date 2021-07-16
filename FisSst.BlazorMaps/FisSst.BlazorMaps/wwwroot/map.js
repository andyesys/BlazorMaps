export function initialize(mapOptions) {
    const map = L.map(mapOptions.divId).setView(mapOptions.center, mapOptions.zoom);
    if (mapOptions.urlTileLayer)
        L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(map);
    if (mapOptions.showScale)
        L.control.scale().addTo(map);
    return map;
}