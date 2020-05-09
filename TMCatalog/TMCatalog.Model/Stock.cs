// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
  using System.ComponentModel.DataAnnotations;
    using TMCatalog.Common.Interfaces;
    using TMCatalog.Common.MVVM;

    /// <summary>
    /// Stock
    /// </summary>
    public class Stock : ViewModelBase, IStock
  {
        private int quantity;
    [Key]
    public int ArticleId { get; set; }

    public Stock()
    {

    }

    public Stock(Stock stock)
    {
        this.ArticleId = stock.ArticleId;
        this.Article = stock.Article;
        this.Price = stock.Price;
        this.Quantity = 1;
    }



    public Article Article { get; set; }

    public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Stock.TotalPrice));
            }
        }

    public decimal Price { get; set; }

    public decimal TotalPrice
    {
        get
        {
            return this.Quantity * this.Price;
        }
    }
  }
}
