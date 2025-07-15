using Newtonsoft.Json;

namespace WebPlupload.Models
{
    public class DBDProfileV7ResponseStatus
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class DBDProfileResponseV7
    {
        public DBDProfileV7ResponseStatus status { get; set; }

        public object data { get; set; }
    }

    public class DBDProfileV7Juristic
    {
        //public DBDProfileV7Juristic()
        //{
        //    OrganizationJuristicPerson = new DBDProfileV7JuristicPerson();
        //}

        [JsonProperty("cd:OrganizationJuristicPerson")]
        //  [JsonPropertyName("cd:OrganizationJuristicPerson")]

        public DBDProfileV7JuristicPerson JuristicPerson { get; set; }
    }

    public class DBDProfileV7JuristicPerson
    {
        [JsonProperty("cd:OrganizationJuristicID")]
        //[JsonPropertyName("cd:OrganizationJuristicID")]
        public string JuristicID { get; set; }

        [JsonProperty("cd:OrganizationOldJuristicID")]
        public string OldJuristicID { get; set; }

        [JsonProperty("cd:OrganizationJuristicNameTH")]
        public string JuristicNameTH { get; set; }


        [JsonProperty("cd:OrganizationJuristicNameEN")]
        public string JuristicNameEN { get; set; }


        [JsonProperty("cd:OrganizationJuristicType")]
        public string JuristicType { get; set; }


        [JsonProperty("cd:OrganizationJuristicRegisterDate")]
        public string JuristicRegisterDate { get; set; }


        [JsonProperty("cd:OrganizationJuristicStatus")]
        public string JuristicStatus { get; set; }



        [JsonProperty("cd:OrganizationJuristicObjective")]
        public List<JuristicObjective> JuristicObjectives { get; set; }


        [JsonProperty("cd:OrganizationJuristicObjectiveItems")]
        public string ObjectiveItems { get; set; }


        [JsonProperty("cd:OrganizationJuristicObjectivePages")]
        public string ObjectivePages { get; set; }


        [JsonProperty("cd:OrganizationJuristicPersonTelephone")]
        public string JuristicPersonTelephone { get; set; }


        [JsonProperty("cd:OrganizationJuristicRegisterCapital")]
        public string RegisterCapital { get; set; }


        [JsonProperty("cd:OrganizationJuristicPaidUpCapital")]
        public string PaidUpCapital { get; set; }


        [JsonProperty("cd:OrganizationJuristicPersonList")]
        public List<JuristicPersonList> JuristicPersons { get; set; }


        [JsonProperty("cd:OrganizationJuristicBranchName")]
        public string JuristicBranchName { get; set; }


        [JsonProperty("cd:OrganizationJuristicAddress")]
        public JuristicAddress Address { get; set; }


        [JsonProperty("cd:OrganizationJuristicPersonDescription")]
        public List<PersonDescription> PersonDescriptions { get; set; }

    }

    public class PersonDescription
    {
        [JsonProperty("cd:OrganizationJuristicPersonDescriptionSequence")]
        public string DescriptionSequence { get; set; }

        [JsonProperty("cd:OrganizationJuristicPersonDescriptionType")]
        public string DescriptionType { get; set; }

        [JsonProperty("cd:OrganizationJuristicPersonDescriptionDetail")]
        public string DescriptionDetail { get; set; }

    }

    public class JuristicObjective
    {
        [JsonProperty("td:JuristicObjective")]
        public string Objective { get; set; }

        [JsonProperty("td:JuristicObjectiveCode")]
        public string ObjectiveCode { get; set; }

        [JsonProperty("td:JuristicObjectiveTextTH")]
        public string ObjectiveTextTH { get; set; }

        [JsonProperty("td:JuristicObjectiveTextEN")]
        public string ObjectiveTextEN { get; set; }



    }

    public class JuristicPersonList
    {
        public JuristicPersonList()
        {
            Person = new JuristicPerson();
        }
        [JsonProperty("td:JuristicPersonSequence")]
        public int PersonSequence { get; set; }

        [JsonProperty("td:JuristicPersonType")]
        public string PersonType { get; set; }

        [JsonProperty("td:JuristicPerson")]
        public JuristicPerson Person { get; set; }


        [JsonProperty("td:JuristicPersonInvestType")]
        public string PersonInvestType { get; set; }


        [JsonProperty("td:JuristicPersonInvestAmount")]
        public string PersonInvestAmount { get; set; }

    }

    public class JuristicPerson
    {
        public JuristicPerson()
        {
            PersonName = new JuristicPersonName();
        }

        [JsonProperty("cd:PersonBirthDate")]
        public string PersonBirthDate { get; set; }

        [JsonProperty("cd:PersonID")]
        public string PersonID { get; set; }

        [JsonProperty("cd:PersonIDType")]
        public string PersonIDType { get; set; }

        [JsonProperty("cd:PersonNameTH")]
        public JuristicPersonName PersonName { get; set; }

    }
    public class JuristicPersonName
    {

        [JsonProperty("cd:PersonNameTitleTextTH")]
        public string TitleTextTH { get; set; }

        [JsonProperty("cd:PersonFirstNameTH")]
        public string FirstNameTH { get; set; }

        [JsonProperty("cd:PersonMiddleNameTH")]
        public string MiddleNameTH { get; set; }

        [JsonProperty("cd:PersonLastNameTH")]
        public string LastNameTH { get; set; }

    }


    public class JuristicAddress
    {
        public JuristicAddress()
        {
            AddressDetail = new AddressType();
        }

        [JsonProperty("cr:AddressType")]
        public AddressType AddressDetail { get; set; }
    }

    public class AddressType
    {
        public AddressType()
        {
            SubDivision = new CitySubDivision();
            Division = new City();
            Province = new CountrySubDivision();

        }
        [JsonProperty("cd:Address")]
        public string Address { get; set; }

        [JsonProperty("cd:Building")]
        public string Building { get; set; }

        [JsonProperty("cd:RoomNo")]
        public string RoomNo { get; set; }

        [JsonProperty("cd:Floor")]
        public string Floor { get; set; }

        [JsonProperty("cd:AddressNo")]
        public string AddressNo { get; set; }

        [JsonProperty("cd:Moo")]
        public string Moo { get; set; }

        [JsonProperty("cd:Yaek")]
        public string Yaek { get; set; }

        [JsonProperty("cd:Soi")]
        public string Soi { get; set; }

        [JsonProperty("cd:Trok")]
        public string Trok { get; set; }

        [JsonProperty("cd:Village")]
        public string Village { get; set; }

        [JsonProperty("cd:Road")]
        public string Road { get; set; }

        [JsonProperty("cd:CitySubDivision")]
        public CitySubDivision SubDivision { get; set; }

        [JsonProperty("cd:City")]
        public City Division { get; set; }

        [JsonProperty("cd:CountrySubDivision")]
        public CountrySubDivision Province { get; set; }


    }

    public class CitySubDivision
    {
        [JsonProperty("cr:CitySubDivisionCode")]
        public string SubDivisionCode { get; set; }

        [JsonProperty("cr:CitySubDivisionTextTH")]
        public string SubDivisionTextTH { get; set; }


    }

    public class City
    {
        [JsonProperty("cr:CityCode")]
        public string DivisionCode { get; set; }

        [JsonProperty("cr:CityTextTH")]
        public string DivisionTextTH { get; set; }
    }

    public class CountrySubDivision
    {
        [JsonProperty("cr:CountrySubDivisionCode")]
        public string ProvinceCode { get; set; }

        [JsonProperty("cr:CountrySubDivisionTextTH")]
        public string ProvinceTextTH { get; set; }
    }

}
