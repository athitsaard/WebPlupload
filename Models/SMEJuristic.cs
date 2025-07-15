namespace WebPlupload.Models
{
    public abstract class BaseSMEProfile
    {
        public string Id { get; set; }
        public string Document { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public DateTimeOffset? Expired { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset? Replicated { get; set; }
        public DateTimeOffset? Founded { get; set; }
        public DateTimeOffset? Issued { get; set; }
        public DateTimeOffset? Approved { get; set; }
        public List<Business> Business { get; set; }
        public Operator Operator { get; set; }
    }
    public class Business
    {
        public string Code { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Size { get; set; }
        public string Established { get; set; }
        public string Sector { get; set; }
        public string Category { get; set; }
        public string CategoryDescription { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }
        public string Created { get; set; }
        public string Approved { get; set; }
        public SMEAddress Address { get; set; }
    }

    public class Operator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notifier { get; set; }

    }

    public class SMEAddress
    {
        public string Room { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string Village { get; set; }
        public string No { get; set; }
        public string Moo { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string PhoneExtension { get; set; }
        public string Fax { get; set; }
        public string FaxExtension { get; set; }
        public string Email { get; set; }

    }
    public class SMEJuristic: BaseSMEProfile
    {
        public JursticProfile Profile { get; set; }
    }

    public class JursticProfile
    {
        public string Type { get; set; }
        public string NameThai { get; set; }
        public string NameEnglish { get; set; }
        public string Registered { get; set; }
        public string StandardId { get; set; }
        public string StandardDescription { get; set; }
        public string BusinessDetail { get; set; }
        public bool OSSRecommendation { get; set; }
        public string Size { get; set; }
        public SMEAddress Address { get; set; }
        public List<Committee> Committee { get; set; }
        public List<Authorized> Authorized { get; set; }
        public List<Financial> Financial { get; set; }
    }


    public class Committee
    {
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Authorized
    {
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
    public class Financial
    {
        public int Year { get; set; }
        public double? Value { get; set; }
    }
}
