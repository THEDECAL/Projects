using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartfon_shop
{
    class Smartfone
    {
        public string Name { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
        public string CommStd { get; set; }
        public decimal ScrDiag { get; set; }
        public string ScrResol { get; set; }
        public string MatrixType { get; set; }
        public int CntTouchPoint { get; set; }
        public string ScrMaterial { get; set; }
        public int CntSIMCards { get; set; }
        public string SIMType { get; set; }
        public int RAM { get; set; }
        public int BMEM { get; set; }
        public string MemCardsType { get; set; }
        public int MaxMem { get; set; }
        public string OS { get; set; }
        public string QualityFrontalCamera { get; set; }
        public string QualityFrontalVideo { get; set; }
        public string QualityGeneralCamera { get; set; }
        public string QualityGeneralVideo { get; set; }
        public string Flash { get; set; }
        public int BatteryCapp { get; set; }
        public string ChargerConn { get; set; }
        public string AudioConn { get; set; }
        public int Weight { get; set; }
        public string WirelessTech { get; set; }
        public string Color { get; set; }
    }
}
