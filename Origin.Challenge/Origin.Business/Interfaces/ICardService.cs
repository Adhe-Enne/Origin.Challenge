using Core.Abstractions;
using Core.Framework;
using Origin.Business.Service;

namespace Origin.Business.Interfaces
{
    public interface ICardService : IService<Model.Card>
    {
        void ValidateCodeNumber(string code);

        Model.Card ValidatePIN(string code, string PIN);

        Model.Card BalanceCard(string code, string PIN, out string message);

        void WithDraw(string code, string PIN, double withdraw);
        
    }
}
