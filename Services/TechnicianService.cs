using AppGestionFranca.Models;

namespace AppGestionFranca.Services
{
    public class TechnicianService
    {

        public int GetNextId()
        {

            DBContext context = new DBContext();
            int result = context.Technicians.Count() > 0 ? context.Technicians.Max(p => p.TechnicianId) : 0;

            return ++result;
        }
    }
}
