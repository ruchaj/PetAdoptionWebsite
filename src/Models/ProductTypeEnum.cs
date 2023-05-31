namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// A datastructure to declare producttype .
    /// </summary>
    public enum ProductTypeEnum
    {
        Undefined = 0,
        Fish = 1,
        Other = 2,
        Cat = 3,
        Dog = 4,
    }

    public static class ProductTypeEnumExtensions
    {
        /// <summary>
        /// A class to display producttype .
        /// </summary>
        /// <param name="data"></param>
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
