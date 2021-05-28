namespace BlazorControlsSandbox.Services
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading.Tasks;
    using Models;

    public interface ISvgItemService
    {
        public Task<List<SvgAttributes>> GetSvgItems();
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
    }
}