using System.Data.Linq.Mapping;
using System.Text.RegularExpressions;

namespace smartfon_catalog
{
    class Smartfone
    {
        public int Id { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public string Name { get; set; } = "";
        public byte[] Image { get; set; }
        public string CommStd { get; set; } = "";
        public string ScrDiag { get; set; } = "";
        public string ScrResol { get; set; } = "";
        public string MatrixType { get; set; } = "";
        public string CntSIMCards { get; set; } = "";
        public string SIMType { get; set; } = "";
        public string RAM { get; set; } = "";
        public string BMEM { get; set; } = "";
        public string MemCardsType { get; set; } = "";
        public string OS { get; set; } = "";
        public string QualityFrontalCamera { get; set; } = "";
        public string QualityGeneralCamera { get; set; } = "";
        public string BatteryCapp { get; set; } = "";
        public string Color { get; set; } = "";
        public override string ToString() => $"Brand: {Brand}, Model: {Name}";
    }
}
