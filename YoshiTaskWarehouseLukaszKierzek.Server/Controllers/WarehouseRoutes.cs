namespace YoshiTaskWarehouseLukaszKierzek.Server.Controllers
{
    public static class WarehouseRoutes
    {
        public const string defaultRoute = "[controller]";
        public const string dokumentPrzyjecia = "dokument-przyjecia";
        public const string magazyn = "magazyn";

        #region Towar
        public const string towarGET = "towar";
        public const string towarById = towarGET + "/{id}";
        public const string towarPOST = towarGET + "/{id}";
        public const string towarPUT = towarGET + "/{id}";
        public const string towarDELETE = towarGET + "/{id}";
        #endregion

        #region Dostawca
        public const string dostawcaGET = "dostawca";
        public const string dostawcaById = dostawcaGET + "/{id}";
        public const string dostawcaPOST = dostawcaGET + "/{id}";
        public const string dostawcaPUT = dostawcaGET + "/{id}";
        public const string dostawcaDELETE = dostawcaGET + "/{id}";
        #endregion
    }
}
