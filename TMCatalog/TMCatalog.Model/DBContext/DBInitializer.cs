﻿// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.Model.DBContext
{
    using System.Data.Entity;
    using TMCatalogClient.Model;

    /// <summary>
    /// Database initialization
    /// </summary>
    /// <seealso cref="System.Data.Entity.CreateDatabaseIfNotExists{TMCatalog.Model.DBContext.TMCatalogDB}" />
    public class DBInitializer : CreateDatabaseIfNotExists<TMCatalogDB>
    {
        protected override void Seed(TMCatalogDB context)
        {
            this.AddFuelTypes(context);
            this.AddProductGroups(context);
            this.AddProducts(context);
            this.AddArticles(context);
            this.AddStocks(context);
            this.AddManufacturers(context);
            this.AddModels(context);
            this.AddVehicleTypes(context);
            this.AddVehicleTypeVin(context);
            this.AddVehicleTypeProducts(context);
            this.AddVehicleTypeArticles(context);
        }

        private void AddArticles(TMCatalogDB context)
        {
            context.Articles.Add(new Article { Id = 1, ArticleNumber = "1101", Description = "BOSCH Fog Light", ProductId = 1 });
            context.Articles.Add(new Article { Id = 2, ArticleNumber = "2201", Description = "BOSCH Headlight", ProductId = 2 });
            context.Articles.Add(new Article { Id = 3, ArticleNumber = "3301", Description = "BOSCH Indicator", ProductId = 3 });
            context.Articles.Add(new Article { Id = 4, ArticleNumber = "4401", Description = "BOSCH Brake Disk", ProductId = 4 });
            context.Articles.Add(new Article { Id = 5, ArticleNumber = "5501", Description = "BOSCH Brake Hose", ProductId = 5 });
            context.Articles.Add(new Article { Id = 6, ArticleNumber = "6601", Description = "BOSCH Cable, parking brake", ProductId = 6 });
            context.Articles.Add(new Article { Id = 7, ArticleNumber = "7701", Description = "BOSCH Oil Filter", ProductId = 7 });
            context.Articles.Add(new Article { Id = 8, ArticleNumber = "8801", Description = "BOSCH Air Filter", ProductId = 8 });
            context.Articles.Add(new Article { Id = 9, ArticleNumber = "9901", Description = "BOSCH Lambda sensor", ProductId = 9 });
            context.Articles.Add(new Article { Id = 10, ArticleNumber = "1011", Description = "BOSCH Fuel Filter", ProductId = 10 });
            context.Articles.Add(new Article { Id = 11, ArticleNumber = "1111", Description = "BOSCH Filter, interior air", ProductId = 11 });

            context.Articles.Add(new Article { Id = 12, ArticleNumber = "1210", Description = "HELLA Fog Light", ProductId = 1 });
            context.Articles.Add(new Article { Id = 13, ArticleNumber = "1320", Description = "HELLA Headlight", ProductId = 2 });
            context.Articles.Add(new Article { Id = 14, ArticleNumber = "1430", Description = "HELLA Indicator", ProductId = 3 });
            context.Articles.Add(new Article { Id = 15, ArticleNumber = "1540", Description = "ABE Brake Disk", ProductId = 4 });
            context.Articles.Add(new Article { Id = 16, ArticleNumber = "1650", Description = "ABE Brake Hose", ProductId = 5 });
            context.Articles.Add(new Article { Id = 17, ArticleNumber = "1760", Description = "ABE Cable, parking brake", ProductId = 6 });
            context.Articles.Add(new Article { Id = 18, ArticleNumber = "1870", Description = "MAHLE Oil Filter", ProductId = 7 });
            context.Articles.Add(new Article { Id = 19, ArticleNumber = "1980", Description = "MAHLE Air Filter", ProductId = 8 });
            context.Articles.Add(new Article { Id = 20, ArticleNumber = "2090", Description = "MAHLE Lambda sensor", ProductId = 9 });
            context.Articles.Add(new Article { Id = 21, ArticleNumber = "2110", Description = "MAHLE Fuel Filter", ProductId = 10 });
            context.Articles.Add(new Article { Id = 22, ArticleNumber = "2211", Description = "MAHLE Filter, interior air", ProductId = 11 });
        }

        private void AddFuelTypes(TMCatalogDB context)
        {
            context.FuelTypes.Add(new FuelType { Id = 1, Description = "Petrol" });
            context.FuelTypes.Add(new FuelType { Id = 2, Description = "Diesel" });
        }

        private void AddManufacturers(TMCatalogDB context)
        {
            context.Manufacturer.Add(new Manufacturer { Id = 1, Description = "VW" });
            context.Manufacturer.Add(new Manufacturer { Id = 2, Description = "Audi" });
            context.Manufacturer.Add(new Manufacturer { Id = 3, Description = "Mercedes-Benz" });
            context.Manufacturer.Add(new Manufacturer { Id = 4, Description = "BMW" });
            context.Manufacturer.Add(new Manufacturer { Id = 5, Description = "Opel" });
        }

        private void AddModels(TMCatalogDB context)
        {
            context.Models.Add(new Model { Id = 1, Description = "Golf V (1K1)", ManufacturerId = 1 });
            context.Models.Add(new Model { Id = 2, Description = "Polo Classic (6KV2)", ManufacturerId = 1 });
            context.Models.Add(new Model { Id = 3, Description = "Passat (362)", ManufacturerId = 1 });
            context.Models.Add(new Model { Id = 4, Description = "A3 (8P1)", ManufacturerId = 2 });
            context.Models.Add(new Model { Id = 5, Description = "Q7 (4L)", ManufacturerId = 2 });
            context.Models.Add(new Model { Id = 6, Description = "A-CLASS (W169)", ManufacturerId = 3 });
            context.Models.Add(new Model { Id = 7, Description = "G-CLASS (W460)", ManufacturerId = 3 });
            context.Models.Add(new Model { Id = 8, Description = "5 (E39)", ManufacturerId = 4 });
            context.Models.Add(new Model { Id = 9, Description = "7 (G11, G12)", ManufacturerId = 4 });
            context.Models.Add(new Model { Id = 10, Description = "ASTRA H (L48)", ManufacturerId = 5 });
            context.Models.Add(new Model { Id = 11, Description = "CORSA E", ManufacturerId = 5 });

        }

        private void AddProducts(TMCatalogDB context)
        {
            context.Products.Add(new Product { Id = 1, Description = "Fog Light", ProductGroupId = 1 });

            context.Products.Add(
                new Product
                {
                    Id = 2,
                    Description = "Headlight",
                    ProductGroupId = 1,
                });

            context.Products.Add(
                new Product
                {
                    Id = 3,
                    Description = "Indicator",
                    ProductGroupId = 1,
                });

            context.Products.Add(
                new Product
                {
                    Id = 4,
                    Description = "Brake Disk",
                    ProductGroupId = 2,
                });

            context.Products.Add(
                new Product
                {
                    Id = 5,
                    Description = "Brake Hose",
                    ProductGroupId = 2,
                });

            context.Products.Add(
                new Product
                {
                    Id = 6,
                    Description = "Cable, parking brake",
                    ProductGroupId = 2,
                });

            context.Products.Add(
                new Product
                {
                    Id = 7,
                    Description = "Oil Filter",
                    ProductGroupId = 3,
                });

            context.Products.Add(
                new Product
                {
                    Id = 8,
                    Description = "Air Filter",
                    ProductGroupId = 3,
                });

            context.Products.Add(
                new Product
                {
                    Id = 9,
                    Description = "Lambda sensor",
                    ProductGroupId = 3,
                });

            context.Products.Add(
                new Product
                {
                    Id = 10,
                    Description = "Fuel Filter",
                    ProductGroupId = 4,
                });

            context.Products.Add(
                new Product
                {
                    Id = 11,
                    Description = "Filter, interior air",
                    ProductGroupId = 4,
                });
        }

        private void AddProductGroups(TMCatalogDB context)
        {
            context.ProductGroups.Add(new ProductGroup { Id = 1, Description = "Body" });
            context.ProductGroups.Add(new ProductGroup { Id = 2, Description = "Brake System" });
            context.ProductGroups.Add(new ProductGroup { Id = 3, Description = "Engine" });
            context.ProductGroups.Add(new ProductGroup { Id = 4, Description = "Filters" });
        }

        private void AddStocks(TMCatalogDB context)
        {
            context.Stocks.Add(new Stock { ArticleId = 1, Quantity = 200, Price = 10.5M });
            context.Stocks.Add(new Stock { ArticleId = 2, Quantity = 200, Price = 23.6M });
            context.Stocks.Add(new Stock { ArticleId = 3, Quantity = 200, Price = 20.65M });
            context.Stocks.Add(new Stock { ArticleId = 4, Quantity = 200, Price = 10 });
            context.Stocks.Add(new Stock { ArticleId = 5, Quantity = 200, Price = 30 });
            context.Stocks.Add(new Stock { ArticleId = 6, Quantity = 200, Price = 35.6M });
            context.Stocks.Add(new Stock { ArticleId = 7, Quantity = 200, Price = 8.9M });
            context.Stocks.Add(new Stock { ArticleId = 8, Quantity = 200, Price = 7.3M });
            context.Stocks.Add(new Stock { ArticleId = 9, Quantity = 200, Price = 189.3M });
            context.Stocks.Add(new Stock { ArticleId = 10, Quantity = 200, Price = 65.4M });
            context.Stocks.Add(new Stock { ArticleId = 11, Quantity = 200, Price = 32 });

            context.Stocks.Add(new Stock { ArticleId = 12, Quantity = 200, Price = 87.9M });
            context.Stocks.Add(new Stock { ArticleId = 13, Quantity = 200, Price = 45 });
            context.Stocks.Add(new Stock { ArticleId = 14, Quantity = 200, Price = 54 });
            context.Stocks.Add(new Stock { ArticleId = 15, Quantity = 200, Price = 64 });
            context.Stocks.Add(new Stock { ArticleId = 16, Quantity = 200, Price = 89 });
            context.Stocks.Add(new Stock { ArticleId = 17, Quantity = 200, Price = 87.9M });
            context.Stocks.Add(new Stock { ArticleId = 18, Quantity = 200, Price = 96 });
            context.Stocks.Add(new Stock { ArticleId = 19, Quantity = 200, Price = 96.3M });
            context.Stocks.Add(new Stock { ArticleId = 20, Quantity = 200, Price = 98.5M });
            context.Stocks.Add(new Stock { ArticleId = 21, Quantity = 200, Price = 34.7M });
            context.Stocks.Add(new Stock { ArticleId = 22, Quantity = 200, Price = 45.1M });
        }

        private void AddVehicleTypes(TMCatalogDB context)
        {
            context.VehicleTypes.Add(new VehicleType { Id = 1, Description = "VW GOLF V (1K1) 1.4 TSI", ModelId = 1, TecDocID = 1101, ProductionYearFrom = 2003, ProductionYearTo = 2006, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 2, Description = "VW GOLF V (1K1) 1.9 TDI", ModelId = 1, TecDocID = 1102, ProductionYearFrom = 2004, ProductionYearTo = 2008, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 3, Description = "Polo Classic (6KV2) 75 1.6", ModelId = 2, TecDocID = 1201, ProductionYearFrom = 1995, ProductionYearTo = 1997, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 4, Description = "Polo Classic (6KV2) 90 1.9 TDI", ModelId = 2, TecDocID = 1202, ProductionYearFrom = 1996, ProductionYearTo = 2001, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 5, Description = "VW PASSAT (32) 1.3", ModelId = 3, TecDocID = 1301, ProductionYearFrom = 1973, ProductionYearTo = 1980, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 6, Description = "VW PASSAT (32) 1.5 D", ModelId = 3, TecDocID = 1302, ProductionYearFrom = 1977, ProductionYearTo = 1980, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 7, Description = "A3 (8P1) 1.6", ModelId = 4, TecDocID = 2101, ProductionYearFrom = 2003, ProductionYearTo = 2012, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 8, Description = "A3 (8P1) 1.9 TDI", ModelId = 4, TecDocID = 2102, ProductionYearFrom = 2003, ProductionYearTo = 2010, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 9, Description = "Q7 (4L) 3.0 TFSI", ModelId = 5, TecDocID = 2201, ProductionYearFrom = 2010, ProductionYearTo = 2015, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 10, Description = "Q7 (4L) 3.0 TDI", ModelId = 5, TecDocID = 2202, ProductionYearFrom = 2007, ProductionYearTo = 2015, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 11, Description = "Mercedes-Benz A-CLASS (W169) A180", ModelId = 6, TecDocID = 3101, ProductionYearFrom = 2009, ProductionYearTo = 2012, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 12, Description = "Mercedes-Benz A-CLASS (W169) A180 CDI", ModelId = 6, TecDocID = 3102, ProductionYearFrom = 2004, ProductionYearTo = 2012, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 13, Description = "Mercedes-Benz G - CLASS(W460) 230G", ModelId = 7, TecDocID = 3201, ProductionYearFrom = 1982, ProductionYearTo = 1992, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 14, Description = "Mercedes-Benz G-CLASS (W460) 250GD", ModelId = 7, TecDocID = 3202, ProductionYearFrom = 1988, ProductionYearTo = 1992, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 15, Description = "BMW 5 (E39) 520 i", ModelId = 8, TecDocID = 4101, ProductionYearFrom = 1999, ProductionYearTo = 2003, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 16, Description = "BMW 5 (E39) 530 d", ModelId = 8, TecDocID = 4102, ProductionYearFrom = 2000, ProductionYearTo = 2003, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 17, Description = "BMW 7 (G11, G12) 730 i", ModelId = 9, TecDocID = 4201, ProductionYearFrom = 2016, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 18, Description = "BMW 7 (G11, G12) 730 d", ModelId = 9, TecDocID = 4202, ProductionYearFrom = 2015, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 19, Description = "OPEL ASTRA H (L48) 1.4", ModelId = 10, TecDocID = 5101, ProductionYearFrom = 2005, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 20, Description = "OPEL ASTRA H (L48) 1.9 CDTI", ModelId = 10, TecDocID = 5101, ProductionYearFrom = 2004, FuelTypeId = 2 });
            context.VehicleTypes.Add(new VehicleType { Id = 21, Description = "OPEL CORSA 1.0", ModelId = 11, TecDocID = 5201, ProductionYearFrom = 2014, FuelTypeId = 1 });
            context.VehicleTypes.Add(new VehicleType { Id = 22, Description = "OPEL CORSA 1.3 CDTI", ModelId = 11, TecDocID = 5202, ProductionYearFrom = 2014, FuelTypeId = 2 });
        }

        private void AddVehicleTypeArticles(TMCatalogDB context)
        {
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 1 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 1 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 2 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 2 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 3 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 3 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 4 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 4 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 5 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 5 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 6 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 6 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 7 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 7 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 8 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 8 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 9 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 9 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 10 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 10 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 11 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 11 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 12 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 12 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 13 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 13 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 14 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 14 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 15 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 15 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 16 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 16 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 17 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 17 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 18 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 18 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 19 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 19 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 20 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 20 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 21 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 21 });

            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 1, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 2, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 3, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 4, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 5, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 6, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 7, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 8, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 9, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 10, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 11, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 12, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 13, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 14, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 15, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 16, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 17, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 18, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 19, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 20, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 21, VehicleTypeId = 22 });
            context.VehicleTypeArticles.Add(new VehicleTypeArticles { ArticleId = 22, VehicleTypeId = 22 });
        }

        private void AddVehicleTypeProducts(TMCatalogDB context)
        {
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 1, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 2, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 3, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 4, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 5, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 6, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 7, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 8, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 9, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 10, VehicleTypeId = 22 });

            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 1 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 2 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 3 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 4 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 5 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 6 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 7 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 8 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 9 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 10 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 11 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 12 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 13 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 14 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 15 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 16 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 17 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 18 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 19 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 20 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 21 });
            context.VehicleTypeProducts.Add(new VehicleTypeProducts { ProductId = 11, VehicleTypeId = 22 });
        }

        private void AddVehicleTypeVin(TMCatalogDB context)
        {
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 1, VIN = "WVWZZZ1JZ3W245274" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 2, VIN = "WVWZZZ1JZ3W245275" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 3, VIN = "WVWZZZ1JZ3W245276" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 4, VIN = "WVWZZZ1JZ3W245277" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 5, VIN = "WVWZZZ1JZ3W245278" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 6, VIN = "WVWZZZ1JZ3W245279" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 7, VIN = "WAUZZZ8K6AA103082" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 8, VIN = "WAUZZZ8K6AA103083" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 9, VIN = "WAUZZZ8K6AA103084" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 10, VIN = "WAUZZZ8K6AA103085" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 11, VIN = "WDBHA28E5VF557286" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 12, VIN = "WDBHA28E5VF557287" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 13, VIN = "WDBHA28E5VF557288" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 14, VIN = "WDBHA28E5VF557289" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 15, VIN = "WBABA7300NEJ13724" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 16, VIN = "WBABA7300NEJ13725" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 17, VIN = "WBABA7300NEJ13726" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 18, VIN = "WBABA7300NEJ13727" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 19, VIN = "W0L0XCE75640002092" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 20, VIN = "W0L0XCE75640002091" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 22, VIN = "W0L0XCE75640002093" });
            context.VehicleTypeVin.Add(new VehicleTypeVin { VehicleTypeId = 22, VIN = "W0L0XCE75640002094" });
        }
    }
}
