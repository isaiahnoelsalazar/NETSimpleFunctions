using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;

namespace NETSimpleFunctions
{
    public class PyCS
    {
        bool Console = true, exist1 = false, exist2 = false, exist3 = false;
        Process? Process;

        void AllowTLS12()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public PyCS()
        {
            CreatePython();
        }

        public PyCS(bool Console)
        {
            this.Console = Console;
            CreatePython();
        }

        void CreatePython()
        {
            AllowTLS12();
            if (!File.Exists("python-3.13.5-embed-amd64.zip"))
            {
                if (Console)
                {
                    System.Console.WriteLine("Creating Python 3.13 resources...");
                }
                try
                {
                    SimpleFileHandler.ProjectToLocation(Assembly.GetExecutingAssembly(), "python-3.13.5-embed-amd64.zip");
                }
                catch
                {
                    System.Console.WriteLine("Failed to create Python 3.13 resources.");
                }
            }
            else
            {
                if (Console)
                {
                    System.Console.WriteLine("Python 3.13 resources already created.");
                }
            }
            try
            {
                using (File.OpenRead("python-3.13.5-embed-amd64.zip"))
                {
                    exist1 = true;
                }
            }
            catch
            {
            }
            if (exist1)
            {
                if (!Directory.Exists("python3_13\\python313"))
                {
                    if (Console)
                    {
                        System.Console.WriteLine("Extracting Python 3.13 resources...");
                    }
                    try
                    {
                        Directory.CreateDirectory("python3_13");
                        string zipPath = "python-3.13.5-embed-amd64.zip";
                        string extractPath = "python3_13";
                        ZipFile.ExtractToDirectory(zipPath, extractPath);

                        using (FileStream fs = File.OpenWrite("python3_13\\python313._pth"))
                        {
                            string toWrite = "python313.zip\r\n.\r\n\r\n# Uncomment to run site.main() automatically\r\nimport site\r\n";
                            fs.Write(Encoding.UTF8.GetBytes(toWrite), 0, Encoding.UTF8.GetBytes(toWrite).Length);
                        }

                        string zipPath1 = "python3_13\\python313.zip";
                        string extractPath1 = "python3_13\\python313";
                        ZipFile.ExtractToDirectory(zipPath1, extractPath1);

                        SimpleFileHandler.ProjectToLocation(Assembly.GetExecutingAssembly(), "sitecustomize.py", "python3_13");
                    }
                    catch
                    {
                        if (Console)
                        {
                            System.Console.WriteLine("Failed to extract Python 3.13 resources.");
                        }
                    }
                }
                else
                {
                    if (Console)
                    {
                        System.Console.WriteLine("Python 3.13 resources already extracted.");
                    }
                }
            }
        }

        public void InstallPip()
        {
            try
            {
                if (!File.Exists("python3_13\\get-pip.py"))
                {
                    if (Console)
                    {
                        System.Console.WriteLine("Downloading get-pip...");
                    }
                    var webReq = (HttpWebRequest)HttpWebRequest.Create("https://bootstrap.pypa.io/get-pip.py");
                    var res = webReq.GetResponse();
                    var content = res.GetResponseStream();

                    using (var fileStream = File.Create("python3_13\\get-pip.py"))
                    {
                        content.CopyTo(fileStream);
                    }
                }
                else
                {
                    if (Console)
                    {
                        System.Console.WriteLine("get-pip already downloaded.");
                    }
                }
            }
            catch
            {
                System.Console.WriteLine("Failed to download get-pip. Connect to the internet to download get-pip.");
            }
            try
            {
                using (File.OpenRead("python3_13\\get-pip.py"))
                {
                    exist2 = true;
                }
            }
            catch
            {
            }
            try
            {
                using (File.OpenRead("python3_13\\sitecustomize.py"))
                {
                    exist3 = true;
                }
            }
            catch
            {
            }
            if (exist2 && exist3)
            {
                if (!Directory.Exists("python3_13\\Lib") || !Directory.Exists("python3_13\\Scripts") ||
                    !File.Exists("python3_13\\Scripts\\pip.exe") || !File.Exists("python3_13\\Scripts\\pip3.13.exe") || !File.Exists("python3_13\\Scripts\\pip3.exe"))
                {
                    if (Console)
                    {
                        System.Console.WriteLine("Downloading pip...");
                    }
                    try
                    {
                        ProcessStartInfo run0 = new ProcessStartInfo();
                        run0.FileName = "python3_13\\python.exe";
                        run0.Arguments = "python3_13\\get-pip.py";
                        run0.UseShellExecute = false;
                        run0.RedirectStandardOutput = true;
                        run0.CreateNoWindow = true;
                        Process = Process.Start(run0);
                        StreamReader reader = Process.StandardOutput;
                        if (reader.ReadToEnd().Length != 0)
                        {
                            System.Console.WriteLine("pip downloaded.");
                        }
                        else
                        {
                            System.Console.WriteLine("Failed to download pip. Connect to the internet to download pip.");
                        }
                    }
                    catch
                    {
                        System.Console.WriteLine("Failed to download pip.");
                    }
                }
                else
                {
                    if (Console)
                    {
                        System.Console.WriteLine("pip already downloaded.");
                    }
                }
            }
        }

        public void Pip(string[] args)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\Scripts\\pip.exe";
            run0.Arguments = "install " + string.Join(" ", args);
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            if (Console)
            {
                System.Console.WriteLine(reader.ReadToEnd());
            }
        }

        public void PipUpgrade(string[] args)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\Scripts\\pip.exe";
            run0.Arguments = "install --upgrade " + string.Join(" ", args);
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            if (Console)
            {
                System.Console.WriteLine(reader.ReadToEnd());
            }
        }

        public void PipLocal(string[] args)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\Scripts\\pip.exe";
            run0.Arguments = "install " + string.Join(" ", args) + " --no-index --find-links /";
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            if (Console)
            {
                System.Console.WriteLine(reader.ReadToEnd());
            }
        }

        public void Stop()
        {
            if (!Process.HasExited)
            {
                Process.CloseMainWindow();
                Process.WaitForExit(2000);
                if (!Process.HasExited)
                {
                    Process.Kill();
                    Process.WaitForExit();
                }
            }
        }

        public void Run(string script)
        {
            File.Create("python3_13\\main.py").Close();
            File.WriteAllText("python3_13\\main.py", script);

            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\python.exe";
            run0.Arguments = "python3_13\\main.py";
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            System.Console.WriteLine(reader.ReadToEnd());
        }

        public void RunFile(string filePath)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\python.exe";
            run0.Arguments = filePath;
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            System.Console.WriteLine(reader.ReadToEnd());
        }

        public string GetOutput(string script)
        {
            File.Create("python3_13\\main.py").Close();
            File.WriteAllText("python3_13\\main.py", script);

            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\python.exe";
            run0.Arguments = "python3_13\\main.py";
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            return reader.ReadToEnd();
        }

        public string GetFileOutput(string filePath)
        {
            ProcessStartInfo run0 = new ProcessStartInfo();
            run0.FileName = "python3_13\\python.exe";
            run0.Arguments = filePath;
            run0.UseShellExecute = false;
            run0.RedirectStandardOutput = true;
            run0.CreateNoWindow = Console;
            Process = Process.Start(run0);
            StreamReader reader = Process.StandardOutput;
            return reader.ReadToEnd();
        }
    }
}
