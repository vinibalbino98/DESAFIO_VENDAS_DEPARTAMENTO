using System;
using System.Collections.Generic;
using System.Globalization;

namespace DesafioVendas {
    class Program {
        static void Main(string[] args) {
            List<string> sales = new List<string>
            {
                "8349,14/09/2024,899.9,ESPORTE",
                "4837,17/09/2024,530.0,VESTUARIO",
                "15281,21/09/2024,1253.99,ESPORTE",
                "15344,27/09/2024,1000.9,VESTUARIO",
                "18317,04/10/2024,250.4,VESTUARIO",
                "18972,11/10/2024,385.5,JARDINAGEM"
            };

            string department = "VESTUARIO";

            double[] result = TotalSales(sales, department);

            Console.WriteLine($"{(int)result[0]} VENDAS");
            Console.WriteLine($"TOTAL = $ {result[1].ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public static double[] TotalSales(List<string> sales, string department) {
            return TotalSalesRecursive(sales, department, 0, 0, 0);
        }

        private static double[] TotalSalesRecursive(List<string> sales, string department, int index, int count, double total) {
            if(index == sales.Count) {
                return new double[] { count, total };
            }

            string[] parts = sales[index].Split(',');

            string saleDepartment = parts[3];
            double price = double.Parse(parts[2], CultureInfo.InvariantCulture);

            if(saleDepartment.Equals(department, StringComparison.OrdinalIgnoreCase)) {
                count++;
                total += price;
            }

            return TotalSalesRecursive(sales, department, index + 1, count, total);
        }
    }
}
