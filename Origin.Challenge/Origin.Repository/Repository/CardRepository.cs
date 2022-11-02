using Origin.DatabaseContext;
using Origin.Model;
using Origin.Model.Enum;

namespace Origin.Repository
{
    public class CardRepository : Repository<Card>, Interfaces.ICardRepository
    {
        public CardRepository(OriginDbContext ctx) : base(ctx)
        {
        }

        public void ChangeStatus(Card entity, Model.Enum.Status Status)
        {
            entity.DateUpdated= DateTime.Now;
            entity.Status = Status;

            this.Update(entity);
        }

        public void ChangeStatus(Card entity, Model.Enum.Status Status, string description)
        {
            Movement mov = new();
            mov.Description = description;

            entity.Movements.Add(mov);

            ChangeStatus(entity, Status);
        }

        public void ChangeStatus(Card entity, string description, double withDraw = 0)
        {
            Movement mov = new();
            mov.Description = description;
            mov.WithdrawAmount = - withDraw;

            entity.Movements.Add(mov);

            if(entity.Balance == 0 )


            this.Update(entity);
        }
    }
}


