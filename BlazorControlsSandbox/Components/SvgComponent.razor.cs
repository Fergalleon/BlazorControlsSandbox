namespace BlazorControlsSandbox.Components
{
    using Microsoft.AspNetCore.Components;
    using Models;

    public partial class SvgComponent
    {
        [Parameter]
        public SvgAttributes SvgAttributes { get; set; }
    }
}
