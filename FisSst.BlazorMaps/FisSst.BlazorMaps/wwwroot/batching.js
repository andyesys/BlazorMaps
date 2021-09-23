export function removeLayerIds(layerGroup, ids) {
    for (let i = 0; i < ids.length; i++) {
        layerGroup.removeLayer(ids[i]);
    }
}

export function createAndAddMarkersBatched(layerGroup, latLngs, options, iconOptions) {
    const results = [];
    for (let i = 0; i < latLngs.length; i++) {
        if (iconOptions && iconOptions[i])
            options[i].icon = L.Icon(iconOptions[i]);
        const marker = L.marker(latLngs[i], options[i]);
        marker.addTo(layerGroup);
        results.push(L.stamp(marker));
    }
    return results;
}

export function createAndAddDivMarkersBatched(layerGroup, latLngs, options, iconOptions) {
    const results = [];
    for (let i = 0; i < latLngs.length; i++) {
        options[i].icon = L.divIcon(iconOptions[i]);
        const marker = L.marker(latLngs[i], options[i]);
        marker.addTo(layerGroup);
        results.push(L.stamp(marker));
    }
    return results;
}

export function createAndAddPolygonsBatched(layerGroup, latLngs, options) {
    const results = [];
    for (let i = 0; i < latLngs.length; i++) {
        const polygon = L.polygon(latLngs[i], options[i]);
        polygon.addTo(layerGroup);
        results.push(L.stamp(polygon));
    }
    return results;
}