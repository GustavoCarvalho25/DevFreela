using DevFreela.Core.DTOs;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
