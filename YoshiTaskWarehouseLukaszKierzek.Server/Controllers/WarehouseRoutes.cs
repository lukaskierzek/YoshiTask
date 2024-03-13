namespace YoshiTaskWarehouseLukaszKierzek.Server.Controllers
{
    public static class WarehouseRoutes
    {
        public const string defaultRoute = "[controller]";

        #region DokuemntPrzyjecia
        public const string dokumentPrzyjeciaGET = "dokument-przyjecia";
        public const string dokumentPrzyjeciaById = dokumentPrzyjeciaGET + "/{id}";
        public const string dokumentPrzyjeciaPOST = dokumentPrzyjeciaGET;
        public const string dokumentPrzyjeciaPUT = dokumentPrzyjeciaGET + "/{id}";
        #endregion

        #region Magazyn
        public const string magazyn = "magazyn";
        #endregion

        #region Towar
        public const string towarGET = "towar";
        public const string towarById = towarGET + "/{id}";
        public const string towarPOST = towarGET;
        public const string towarPUT = towarGET + "/{id}";
        public const string towarDELETE = towarGET + "/{id}";
        #endregion

        #region Dostawca
        public const string dostawcaGET = "dostawca";
        public const string dostawcaById = dostawcaGET + "/{id}";
        public const string dostawcaPOST = dostawcaGET;
        public const string dostawcaPUT = dostawcaGET + "/{id}";
        public const string dostawcaDELETE = dostawcaGET + "/{id}";
        #endregion
    }
}
