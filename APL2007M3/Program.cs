namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method
            report.GenerateSalesData();

            // call the QuarterlySalesReport method
            report.QuarterlySalesReport(report.GenerateSalesData());

        }


/* public struct SalesData. Include the following fields: date sold, department name, product ID, 
quantity sold, unit price */
        public struct SalesData
        {
            public DateOnly dateSold;
            public string departmentName;
            public int productID;
            public int quantitySold;
            public double unitPrice;
        }

/* the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field
 of the data structure */
        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random rnd = new Random();

            for (int i = 0; i < salesData.Length; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, rnd.Next(1, 13), rnd.Next(1, 29));
                salesData[i].departmentName = "Department " + rnd.Next(1, 11);
                salesData[i].productID = rnd.Next(1, 101);
                salesData[i].quantitySold = rnd.Next(1, 101);
                salesData[i].unitPrice = Math.Round(rnd.NextDouble() * 100, 2);
            }

            return salesData;
        }

/* the QuarterlySalesReport method takes an array of SalesData records as a parameter and generates a
 quarterly sales report. The method calculates the total sales and income for each quarter and displays
    the results on the console */
        public void QuarterlySalesReport(SalesData[] salesData)
        {
            double[] quarterlySales = new double[4];
            double[] quarterlyIncome = new double[4];

            for (int i = 0; i < salesData.Length; i++)
            {
                int quarter = (salesData[i].dateSold.Month - 1) / 3;
                quarterlySales[quarter] += salesData[i].quantitySold;
                quarterlyIncome[quarter] += salesData[i].quantitySold * salesData[i].unitPrice;
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Quarter " + (i + 1));
                Console.WriteLine("Total Sales: " + quarterlySales[i]);
                Console.WriteLine("Total Income: " + quarterlyIncome[i]);
                Console.WriteLine();
            }
        }
    }    
}