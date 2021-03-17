using System;

namespace CourierManagement.RequestModels
{
    public class AddParcelItemRequest
    {
        public Guid SessionId { get; set; }

        public string ItemName { get; set; }

        public double Length { get; set; }

        public double Breadth { get; set; }

        public double Width { get; set; }

        public string Address { get; set; }
    }
}
