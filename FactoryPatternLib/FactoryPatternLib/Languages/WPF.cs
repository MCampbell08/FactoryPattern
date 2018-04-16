using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class WPF : LanguageFactory
    {
        public override List<Tuple<Enums.Component, double, double, string, double, double>> Components { get => Components; set => Components = value; }

        public override void Compile()
        {
            throw new NotImplementedException();
        }

        public override void CreateComponent()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "csc.exe /out:WPFApplication.exe /target:winexe app.cs mainwindow.xaml.cs /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\presentationframework.dll\" /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\windowsbase.dll\" /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\presentationcore.dll\"";
            process.StartInfo = startInfo;
            process.Start();
            
        }
    }
}
