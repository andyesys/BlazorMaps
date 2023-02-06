using System.Collections.Generic;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is responsible for creating Polylines and optionally adding them to the Map.
/// </summary>
public interface IPolylineFactory
{
    Task<Polyline> Create(IEnumerable<LatLng> latLngs);
    Task<Polyline> Create(IEnumerable<LatLng> latLngs, PolylineOptions options);
    Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map);
    Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options);
}
