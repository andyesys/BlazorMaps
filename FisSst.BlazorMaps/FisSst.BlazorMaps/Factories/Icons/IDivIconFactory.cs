using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is responsible for creating Icons.
/// </summary>
public interface IDivIconFactory
{
    Task<DivIcon> Create(DivIconOptions options);
    Task<DivIcon> CreateDefault();
}
