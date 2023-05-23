namespace ContosoCrafts.WebSite.Models
{
    public enum ProductTypeEnum
    {
        Undefined = 0,
        Fish = 1,
        Other = 5,
        Cat = 130,
        Dog = 55,
    }

    public static class ProductTypeEnumExtensions
    {
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Fish => "Small Freshwater, Large Saltwater",
                ProductTypeEnum.Other => "Other Pets",
                ProductTypeEnum.Cat => "Cats",
                ProductTypeEnum.Dog => "Dogs",

                // Default, Unknown
                _ => "",
            };
        }
    }

}
