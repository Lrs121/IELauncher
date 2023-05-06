
using IELauncher.Properties;
using System.Security.Policy;

namespace IELauncher
{
    class Program
    {
        private static void RunIE()
        {
            object URL = Settings.Default.StartupURL;

            // The SHDocVw object requires a refrence to COM object "Microsoft Internet Controls"
            SHDocVw.InternetExplorer IE = new();
            IE.Visible = true;
            IE.Navigate2(ref URL);
        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
#if DEBUG
            showGui();
            RunIE();
        }
#else

            string? processPath = Environment.ProcessPath;
            if (processPath != null && processPath.ToLower().Contains("gui"))
            {
                showGui();
            }

            if (args.Length >= 1)
            {
                foreach (string argToBeParsed in args)
                {
                    if (argToBeParsed.StartsWith('/'))
                    {
                        string arg = argToBeParsed.Remove(0, 1);
                        if (arg.Split(':').Length >= 2)
                        {
                            string argPart1 = arg.Split(':')[0];
                            string argPart2 = arg.Remove(0, argPart1.Length + 1);

                            switch (argPart1.ToLower())
                            {
                                case "url":
                                    if (!string.IsNullOrEmpty(argPart2))
                                        Settings.Default.StartupURL = argPart2;            // Here the URL is
                                    else                                                   // set into settings but settings
                                        Settings.Default.StartupURL = "about:blank";       // are not saved on close
                                    break;
                                case "startupurl":
                                    Settings.Default.StartupURL = argPart2;
                                    Settings.Default.Save(); // save settings before closing!
                                    MessageBox.Show("The new startup URL is: " + Settings.Default.StartupURL);
                                    break;
                                case "gui":
                                case "GUI":
                                    if (argPart2.ToLower() == "true" || argPart2 == "1")
                                        showGui();
                                    break;
                                default:
                                    ShowHelpAndQuit(argPart1);
                                    return;
                            }
                        }
                        else
                        {
                            ShowHelpAndQuit(argToBeParsed.Remove(0, 1));
                            return;
                        }
                    }
                    else
                    {
                        ShowHelpAndQuit(argToBeParsed);
                        return;
                    }
                }
            }

            RunIE();
        }
#endif

        private static void showGui()
        {
            if (new Gui().ShowDialog() != DialogResult.OK) Environment.Exit(1);
        }

        private static void ShowHelpAndQuit(string? option = null)
        {
            if (option is not null)
            {
                MessageBox.Show("Unknown or incomplete option: " + option, "Internet Explorer Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show("Available options: " + Environment.NewLine + "   /URL:<URL>\t\tStart IE with <URL> as URL" + Environment.NewLine + "   /StartupURL:<URL>\tSet the startup URL" + Environment.NewLine + "   /gui:true" + Environment.NewLine + "   /GUI:true\t\tShow a simple Graphical UI", "Internet Explorer Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(1);
        }
    }
}