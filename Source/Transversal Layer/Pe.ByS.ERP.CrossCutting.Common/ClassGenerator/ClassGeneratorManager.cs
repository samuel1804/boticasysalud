using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Pe.ByS.ERP.CrossCutting.Common.ClassGenerator
{
    public class ClassGeneratorManager
    {
        public static Assembly EvaluateExpression(string codigoCompilar)
        {
            CompilerResults compilerResults = CompileScript(codigoCompilar);

            if (compilerResults.Errors.HasErrors)
            {
                throw new InvalidOperationException("Expression has a syntax error.");
            }

            Assembly assembly = compilerResults.CompiledAssembly;
            return assembly;
        }

        public static CompilerResults CompileScript(string source)
        {
            var parms = new CompilerParameters {GenerateExecutable = false, GenerateInMemory = true, IncludeDebugInformation = false};

            CodeDomProvider compiler = CodeDomProvider.CreateProvider("CSharp");

            return compiler.CompileAssemblyFromSource(parms, source);
        }
    }
}
