using AppGestionFranca.Models;

namespace AppGestionFranca.Services
{
    public class SubsidiaryService
    {

        public List<Subsidiary> GetSubsidiaries()
        {

            DBContext context = new DBContext();
            

            var result = context.Subsidiaries.ToList();


            return result;
        }
    }
}
