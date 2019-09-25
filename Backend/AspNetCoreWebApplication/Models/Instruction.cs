using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class Instruction
    {
        public int InstructionId { get; set; }
        public int RecipeId { get; set; }
        public string InstructionContent { get; set; }
    }
}
