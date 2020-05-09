// ------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogController.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using TMCatalog.Model;
    using TMCatalog.Model.DBContext;
    using TMCatalogClient.Model;

    public class CatalogController
    {
        private TMCatalogDB catalogDatabase;

        public CatalogController()
        {
            this.catalogDatabase = new TMCatalogDB();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.catalogDatabase.Manufacturer.ToList();
        }

        public List<Model> GetModels(int manufacturerId)
        {
            return this.catalogDatabase.Models.Where(x => x.ManufacturerId == manufacturerId).ToList();
        }

        public List<VehicleType> GetVehicleTypes(int modelId)
        {
            return this.catalogDatabase.VehicleTypes.Include("Model").Include("Model.Manufacturer").Include("FuelType").
                Where(x => x.ModelId == modelId).
                OrderBy(m => m.Model.Manufacturer.Description).
                ThenBy(m => m.Model.Description).
                ThenBy(m => m.Description).
                ToList();
        }

        public List<Product> GetProducts(int vehicleTypeID)
        {
            return this.catalogDatabase.VehicleTypeProducts.
                Where(vt => vt.VehicleTypeId == vehicleTypeID).
                Select(p => p.Product)
                .ToList();
        }

        public List<Product> GetProductsV2(int vehicleTypeID)
        {
            List<Product> products = (from p in this.catalogDatabase.Products
                                      join v in this.catalogDatabase.VehicleTypeProducts on p.Id equals v.ProductId
                                      where v.VehicleTypeId == vehicleTypeID
                                      select p).ToList();

            return products;
        }

        public List<ProductGroup> GetProductGroups(int vehicleTypeID)
        {
            IEnumerable<VehicleTypeProducts> vehicleTypeProducts = this.catalogDatabase.VehicleTypeProducts.
                Include("Product").Include("Product.ProductGroup").
                Where(vt => vt.VehicleTypeId == vehicleTypeID);

            List<ProductGroup> productGroups = new List<ProductGroup>();

            if (vehicleTypeProducts.Count() > 0)
            {
                foreach (IGrouping<ProductGroup, VehicleTypeProducts> item in vehicleTypeProducts.GroupBy(p => p.Product.ProductGroup)) {
                    ProductGroup productGroup = item.Key;
                    productGroup.Products = new List<Product>();

                    foreach (VehicleTypeProducts vtp in item)
                    {
                        productGroup.Products.Add(vtp.Product);
                    }

                    productGroups.Add(productGroup);
                }
            }

            return productGroups;
        }

        public List<Article> GetArticles(int vehicleTypeID, int productID)
        {
            return this.catalogDatabase.VehicleTypeArticles.
                Include("Article").
                Where(vta => vta.VehicleTypeId == vehicleTypeID && vta.Article.ProductId == productID).
                Select(a => a.Article).ToList();
        }

        public Stock GetArticleStock(int articleID)
        {
            return this.catalogDatabase.Stocks.FirstOrDefault(s => s.ArticleId == articleID);
        }

        ///Fitness app querrys
        ///

        public List<Client> GetAllClients()
        {
            return this.catalogDatabase.Clients.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }

        public List<Client> SearchClientByPhoneNumber(string phoneNumber)
        {
            return this.catalogDatabase.Clients.Where(c => c.PhoneNumber.Contains(phoneNumber)).ToList();
        }

        public List<Client> SearchClientByCardNumber(int cardNumber)
        {
            return this.catalogDatabase.Clients.Where(c => c.CardNumber == cardNumber).ToList();
        }

        public List<Client> SearchClientByName(string name)
        {
            return this.catalogDatabase.Clients.
                Where(c => string.Concat(c.FirstName, " ", c.LastName).ToLower().Contains(name.ToLower())).
                ToList();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.catalogDatabase.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public List<ClientMembership> GetAllClientMemberships(bool listInaciveMemberships)
        {
            if (listInaciveMemberships)
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    OrderBy(cm => cm.Client.FirstName).ThenBy(cm => cm.Client.LastName).ToList();
            }
            else
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    Where(cm => cm.Active == true).
                    OrderBy(cm => cm.Client.FirstName).ThenBy(cm => cm.Client.LastName).ToList();
            }
        }

        public List<ClientMembership> SearchClientMembershipByCardNumber(int cardNumber, bool listInaciveMemberships)
        {
            if (listInaciveMemberships)
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    Where(cm => cm.Client.CardNumber == cardNumber).ToList();
            }
            else
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    Where(cm => cm.Client.CardNumber == cardNumber && cm.Active == true).ToList();
            }
        }

        public List<ClientMembership> SearchClientMembershipByName(string name, bool listInaciveMemberships)
        {
            if (listInaciveMemberships)
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    Where(cm => string.Concat(cm.Client.FirstName, " ", cm.Client.LastName).ToLower().Contains(name.ToLower())).
                    ToList();
            }
            else
            {
                return this.catalogDatabase.ClientMemberships.
                    Include("Client").
                    Include("Ticket").
                    Where(cm => string.Concat(cm.Client.FirstName, " ", cm.Client.LastName).ToLower().Contains(name.ToLower()) && cm.Active == true).
                    ToList();
            }
        }

        public List<object> GetAllClientTicketsList(bool listInactiveTicketAlso) 
        {
            IEnumerable<object> clientTickets;

            if (listInactiveTicketAlso)
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 orderby c.FirstName, c.LastName ascending
                                 select new { 
                                     c.CardNumber, 
                                     c.FirstName,
                                     c.LastName, 
                                     TicketType = t.Type, 
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber), 
                                     cm.EntranceLeft, 
                                     c.Comment, 
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }
            else
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where (cm.EntranceLeft > 0 || cm.EntranceLeft == -1) && (DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber) >= DateTime.Now)
                                 orderby c.FirstName, c.LastName ascending
                                 select new { 
                                     c.CardNumber, 
                                     c.FirstName, 
                                     c.LastName, 
                                     TicketType = t.Type, 
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber), 
                                     cm.EntranceLeft, 
                                     c.Comment, 
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }

            return clientTickets.ToList();
        }

        public List<object> GetClientTicketsListByName(bool listInactiveTicketAlso, string name)
        {
            IEnumerable<object> clientTickets;

            if (listInactiveTicketAlso)
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where (c.FirstName + " " + c.LastName).ToLower().Contains(name.ToLower())
                                 orderby c.FirstName, c.LastName ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }
            else
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where (cm.EntranceLeft > 0 || cm.EntranceLeft == -1) && (DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber) >= DateTime.Now) &&
                                    ((c.FirstName + " " + c.LastName).ToLower().Contains(name.ToLower()))
                                 orderby c.FirstName, c.LastName ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }

            return clientTickets.ToList();
        }

        public List<object> GetClientTicketsListByPhoneNumber(bool listInactiveTicketAlso, string phoneNumber)
        {
            IEnumerable<object> clientTickets;

            if (listInactiveTicketAlso)
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where c.PhoneNumber.Contains(phoneNumber)
                                 orderby c.PhoneNumber ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }
            else
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where (cm.EntranceLeft > 0 || cm.EntranceLeft == -1) && (DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber) >= DateTime.Now) &&
                                    c.PhoneNumber.Contains(phoneNumber)
                                 orderby c.PhoneNumber ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }

            return clientTickets.ToList();
        }

        public List<object> GetClientTicketsListByCardNumber(bool listInactiveTicketAlso, string cardNumber)
        {
            IEnumerable<object> clientTickets;

            if (listInactiveTicketAlso)
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where c.CardNumber.ToString().Contains(cardNumber)
                                 orderby c.CardNumber ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }
            else
            {
                clientTickets = (from c in this.catalogDatabase.Clients
                                 join cm in this.catalogDatabase.ClientMemberships on c.Id equals cm.TicketId
                                 join t in this.catalogDatabase.Tickets on cm.TicketId equals t.Id
                                 where (cm.EntranceLeft > 0 || cm.EntranceLeft == -1) && (DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber) >= DateTime.Now) &&
                                    c.CardNumber.ToString().Contains(cardNumber)
                                 orderby c.CardNumber ascending
                                 select new
                                 {
                                     c.CardNumber,
                                     c.FirstName,
                                     c.LastName,
                                     TicketType = t.Type,
                                     ValidUntil = DbFunctions.AddDays(cm.ValidAfter, t.ValidityNumber),
                                     cm.EntranceLeft,
                                     c.Comment,
                                     t.ValidityNumber,
                                     c.PhoneNumber,
                                     cm.Id
                                 }).ToList();
            }

            return clientTickets.ToList();
        }
    }
}
    