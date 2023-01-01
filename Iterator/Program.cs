namespace Iterator;

public class Program
{
    static void Main()
    {
        CompanyList companyList = new CompanyList(4);
        companyList.appendCompany(new Company("takao"));
        companyList.appendCompany(new Company("tko"));
        companyList.appendCompany(new Company("kit"));
        companyList.appendCompany(new Company("leave"));

        IIterator itr = companyList.iterator();
        while (itr.hasNext())
        {
            Company com = (Company)itr.next();
            Console.WriteLine(com.getName());
        }
    }
}