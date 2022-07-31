using MM.GeekShopping.Email.Messages;
using System.Threading.Tasks;

namespace MM.GeekShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
