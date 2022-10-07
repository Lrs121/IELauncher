
namespace IELauncher
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles(); // to enable visual styles in message boxes

            // The SHDocVw object requires a refrence to COM object "Microsoft Internet Controls"
            SHDocVw.InternetExplorer IE = new();
            object URL = Properties.Settings.Default.StartupURL;

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
                            string argPart2 = arg.Remove(0, argPart1.Length + 1); // here i added '+1' to remove the leading ':'

                            switch (argPart1.ToLower())
                            {
                                case "url":
                                    if (!string.IsNullOrEmpty(argPart2))
                                        URL = argPart2;
                                    else
                                        URL = "about:blank";
                                    break;
                                case "startupurl": // set new startup url and quit
                                    Properties.Settings.Default.StartupURL = argPart2;
                                    Properties.Settings.Default.Save();
                                    MessageBox.Show("The new startup URL is: " + Properties.Settings.Default.StartupURL);
                                    return;
                                default:
                                    ShowHelpAndQuit(argPart1);
                                    break;
                            }
                        }
                        else
                        {
                            ShowHelpAndQuit(argToBeParsed.Remove(0, 1));
                        }
                    }
                    else
                    {
                        ShowHelpAndQuit(argToBeParsed);
                    }
                }
            }

            // Call the IE instance to open the specified URL
            IE.Visible = true;
            IE.Navigate2(ref URL);
        }

        private static void ShowHelpAndQuit(string? option = null)
        {
            if (option is not null)
            {
                MessageBox.Show("Unknown or incomplete option: " + option, "Internet Explorer Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show("Available options: " + Environment.NewLine + "   /URL:<URL>\t\tStart IE with <URL> as URL" + Environment.NewLine + "   /StartupURL:<URL>\tSet the startup URL", "Internet Explorer Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(1);
        }
    }
}
