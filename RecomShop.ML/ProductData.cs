using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ML.Data;


namespace RecomShop.ML
{
    public class ProductData
    {
        [LoadColumn(0)]
        public float Price { get; set; }

        [LoadColumn(1)]
        public float Rating { get; set; }
    }
}

