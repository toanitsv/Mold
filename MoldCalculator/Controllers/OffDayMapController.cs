using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class OffDayMapController
    {
        // Create
        public static void Insert(OffDay_Supplier_Mapping model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.OffDay_Supplier_Mappings.SingleOrDefault(s => s.ID == model.ID && s.OffDayID == model.OffDayID && s.SupplierID == model.SupplierID);
                if (canInsert == null)
                {
                    db.OffDay_Supplier_Mappings.Add(model);
                    db.SaveChanges();
                }
            }
        }

        // Read
        public static List<OffDay_Supplier_Mapping> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.OffDay_Supplier_Mappings.ToList();
            }
        }

        // Update
        public static void Update(OffDay_Supplier_Mapping model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.OffDay_Supplier_Mappings.SingleOrDefault(s => s.ID == model.ID);
                if (canUpdate != null)
                {
                    canUpdate.OffDayID = model.OffDayID;
                    canUpdate.SupplierID = model.SupplierID;
                    db.SaveChanges();
                }
            }
        }

        // Delete
        public static void Delete(int ID)
        {
            using (var db = new MouldEntities())
            {
                var canDelete = db.OffDay_Supplier_Mappings.SingleOrDefault(s => s.ID == ID);
                if (canDelete != null)
                {
                    db.OffDay_Supplier_Mappings.Remove(canDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
