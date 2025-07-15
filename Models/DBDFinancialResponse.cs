namespace WebPlupload.Models
{
    public class DBDFinancialResponse
    {
        public List<DBDFinancial> ResultList { get; set; }

        public string Message { get; set; }

        public DBDFinancial GetDBDFinancial()
        {
            if (ResultList != null)
            {
                return ResultList.FirstOrDefault();
            }

            return null;
        }


        public class DBDFinancial
        {
            public string JuristicID { get; set; }
            public string RegisterCapital { get; set; }
            public string AccountReceivable { get; set; }
            public string CurrentLiabilities { get; set; }
            public string Inventory { get; set; }
            public string PaidUpCapital { get; set; }
            public string ProperTREquipment { get; set; }
            public string ShareholderEquity { get; set; }
            public string TotalAsset { get; set; }
            public string TotalCurrentAsset { get; set; }
            public string TotalLiabilities { get; set; }
            public string AdminExpenses { get; set; }
            public string CostOfGoodsSold { get; set; }
            public string EarningPerShare { get; set; }
            public string IncomeTax { get; set; }
            public string InterestExpenses { get; set; }
            public string NetProfit { get; set; }
            public string SaleRevenue { get; set; }
            public string TotalRevenue { get; set; }
            public string StatementYear { get; set; }
        }

    }
}
