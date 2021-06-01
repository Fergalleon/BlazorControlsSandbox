namespace BlazorControlsSandbox.Services
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading.Tasks;
    using Models;

    public interface ISvgItemService
    {
        public Task<List<SvgAttributes>> GetSvgItems();
        public Task<List<SvgPathElement>> GetSvgPathItems();
    }

    public class SvgItemService : ISvgItemService
    {
        public async Task<List<SvgAttributes>> GetSvgItems()
        {
            var items = new List<SvgAttributes>
            {
                new SvgAttributes(new Rectangle(50, 20, 150, 50), "Item1"),
                new SvgAttributes(new Rectangle(250, 20, 150, 50), "Item2"),
            };

            return await Task.FromResult(items);
        }

        public async Task<List<SvgPathElement>> GetSvgPathItems()
        {
            //M 100 300 Q 150 50 200 300 Q 250 550 250 200 Q 350 50 350 350 C 450 550 450 50 650 100
            //C 550 50 550 550 600 300 A 50 50 0 1 1 700 300 

            //C 450 550 450 50 650 100 C 550 50 550 550 600 300 A 50 50 0 1 1 700 300
            //TODO: parse svg string..
            return new List<SvgPathElement>
            {
                new SvgPathElement('M', new List<int> {100, 300}),
                new SvgPathElement('Q', new List<int> {150, 50, 200, 300}),
                new SvgPathElement('Q', new List<int> {250, 550, 250, 200}),
                new SvgPathElement('C', new List<int> {450, 550, 450, 50, 650, 100}),
                new SvgPathElement('C', new List<int> {450, 550, 450, 50, 650, 100}),
                new SvgPathElement('C', new List<int> {550, 50, 550, 550, 600, 300}),
                new SvgPathElement('A', new List<int> {50, 50, 0, 1, 1, 700, 300})
            };
        }

    }
}