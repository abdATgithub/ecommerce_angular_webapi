using System.Runtime.Serialization;

namespace Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,

        [EnumMember(Value = "PAYMENT RECEIVED")]
        PAYMENT_RECEIVED,

        [EnumMember(Value = "PAYMENT FAILED")]
        PAYMENT_FAILED
    }
}