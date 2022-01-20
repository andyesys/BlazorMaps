namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Determines Icon's properties.
    /// </summary>
    public class DivIconOptions : IconOptions
    {
        public DivIconOptions() : base() => Html = null!;

        public string Html { get; init; }
    }
}
