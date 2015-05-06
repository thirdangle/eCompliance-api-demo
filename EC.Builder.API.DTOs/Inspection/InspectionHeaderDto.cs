namespace EC.Builder.API.DTOs.Inspection
{
    public class InspectionHeaderDto
    {
        public string Client { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string GpsLocation { get; set; }
        public string Personnel { get; set; }
        public string PreparedBy { get; set; }
        public string OrganizationName { get; set; }
        public string AssetNumber { get; set; }
    }
}