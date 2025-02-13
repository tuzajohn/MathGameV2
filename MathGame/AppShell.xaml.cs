namespace MathGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute("playground", typeof(PlaygroundPage));
        }
    }
}
