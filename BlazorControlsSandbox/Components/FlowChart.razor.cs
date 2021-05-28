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
        [Inject]
        public ISvgItemService SvgItemService { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        private bool _isMouseDown = false;

        private void HandleMouseDown(MouseEventArgs e)
        {
            ClickPoint = new Point((int)e.ClientX, (int)e.ClientY);
            SelectedItem = SvgComponents?.GetSelected(ContainerOffset, ClickPoint);
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
            SelectedItem.X = (int)e.OffsetX;
            SelectedItem.Y = (int)e.OffsetY;
        }

        private void HandleMouseUp(MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private SvgAttributes SelectedItem { get; set; }

        private Point ClickPoint { get; set; }

        private string SelectedItemText => SelectedItem?.DisplayValue ?? "(none)";

        private List<SvgAttributes> SvgComponents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SvgComponents = await SvgItemService.GetSvgItems();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SetCanvasPosition();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task SetCanvasPosition()
        {
            var result = await JsRuntime.InvokeAsync<BoundingClientRect>(
                "MyDOMGetBoundingClientRect", "canvas");

            ContainerOffset = new Point((int)result.Left, (int)result.Top);
        }

        private Point ContainerOffset { get; set; }
    }
}
