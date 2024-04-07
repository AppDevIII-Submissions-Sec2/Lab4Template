using MauiFitness.Config;
using MauiFitness.DataRepos;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MauiFitness
{
    public partial class App : Application
    {
        public static Settings Settings { get; private set; }

        private static FitnessRepo repo;
        public static FitnessRepo Repo
        {
            get
            {
                return repo ??= new FitnessRepo();
            }
        }
        public App()
        {
            InitializeComponent();
            var a = Assembly.GetExecutingAssembly();
            var stream = a.GetManifestResourceStream("MauiFitness.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();
            Settings = config.GetRequiredSection(nameof(Settings)).Get<Settings>();
            MainPage = new AppShell();  
        }
    }
}
