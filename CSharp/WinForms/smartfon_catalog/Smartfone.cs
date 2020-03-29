using System.Data.Linq.Mapping;
using System.Text.RegularExpressions;

namespace smartfon_catalog
{
    [Table(Name = "smartfones")]
    class Smartfone
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Brand")]
        public string Brand { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "Image")]
        public byte[] Image { get; set; }
        [Column(Name = "CommStd")]
        public string CommStd { get; set; }
        [Column(Name = "ScrDiag")]
        public string ScrDiag { get; set; }
        [Column(Name = "ScrResol")]
        public string ScrResol { get; set; }
        [Column(Name = "MatrixType")]
        public string MatrixType { get; set; }
        [Column(Name = "CntSIMCards")]
        public string CntSIMCards { get; set; }
        [Column(Name = "SIMType")]
        public string SIMType { get; set; }
        [Column(Name = "RAM")]
        public string RAM { get; set; }
        [Column(Name = "BMEM")]
        public string BMEM { get; set; }
        [Column(Name = "MemCardsType")]
        public string MemCardsType { get; set; }
        [Column(Name = "OS")]
        public string OS { get; set; }
        [Column(Name = "QualityFrontalCamera")]
        public string QualityFrontalCamera { get; set; }
        [Column(Name = "QualityGeneralCamera")]
        public string QualityGeneralCamera { get; set; }
        [Column(Name = "BatteryCapp")]
        public string BatteryCapp { get; set; }
        [Column(Name = "Color")]
        public string Color { get; set; }
        public override string ToString() => $"Brand: {Brand}, Model: {Name}";
    }
}
