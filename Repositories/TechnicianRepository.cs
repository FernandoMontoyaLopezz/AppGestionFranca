
using AppGestionFranca.Models;
using AppGestionFranca.Repositories.Interfaces;


namespace  AppGestionFranca.Repositories
{
    public class TechnicianRepository : Repository<Technician>, ITechnicianRepository
    {
        private readonly DBContext context;

        public TechnicianRepository(DBContext context): base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var technician = await GetByIdAsync(id);

            if (technician == null) throw new Exception("The entity is null.");

            context.Technicians.Remove(technician);
            await context.SaveChangesAsync();

        }
    }
}
