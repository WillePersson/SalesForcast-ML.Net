﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace SalesForcastModel_ConsoleApp
{
    public partial class SalesForcastModel
    {
        /// <summary>
        /// model input class for SalesForcastModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"CompanyID")]
            public float CompanyID { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"Month")]
            public float Month { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"NumberOfEmployees")]
            public float NumberOfEmployees { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"MarketingBudget")]
            public float MarketingBudget { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"IndustryType")]
            public string IndustryType { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"HistoricalSales")]
            public float HistoricalSales { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for SalesForcastModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"CompanyID")]
            public float CompanyID { get; set; }

            [ColumnName(@"Month")]
            public float Month { get; set; }

            [ColumnName(@"NumberOfEmployees")]
            public float NumberOfEmployees { get; set; }

            [ColumnName(@"MarketingBudget")]
            public float MarketingBudget { get; set; }

            [ColumnName(@"IndustryType")]
            public float[] IndustryType { get; set; }

            [ColumnName(@"HistoricalSales")]
            public float HistoricalSales { get; set; }

            [ColumnName(@"ProjectedSales")]
            public float ProjectedSales { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("SalesForcastModel.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }
    }
}
