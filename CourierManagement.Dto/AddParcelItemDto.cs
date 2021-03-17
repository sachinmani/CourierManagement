using System;
using CourierManagement.RequestModels;

namespace CourierManagement.Dto
{
    public class AddParcelItemDto
    {
        public Guid SessionId { get; set; }

        public string ItemName { get; set; }

        public double Length { get; set; }

        public double Breadth { get; set; }

        public double Width { get; set; }

        public string Address { get; set; }

        public decimal ExcessInKg { get; private set; }

        public static AddParcelItemDto FromRequestModel(AddParcelItemRequest addParcelItemRequest)
        {
            return new AddParcelItemDto
            {
                SessionId = addParcelItemRequest.SessionId,
                ItemName = addParcelItemRequest.ItemName,
                Address = addParcelItemRequest.Address,
                Breadth = addParcelItemRequest.Breadth,
                Length = addParcelItemRequest.Length,
                Width = addParcelItemRequest.Width
            };
        }

        public void UpdateExcessKg(decimal excess)
        {
            ExcessInKg = excess;
        }
    }
}
