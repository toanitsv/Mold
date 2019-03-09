using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class OrderController
    {
        // Create
        public static void Insert(Order model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.Orders.SingleOrDefault(s => s.OrderID == model.OrderID && s.OutsoleCode.Equals(model.OutsoleCode) && s.ShoeName.Equals(model.ShoeName));
                if (canInsert == null)
                {
                    db.Orders.Add(model);
                    db.SaveChanges();
                }
            }
        }

        // Read
        public static List<Order> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.Orders.ToList();
            }
        }

        // Update
        public static void Update(Order model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.Orders.SingleOrDefault(s => s.OrderID == model.OrderID);
                if (canUpdate != null)
                {
                    canUpdate.OutsoleCode = model.OutsoleCode;
                    canUpdate.Article = model.Article;
                    canUpdate.ShoeName = model.ShoeName;
                    canUpdate.CSD = model.CSD;
                    canUpdate.Quantity = model.Quantity;
                    canUpdate.IsEnable = model.IsEnable;
                    canUpdate.ModifiedTime = DateTime.Now;

                    db.SaveChanges();
                }
            }
        }

        // Delete
        public static void Delete(int ID)
        {
            using (var db = new MouldEntities())
            {
                var canDelete = db.Orders.SingleOrDefault(s => s.OrderID == ID);
                if (canDelete != null)
                {
                    db.Orders.Remove(canDelete);
                    db.SaveChanges();
                }
            }
        }

    }
}
