namespace prototype;

public class Manager
{
   private HashMap showcase = new HashMap();

   public void register(string name, Product proto)
   {
      showcase.put(name, proto);
   }

   public Product create(string protoname)
   {
      Product p = (Product)showcase.get(protoname);
      return p.createClone();
   }
}