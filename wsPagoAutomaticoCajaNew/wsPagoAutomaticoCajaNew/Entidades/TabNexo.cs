namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class TabNexo
    {
        private string correlat;
        private string folioLi;
        private string folioNc;
        private string folioNd;
        private string folioRe;
        private string cdEstado;
        private string codSuc;

        public TabNexo()
        {
            this.correlat = "";
            this.folioLi = "";
            this.folioNc = "";
            this.folioNd = "";
            this.folioRe = "";
            this.cdEstado = "";
            this.codSuc = "";
        }

        public string Correlat
        {
            get { return correlat; }
            set { correlat = value; }
        }

        public string FolioLi
        {
            get { return folioLi; }
            set { folioLi = value; }
        }

        public string FolioNc
        {
            get { return folioNc; }
            set { folioNc = value; }
        }

        public string FolioNd
        {
            get { return folioNd; }
            set { folioNd = value; }
        }

        public string FolioRe
        {
            get { return folioRe; }
            set { folioRe = value; }
        }

        public string CdEstado
        {
            get { return cdEstado; }
            set { cdEstado = value; }
        }

        public string CodSuc
        {
            get { return codSuc; }
            set { codSuc = value; }
        }
    }
}