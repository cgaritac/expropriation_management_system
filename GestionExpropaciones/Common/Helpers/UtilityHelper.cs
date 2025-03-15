namespace GestionExpropaciones.Common.Helpers;

public static class UtilityHelper
{
    public static (int StartPage, int EndPage) GetVisiblePages(int pageNumber, int totalPages)
    {
        int startPage = Math.Max(1, pageNumber - 1);
        int endPage = Math.Min(totalPages, startPage + 2);

        if (endPage - startPage < 2)
        {
            startPage = Math.Max(1, endPage - 2);
        }

        return (startPage, endPage);
    }
}
