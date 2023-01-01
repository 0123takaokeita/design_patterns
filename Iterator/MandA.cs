using System.Data.Common;

namespace Iterator;

public interface IIterator
{
    public abstract bool hasNext();
    public abstract object next();
}

public interface IAgregate
{
    public abstract IIterator iterator();

}
    
public class CompanyListIterator : IIterator
{
    private CompanyList companyList;
    private int index;

    public CompanyListIterator(CompanyList companyList)
    {
        this.companyList = companyList;
        this.index = 0;
    }

    public bool hasNext()
    {
        return index < companyList.getLength();
    }

    public object next()
    {
        Company company = companyList.getCompanyAt(index);
        index++;
        return company;
    }

}

public class Company
{
    private string name { get; }

    public Company(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }
}

public class CompanyList : IAgregate
{
    private Company[] companyList { get; }
    private int last { get; set; } = 0;

    public CompanyList(int max)
    {
        companyList = new Company[max];
    }

    public Company getCompanyAt(int index)
    {
        return companyList[index];
    }

    public void appendCompany(Company company)
    {
        companyList[last] = company;
        last++;
    }

    public int getLength()
    {
        return last;
    }

    public IIterator iterator()
    {
        return new CompanyListIterator(this);
    }
}