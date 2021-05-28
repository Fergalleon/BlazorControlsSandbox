namespace BlazorControlsSandbox.Components
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.JSInterop;
    using Models;
    using Services;

    public partial class FlowChart
    {
        private bool _isMouseDown = false;

        [Inject] public ISvgItemService SvgItemService { get; set; }

        [Inject] public IJSRuntime JsRuntime { get; set; }

        private Point ContainerOffset { get; set; }

        private SvgAttributes SelectedItem { get; set; }

        private Point ClickPoint { get; set; }

        private string SelectedItemText => SelectedItem?.DisplayValue ?? "(none)";

        private List<SvgAttributes> SvgComponents { get; set; }
        
        private void HandleMouseDown(MouseEventArgs e)
        {
            ClickPoint = new Point((int) e.OffsetX, (int) e.OffsetY);

            SelectedItem = SvgComponents?.GetSelected(ClickPoint);
            _isMouseDown = true;
        }

        private void HandleMouseMove(MouseEventArgs e)
        {
            var isDraggingSvg = _isMouseDown && SelectedItem != null;
            if (!isDraggingSvg)
            {
                return;
            }

            // todo: (hack) this needs to take into account click pos relative to item being dragged's top left, and offset.
            SelectedItem.X = (int) e.OffsetX;
            SelectedItem.Y = (int) e.OffsetY;
        }

        private void HandleMouseUp(MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        protected override async Task OnInitializedAsync()
        {
            SvgComponents = await SvgItemService.GetSvgItems();
        }
    }
}