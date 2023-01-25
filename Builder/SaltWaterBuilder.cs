namespace Builder;

public class SaltWaterBuilder : Builder
{
    private SaltWater saltWater;

    public SaltWaterBuilder()
    {
        this.saltWater = new SaltWater(0,0);
    }
    
    public void addSolute(decimal saltAmount)
    {
        saltWater.salt += saltAmount;
    }

    public void addSolvent(decimal waterAmount)
    {
        saltWater.water += waterAmount;
    }

    public void abandonSolution(decimal saltWaterAmount)
    {
        decimal saltDelta = saltWaterAmount * (saltWater.salt / (saltWater.salt + saltWater.water));
        decimal waterDelta = saltWaterAmount * (saltWater.water / (saltWater.salt + saltWater.water));
        saltWater.salt -= saltDelta;
        saltWater.water -= waterDelta;
    }

    public object getResult()
    {
        return this.saltWater;
    }
}