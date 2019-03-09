using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class ComponentController
    {
        // Create
        public static void Insert(ComponentShoe model)
        {
            using (var db = new MouldEntities())
            {
                var canInsert = db.ComponentShoes.SingleOrDefault(s => s.ComponentID == model.ComponentID && s.ComponentName.Equals(model.ComponentName));
                if (canInsert == null)
                {
                    db.ComponentShoes.Add(model);
                    db.SaveChanges();
                }
            }
        }

        // Read
        public static List<ComponentShoe> Select()
        {
            using (var db = new MouldEntities())
            {
                return db.ComponentShoes.ToList();
            }
        }

        // Update
        public static void Update(ComponentShoe model)
        {
            using (var db = new MouldEntities())
            {
                var canUpdate = db.ComponentShoes.SingleOrDefault(s => s.ComponentID == model.ComponentID);
                if (canUpdate != null)
                {
                    canUpdate.ComponentName = model.ComponentName;
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
                var canDelete = db.ComponentShoes.SingleOrDefault(s => s.ComponentID == ID);
                if (canDelete != null)
                {
                    db.ComponentShoes.Remove(canDelete);
                    db.SaveChanges();
                }
            }
        }

    }
}
