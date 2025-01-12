namespace MVCVendasWeb.Models.Shared
{
    public class Helper
    {
        public static void ValidateSalesDates(DateTime startDate, DateTime tillDate)
        {
            if (startDate > tillDate)
                throw new InvalidOperationException("A data final nao pode ser menor que a data inicial.");
        }
    }
}
