using System.Threading.Tasks;

namespace Northwind.Ordering.Api.Services
{
    public interface ISMSService
    {
        Task Send(string phoneNumber, string message);
    }
}
