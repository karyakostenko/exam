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
    public class GoodsStorage : IGoodsStorage
    {
        public List<GoodsViewModel> GetFullList()
        {
            using (var context = new DatabaseImplement())
            {
                return context.Goodses
                    .Select(CreateModel)   // linq запросы
                    .ToList();
            }
        }

        public List<GoodsViewModel> GetFiltredList(GoodsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                return context.Goodses
                    .Include(rec => rec.Market)
                    .Where(rec => rec.MarketId == model.MarketId)
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public GoodsViewModel GetElement(GoodsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                var component = context.Goodses
                    .Include(rec => rec.Market)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return component != null ?
                    CreateModel(component) : null;
            }
        }

        public void Insert(GoodsBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                context.Goodses.Add(CreateModel(model, new Goods()));
                context.SaveChanges();
            }
        }

        public void Update(GoodsBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var component = context.Goodses.FirstOrDefault(rec => rec.Id == model.Id);
                if(component != null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, component);
                context.SaveChanges();
            }
        }

        public void Delete(GoodsBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var component = context.Goodses.FirstOrDefault(rec => rec.Id == model.Id);
                if (component != null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Remove(component);
                context.SaveChanges();
            }
        }

        public GoodsViewModel CreateModel(Goods component)
        {
            return new GoodsViewModel
            {
                Id = component.Id,
                Name = component.Name,
                Cost = component.Cost,
                DateCreate = component.DateCreate,
                FirmName = component.FirmName,
                MarketId = component.MarketId
            };
        }

        public Goods CreateModel(GoodsBindingModel model, Goods component)
        {
            component.MarketId = model.MarketId;
            component.Name = model.Name;
            component.Cost = model.Cost;
            component.DateCreate = model.DateCreate;
            component.FirmName = model.FirmName;
            return component;
        }
    }
}
