using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ML.Data;

namespace RecomShop.ML
{
    public class ProductPrediction
    {
        [ColumnName("Score")]
        public float PredictedPrice { get; set; }
    }
}
