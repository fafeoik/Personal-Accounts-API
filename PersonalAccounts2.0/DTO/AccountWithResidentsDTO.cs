namespace PersonalAccounts2._0.DTO
{
    public class AccountWithResidentsDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Address { get; set; }
        public decimal RoomArea { get; set; }
        public List<ResidentDTO> Residents { get; set; }
    }
}
