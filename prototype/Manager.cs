namespace prototype;

public class Manager
{
   private Dictionary<string,Product> showcase = new Dictionary<string, Product>();

   public void register(string name, Product proto)
   {
      showcase[name] = proto;
   }

   public Product create(string name)
   {
      Product p = (Product)showcase[name];
      return p.createClone();
   }
}