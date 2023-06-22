using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Text;

namespace IncrementalSourceGeneratorTest
{
    [Generator]
    public class SomeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
            "Bla.g.cs",
            SourceText.From("""
                namespace GeneratorClient;
                
                partial class Class1 
                {
                    void GeneratedMethod() => Console.WriteLine("Hello 11f");
                }
                """, Encoding.UTF8)));
        }
    }
}
