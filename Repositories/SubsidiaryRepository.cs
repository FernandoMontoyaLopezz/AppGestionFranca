using AppGestionFranca.Models;
using AppGestionFranca.Repositories.Interfaces;

namespace  AppGestionFranca.Repositories
{
    public class SubsidiaryRepository : Repository<Subsidiary>, ISubsidiaryRepository
    {
        private readonly DBContext context;

        public SubsidiaryRepository(DBContext context): base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var subsidiary = await GetByIdAsync(id);

            if (subsidiary == null) throw new Exception("The entity is null.");

            context.Subsidiaries.Remove(subsidiary);
            await context.SaveChangesAsync();

        }
    }
}
