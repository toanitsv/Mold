using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class SizeRunController
    {
        // Create
        public static void Insert (SizeRun model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.SizeRuns.SingleOrDefault(w => w.OutsoleCode == model.OutsoleCode && w.SizeNo == model.SizeNo);
                if (canInsert == null)
                {
                    db.SizeRuns.Add(model);
                    db.SaveChanges();
                }
                else
                {
                    canInsert.Quantity = model.Quantity;
                    canInsert.ModifiedTiime = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
        // Read
        public static List<SizeRun> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.SizeRuns.ToList();
            }
        }
        // Update
        public static void Update(SizeRun model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.SizeRuns.SingleOrDefault(w => w.OutsoleCode == model.OutsoleCode && w.SizeNo == w.SizeNo);
                if (canUpdate != null)
                {
                    canUpdate.Quantity = model.Quantity;
                    db.SaveChanges();
                }
            }
        }
        // Delete
        public static void Delete(SizeRun model)
        {
            using (var db = new MouldEntities())
            {
                var canDelete = db.SizeRuns.SingleOrDefault(s => s.OutsoleCode == model.OutsoleCode && s.SizeNo == model.SizeNo);
                if (canDelete != null)
                {
                    db.SizeRuns.Remove(canDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
