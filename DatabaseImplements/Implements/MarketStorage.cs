using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplements.Implements
{
    public class MarketStorage : IMarketStorage
    {
        public List<MarketViewModel> GetFullList()
        {
            using (var context = new DatabaseImplement())
            {
                return context.Markets
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public List<MarketViewModel> GetFiltredList(MarketBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                return context.Markets
                    .Where(rec =>(model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public MarketViewModel GetElement(MarketBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                var product = context.Markets
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return product != null ?
                    CreateModel(product) : null;
            }
        }

        public void Insert(MarketBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                context.Markets.Add(CreateModel(model, new Market()));
                context.SaveChanges();
            }
        }

        public void Update(MarketBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var product = context.Markets.FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, product);
                context.SaveChanges();
            }
        }

        public void Delete(MarketBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var product = context.Markets.FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Remove(product);
                context.SaveChanges();
            }
        }

        public MarketViewModel CreateModel(Market product)
        {
            return new MarketViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                DateCreate = product.DateCreate
            };
        }

        public Market CreateModel(MarketBindingModel model, Market product)
        {
            product.Name = model.Name;
            product.DateCreate = model.DateCreate;
            product.Author = model.Author;
            return product;
        }
    }
}
