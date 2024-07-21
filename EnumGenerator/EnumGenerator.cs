using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using System.Text;

namespace EnumGenerator
{
    [Generator]
    public class EnumGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            System.Diagnostics.Debug.WriteLine("EnumGenerator initialized");
        }

        public void Execute(GeneratorExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("EnumGenerator is running!");

            var enums = new[]
            {
                new { Name = "OrderStatus", Values = new[] { "Pending", "Processing", "Shipped", "Delivered", "Cancelled" } },
                new { Name = "UserRole", Values = new[] { "Admin", "User", "Guest" } }
            };

            foreach (var enumDef in enums)
            {
                var source = GenerateEnumSource(enumDef.Name, enumDef.Values);
                context.AddSource($"{enumDef.Name}.g.cs", SourceText.From(source, Encoding.UTF8));
                System.Diagnostics.Debug.WriteLine($"Generated {enumDef.Name}.g.cs");
            }
        }

        private string GenerateEnumSource(string enumName, string[] values)
        {
            var enumValues = string.Join(",\n    ", values);
            return $@"
namespace EnumGeneratorDemoApp.Enums
{{
    public enum {enumName}
    {{
        {enumValues}
    }}
}}
";
        }
    }
}
