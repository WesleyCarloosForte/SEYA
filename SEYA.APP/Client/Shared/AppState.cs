namespace SEYA.APP.Client.Shared
{
    public static class AppState
    {
        public static bool IsMenuVisible { get; set; } = false;
        public static bool IsSalirVisible { get; set; } = false;
        public static bool IsVisibleAll { get; set; } = false;
        public static void ShowSalir()
        {
            IsSalirVisible= true;
        }
        public static void HideSalir()
        {
            IsSalirVisible = false;
        }
        public static void ShowMenu()
        {
            IsMenuVisible= true;
        }
        public static void HideMenu()
        {
            IsMenuVisible = false;
        }
        public static void HideMenuAll()
        {
            IsVisibleAll = false;
        }
        public static bool Nave =true;
    }
}
