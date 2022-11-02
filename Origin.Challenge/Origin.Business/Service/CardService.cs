using Origin.Business.Interfaces;
using Core.Abstractions;
using Core.Framework;
using Origin.Model;
using System.Linq.Expressions;
using Origin.Repository;
using Origin.Repository.Interfaces;

namespace Origin.Business.Service
{
    public class CardService : Service<Card>, ICardService //Repository<Card>, Interfaces.ICardRepository
    {
        private ICardRepository _cardRepository;
        private static int Strike = 0;

        public CardService(
       ICardRepository cardRepository
        )
            :base(cardRepository)
        {
            this._cardRepository = cardRepository;
        }

        public void ValidateCodeNumber(string code)
        {
            //Buscamos solamente la tarjeta para validar posteriormente el estado y condicion de la misma
            Card entity = _cardRepository.Find(
               x => x.CodeNumber == code
               && x.IsEnabled
               );

            MainValidations(entity);
        }

        public Card ValidatePIN(string code, string PIN)
        {
            //validamos nuevamente la tarjeta si por alguna razon externa o administrativa llegara a ser adulterada
            Card entity = GetValidCard(code, PIN);

            string message = string.Empty;

            if (entity.Pin != PIN)
            {
                Strike++;
                message = Constants.CardMessages.INVALID_PIN;
            }

            if (Strike == Constants.CardValues.WARN)
                message = Constants.CardMessages.WARNING_ACCESS;

            if (Strike >= Constants.CardValues.LOCK)
            {
                //Bloqueamos la tarjeta si excede los intentos
                message = Constants.CardMessages.CARD_HASBEEN_LOCKED;
                LockCard(entity);
                Strike = 0;
            }

            if (!string.IsNullOrEmpty(message))
                throw new OriginException(message);

            return entity;
        }

        private void MainValidations(Card entity)
        {
            if (entity is null)
                throw new OriginException(Constants.CardMessages.ERROR_ACCESS + Constants.CardMessages.NONEXISTENT_CARD);

            if (entity.Status == Model.Enum.Status.LOCKED)
                throw new OriginException(Constants.CardMessages.ERROR_ACCESS + Constants.CardMessages.NO_ATTEMPS);

            if (Core.Framework.Common.IsMaxThan(entity.DueDate, DateTime.Now))
                throw new OriginException(Constants.CardMessages.ERROR_ACCESS + Constants.CardMessages.EXPIRED_CARD + Core.Framework.Common.ToString(entity.DueDate));
        }

        private void LockCard(Card entity)
        {
            AddMovement(entity, Constants.CardMessages.CARD_LOCKED);

            _cardRepository.ChangeStatus(entity, Model.Enum.Status.LOCKED);
        }

        public Card BalanceCard(string code, string PIN, out string message)
        {
            message = string.Empty;

            Card entity = GetValidCard(code, PIN);

            if (entity.Status == Model.Enum.Status.BALANCED)
            {
                message = Constants.CardMessages.WARNING_BALANCED;
                return entity;
            }

            entity.Balance = Constants.CardValues.BALANCE;

            AddMovement(entity, Constants.CardMessages.CARD_HASBEEN_BALANCED);

            _cardRepository.ChangeStatus(entity, Model.Enum.Status.BALANCED);
            
            return entity;
        }

        private Card GetValidCard(string code, string PIN, bool validateBalance = false)
        {
            Card entity = _cardRepository.Find(
                x => x.CodeNumber == code
                && x.Pin == PIN
                && x.IsEnabled
                , p=> p.Owner
                );

            MainValidations(entity);

            if (validateBalance && entity.Status == Model.Enum.Status.UNBALANCED)
                throw new OriginException(Constants.CardMessages.ERROR_ACCESS + Constants.CardMessages.UNBALANCED_CARD);

            return entity;
        }

        public void WithDraw(string code, string PIN , double withdraw)
        {
            Card entity = GetValidCard(code, PIN, true);

            if (entity.Balance < withdraw)
                throw new OriginException(Constants.CardMessages.INSUFICIENT_FUNDS);

            entity.Balance -= withdraw;

            AddMovement(entity, Constants.CardMessages.CARD_WITHDRAW, withdraw);

            if (entity.Balance == Constants.CardValues.EMPTY_BALANCE)
            {
                entity.Status = Model.Enum.Status.UNSUFICIENT_BALANCE;
                AddMovement(entity, Constants.CardMessages.EMPTY_FUNDS);
            }

            _cardRepository.Update(entity);
        }

        public void AddMovement(Card entity, string message, double withdraw = 0) 
        {
            Movement mov = new();

            mov.Description = message;
            mov.RemainingBalance = entity.Balance;
            mov.WithdrawAmount = withdraw;

            entity.Movements.Add(mov);
        }
    }
}
