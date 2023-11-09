using GuardarImagen.Controllers;
namespace GuardarImagen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        static Database _db;

        public static Database instance
        {
            get
            {
                if (_db == null)
                {
                    string dbName = "ImagesDatabase.db3";
                    string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbFull = Path.Combine(dbPath, dbName);
                    _db = new Database(dbFull);
                }
                return _db;
            }
        }
    }
}