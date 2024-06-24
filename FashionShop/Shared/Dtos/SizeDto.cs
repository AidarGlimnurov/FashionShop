using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
    /// <summary>
    /// Amount - численное значение размера с соответствии стандартами ГОСТ 31396-2009
    /// Letter - буквенное обозначение размера в международном формате
    /// Descrition - поле, где можно хранить дополнительные параметры в соответсвии со спецификой товара
    /// например обхват груди, талии и т.д 
    /// </summary>
    public class SizeDto
	{
        public int Id { get; set; }
        public string? Amount { get; set; }
        public string? Letter { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int? ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
}
