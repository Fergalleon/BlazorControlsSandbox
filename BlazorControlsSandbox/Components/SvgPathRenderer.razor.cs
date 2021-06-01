namespace BlazorControlsSandbox.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Models;
    using Services;



    public partial class SvgPathRenderer
    {
        // SvgPath =
        //     "M 100 300 Q 150 50 200 300 Q 250 550 250 200 Q 350 50 350 350 C 450 550 450 50 650 100 C 550 50 550 550 600 300 A 50 50 0 1 1 700 300 ";
        
        private List<SvgPathElement> _svgPathItems;

        [Inject]
        public ISvgItemService SvgItemService { get; set; }

        public string SvgPath { get; set; }
        
        private Task UpdatePath_timed()
        {
            // TODO: (so far)cannot get this to render by updating svg from a timer.
            //       either it all loads at once, or nothing loads
            
            // TODO: move this delay into service, and await on for each against IEnumAsync
            return Task.Run(() =>
            {
                _svgPathItems.ForEach(async itm =>
                {
                    await Task.Delay(500);
                    Console.WriteLine($"adding: {itm}");
                    SvgPath += $"{itm.Instruction} {string.Join(' ', itm.Values)}";

                    // StateHasChanged();
                    Console.WriteLine($"state changed, SvgPath: {SvgPath}");
                });

            });
        }

        private int currentPathIndex = 0;

        private async Task HandleOnClick()
        {
            Console.WriteLine("click");
            if (CanIncrementPath)
            {
                await UpdatePath(currentPathIndex);
                currentPathIndex++;
            }
        }

        private bool CanIncrementPath => currentPathIndex < _svgPathItems.Count;

        private Task UpdatePath(int index)
        {
            return Task.Run(() =>
            {
                var itm = _svgPathItems[index];

                Console.WriteLine($"adding: {itm}");
                SvgPath += $"{itm.Instruction} {string.Join(' ', itm.Values)}";
            });
        }

        protected override async Task OnInitializedAsync()
        {
            _svgPathItems = await SvgItemService.GetSvgPathItems();

           // await UpdatePath();
        }
    }
}
