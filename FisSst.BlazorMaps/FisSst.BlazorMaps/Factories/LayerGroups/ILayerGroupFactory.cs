using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public interface ILayerGroupFactory
    {
        Task<LayerGroup> Create(LayerOptions layerOptions = null);
        Task<LayerGroup> CreateAndAddToMap(Map map, LayerOptions layerOptions = null);
    }
}