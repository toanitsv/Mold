using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class OffDayController
    {
        // Create
        public static void Insert(OffDay model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.OffDays.Where(w => w.OffDate.Value.Year == model.OffDate.Value.Year
                                                   && w.OffDate.Value.Month == model.OffDate.Value.Month
                                                   && w.OffDate.Value.Day == model.OffDate.Value.Day).ToList();
                if (canInsert.Count() == 0)
                {
                    db.OffDays.Add(model);
                    db.SaveChanges();
                }
            }
        }

        // Read
        public static List<OffDay> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.OffDays.ToList();
            }
        }

        // Update
        public static void Update(OffDay model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.OffDays.SingleOrDefault(s => s.OffDayID == model.OffDayID);
                if (canUpdate != null)
                {
                    canUpdate.OffDate = model.OffDate;
                    canUpdate.Description = model.Description;
                    db.SaveChanges();
                }
            }
        }

        // Delete
        public static void Delete(int ID)
        {
            using (var db = new MouldEntities())
            {
                var canDelete = db.OffDays.SingleOrDefault(s => s.OffDayID == ID);
                if (canDelete != null)
                {
                    db.OffDays.Remove(canDelete);
                    db.SaveChanges();
                }

                var offDayMappingDeleteList = db.OffDay_Supplier_Mappings.Where(w => w.OffDayID == ID).ToList();
                foreach (var offDayMappingDelete in offDayMappingDeleteList)
                {
                    db.OffDay_Supplier_Mappings.Remove(offDayMappingDelete);
                    db.SaveChanges();
                }

            }
        }
    }
}
