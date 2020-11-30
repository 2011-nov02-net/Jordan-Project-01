using System;

namespace StoreApp.DataAccess.BusinessModels
{
    public interface IOrder
    {
        int CustomerId { get; set; }
        int StoreId { get; set; }
        int TransactionNumber { get; set; }
        DateTime? TransactionTime { get; set; }
    }
}