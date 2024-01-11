using  AppGestionFranca.Models;
using AppGestionFranca.Repositories.Interfaces;

namespace  AppGestionFranca.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly DBContext context;

        public ItemRepository(DBContext context): base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);

            if (item == null) throw new Exception("The entity is null.");

            context.Items.Remove(item);
            await context.SaveChangesAsync();

        }
    }
}
