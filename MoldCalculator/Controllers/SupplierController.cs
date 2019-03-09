using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class SupplierController
    {
        // Create
        public static void Insert(Supplier model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.Suppliers.SingleOrDefault(s => s.SupplierID == model.SupplierID && s.SupplierName.Equals(model.SupplierName));
                if (canInsert == null)
                {
                    db.Suppliers.Add(model);
                    db.SaveChanges();
                }
            }
        }

        // Read
        public static List<Supplier> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.Suppliers.ToList();
            }
        }

        // Update
        public static void Update(Supplier model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.Suppliers.SingleOrDefault(s => s.SupplierID == model.SupplierID);
                if (canUpdate != null)
                {
                    canUpdate.SupplierName = model.SupplierName;
                    canUpdate.Description = model.Description;
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
                var canDelete = db.Suppliers.SingleOrDefault(s => s.SupplierID == ID);
                if (canDelete != null)
                {
                    db.Suppliers.Remove(canDelete);
                    db.SaveChanges();
                }
            }
        }

    }
}
