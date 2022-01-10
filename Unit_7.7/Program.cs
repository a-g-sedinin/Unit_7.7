#region Unit 7.7
class Recipient
{
    public int Id;
    public string Name;
    public string Company;
    public int INN;
    public long PhoneNum;
    public string Address;
    public Recipient(int id, string name, string company, int inn, long phone, string address)
    {
        Id = id;
        Name = name;
        Company = company;
        INN = inn;
        Address = address;
        PhoneNum = phone;

    }
    public Recipient(int id, string name, long phone, string address)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNum = phone;

    }
}
class TransportUnit
{
    public string Type;
    public string Brand;
    public int TotalMileage;
    public double FuelConsumption;
    public bool IsOnDuty;
    public int MaxWeigt;
    public double MaxVolume;
    public double MinRate;
}
class Garage
{
    private TransportUnit transportUnit;
    public Garage(TransportUnit transportUnit)
    {
        this.transportUnit = transportUnit;
    }
}

class Courier
{
    private string _name = "";
    private byte _age = 0;
    private long _phone = 0;
    private string _driverLicenceCat = "";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public byte Age
    {
        get { return _age; }
        set
        {
            if (value <= 16) { Console.WriteLine("Age must be greater than 16"); }
            else { _age = value; }
        }
    }
    public long Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    public string DriverLicenceCat
    {
        get { return _driverLicenceCat; }
        set
        {
            if (value != "") _driverLicenceCat = value;
            else { Console.WriteLine("Courier must have a driver licince."); }
        }
    }
    public void DisplayInfo()
    {
        Console.WriteLine(Name, " ", Age, " ", DriverLicenceCat);
    }
}
class Package
{
    public int RecipientID;
    public double Weight;
    public double Volume;
}
class PackagesCollection
{
    private Package[] packages;
    public PackagesCollection(Package[] packages)
    {
        this.packages = packages;
    }
    public Package this[int index]
    {
        get
        {
            if (index >= 0 && index < packages.Length)
            {
                return packages[index];
            }
            return null;
        }
        private set
        {
            if (index > -1 && index < packages.Length)
            {
                packages[index] = value;
            }
        }

    }
}
abstract class Delivery
{
    public string Address;
    public string DeliveryDate;
    public string DeliveryTime;
}
class HomeDelivery : Delivery
{
    public int Entrance;
    public int Floor;
    public string Courier;
    public bool IsLift;
    public double DeliveryPrice;
    static readonly double MinRate = 200;
    public HomeDelivery(string courier, bool islift, int floor)
    {
        Courier = courier;
        if (islift) DeliveryPrice = MinRate;
        else DeliveryPrice = MinRate * floor;
    }

}
class Logistics<TTransportUnit> where TTransportUnit : TransportUnit
{
    public TTransportUnit TransportUnit;
    public double Weight;
    public double Volume;
    public double Mileage;
    public double Price;
    public Logistics(double weight, double volume, double Mileage)
    {
        if ((weight <= TransportUnit.MaxVolume) && (volume <= TransportUnit.MaxVolume) && !TransportUnit.IsOnDuty)
        {
            Price = Mileage * TransportUnit.MinRate;

        }
        else
        {
            Price = 0.0;
            Console.WriteLine("Special terms of delivery");
        }
    }
}

class PickPointDelivery : Delivery
{
    public double DeliveryPrice;
    public new string DeliveryTime = "";
    public static int StorageDays = 3;
    public PickPointDelivery()
    {
        NearestPickPoint(Address);
    }
    protected void NearestPickPoint(string address)
    {
        Address = address;
    }
}
class ShopDelivery : Delivery
{
    public static int StorageDays = 14;
    public new static string DeliveryTime = "";
    public new static string Address = "ShopAddress";
    public ShopDelivery()
    {
    }
}
class Order<TDelivery, TRecipient, TLogistics> where TDelivery : Delivery
    where TRecipient : Recipient where TLogistics : Logistics<TransportUnit>
{
    public TDelivery Delivery;
    public TRecipient Recipient;
    public TLogistics Logistics;
    public void DisplayInfo()
    {
        Console.WriteLine("\n", Delivery.Address, "\n", Delivery.DeliveryDate,
                          "\n", Delivery.DeliveryTime, "\n", Logistics.TransportUnit.Brand);

        Console.WriteLine("\n", Recipient.Name);
    }

}

#endregion
