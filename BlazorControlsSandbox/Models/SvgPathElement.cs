namespace BlazorControlsSandbox.Models
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net;

    public class SvgPathElement
    {
        public SvgPathElement(char instruction, List<int> values)
        {
            Instruction = instruction;
            Values = values;
        }

        public char Instruction { get; set; }
        public List<int> Values { get; set; }
    }
}