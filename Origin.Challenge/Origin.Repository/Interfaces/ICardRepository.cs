using Origin.Model;

namespace Origin.Repository.Interfaces
{
    public interface ICardRepository : Core.Abstractions.IRepository<Card>
    {
        void ChangeStatus(Card entity, Model.Enum.Status Status);
    }
}
