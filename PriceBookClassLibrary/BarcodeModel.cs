using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBookClassLibrary
{
    public class BarcodeModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public int ProductId { get; set; }
    }
}
