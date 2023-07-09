namespace ChessClient;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>

    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        //AppContext appContext = new AppContext();

        //Application.Run(appContext);
        Application.Run(new FormLauncher());
        //Application.Run(new FormPlayerVsPlayer());
    }
}

class AppContext : ApplicationContext
{
    private FormUDPClient _form1;
    private FormUDPClient _form2;

    public AppContext()
    {
        new FormLauncher().Show();

        Thread.Sleep(1000);
        _form1 = new("russ", "172.18.31.108", 32123);
        _form2 = new("john", "172.18.31.108", 32123);

        _form1.StartPosition = FormStartPosition.Manual;
        _form2.StartPosition = FormStartPosition.Manual;

        _form1.Location = new Point(300, 200);
        _form2.Location = new Point(1100, 200);

        _form1.Show();
        _form2.Show();

        _form1.BringToFront();
        _form2.BringToFront();
    }

}