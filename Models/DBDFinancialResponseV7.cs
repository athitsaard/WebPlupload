using Newtonsoft.Json;

namespace WebPlupload.Models
{

    public class DBDFinancailV7ResponseStatus
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class DBDFinancialResponseV7
    {
        public DBDFinancailV7ResponseStatus status { get; set; }

        public object data { get; set; }
    }

    public class DBDFinancailV7Juristic
    {
        public DBDFinancailV7Juristic()
        {
            JuristicFinancialInfo = new JuristicFinancailV7Info();
        }

        [JsonProperty("td:JuristicFinancial")]
        public JuristicFinancailV7Info JuristicFinancialInfo { get; set; }




        [JsonProperty("td:JuristicAccountingPeriod")]

        public string AccountingPeriod { get; set; }

        [JsonProperty("td:SubmissionDate")]

        public string SubmissionDate { get; set; }

        [JsonProperty("td:JuristicObjectiveCode1")]

        public string ObjectiveCode1 { get; set; }


        [JsonProperty("td:JuristicObjectiveTextTH1")]
        public string ObjectiveTextTH1 { get; set; }

        [JsonProperty("td:TotalIncomePercentage1")]
        public string TotalIncomePercentage1 { get; set; }

        [JsonProperty("td:JuristicObjectiveCode2")]
        public string JuristicObjectiveCode2 { get; set; }

        [JsonProperty("td:JuristicObjectiveTextTH2")]
        public string ObjectiveTextTH2 { get; set; }

        [JsonProperty("td:TotalIncomePercentage2")]
        public string TotalIncomePercentage2 { get; set; }


        [JsonProperty("td:DateOfExpressingOpinions")]
        public string DateOfExpressingOpinions { get; set; }


        [JsonProperty("td:ExpressingOpinions")]
        public string ExpressingOpinions { get; set; }


        [JsonProperty("td:JuristicShareholderEquity")]
        public double? ShareholderEquity { get; set; }


        [JsonProperty("td:JuristicTotalAsset")]
        public double? TotalAsset { get; set; }



        [JsonProperty("td:JuristicTotalCurrentAsset")]
        public double? TotalCurrentAsset { get; set; }


        [JsonProperty("td:JuristicTotalLiabilities")]
        public double? TotalLiabilities { get; set; }


        [JsonProperty("td:JuristicAdminExpenses")]
        public double? AdminExpenses { get; set; }


        [JsonProperty("td:JuristicCostOfGoodsSold")]
        public double? CostOfGoodsSold { get; set; }


        [JsonProperty("td:JuristicEarningPerShare")]

        public double? EarningPerShare { get; set; }


        [JsonProperty("td:JuristicIncomeTax")]
        public double? IncomeTax { get; set; }


        [JsonProperty("td:JuristicInterestExpenses")]
        public double? InterestExpenses { get; set; }


        [JsonProperty("td:JuristicNetProfit")]

        public double? NetProfit { get; set; }


        [JsonProperty("td:JuristicSaleRevenue")]
        public double? SaleRevenue { get; set; }


        [JsonProperty("td:JuristicTotalRevenue")]
        public double? TotalRevenue { get; set; }


        [JsonProperty("td:JuristicStatementYear")]

        public string StatementYear { get; set; }



        [JsonProperty("td:JuristicRegisterCapital")]

        public double? RegisterCapital { get; set; }



        [JsonProperty("td:JuristicAccountReceivable")]
        public double? AccountReceivable { get; set; }



        [JsonProperty("td:JuristicCurrentLiabilities")]
        public double? CurrentLiabilities { get; set; }


        [JsonProperty("td:JuristicInventory")]
        public double? Inventory { get; set; }


        [JsonProperty("td:JuristicPaidUpCapital")]

        public double? PaidUpCapital { get; set; }

        [JsonProperty("td:JuristicProperTREquipment")]

        public double? ProperTREquipment { get; set; }


    }

    public class JuristicFinancailV7Info
    {

        public JuristicFinancailV7Info()
        {
            OrgJuristic = new OrganizationJuristic();
        }


        [JsonProperty("td:JuristicID")]
        public OrganizationJuristic OrgJuristic { get; set; }

    }

    public class OrganizationJuristic
    {
        public OrganizationJuristic()
        {
            JuristicPerson = new OrganizationJuristicPerson();
        }



        [JsonProperty("cd:OrganizationJuristicPerson")]
        public OrganizationJuristicPerson JuristicPerson { get; set; }       

    }

    public class OrganizationJuristicPerson
    {


        [JsonProperty("cd:OrganizationJuristicID")]
        public string JuristicID { get; set; }


        [JsonProperty("cd:OrganizationJuristicNameTH")]
        public string JuristicNameTH { get; set; }



        [JsonProperty("cd:OrganizationJuristicType")]

        public string JuristicType { get; set; }


    }

}
