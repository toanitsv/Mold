using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoldCalculator.Models;

namespace MoldCalculator.Controllers
{
    public class MoldController
    {
        public static List<Mold> Select ()
        {
            using (var db = new MouldEntities())
            {
                return db.Molds.ToList();
            }
        }
    }
}
