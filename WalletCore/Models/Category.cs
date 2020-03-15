using System;
using System.Linq;
using System.Reflection;

namespace WalletCore.Models
{
  public class Category
  {
    public string Id { get; set; }
    public string Rev { get; set; }
    public string Color { get; set; }
    public bool CustomCategory { get; set; }
    public bool CustomName { get; set; }
    public RecordType DefaultType { get; set; }
    public string Desc { get; set; }
    public string EnvelopeId { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public long Position { get; set; }
    public Guid ReservedOwnerId { get; set; }
    public DateTime ReservedUpdatedAt { get; set; }
    public DateTime ReservedDeletedAt { get; set; }
    public Guid ReservedAuthorId { get; set; }
    public string ReservedModelType { get { return "Category"; } }
    public string ReservedSource { get; set; }
    public string ReservedDeletedSource { get; set; }
    public bool _deleted { get; set; }
  }

  public class StandardCategories
  {
    public static readonly string FOOD = "-Category_4ef882bf-0c6c-4274-a5d4-8a72706a06ad";
    public static readonly string FOOD__BAR = null;
    public static readonly string FOOD__GROCERIES = "-Category_06195a2a-ceb0-4b6c-a636-4076ab9f57e0";
    public static readonly string FOOD__RESTAURANT = "-Category_e80a51a0-a24f-4b96-ab5b-5491f68cff83";
    public static readonly string SHOPPING = "-Category_4b92d22a-7d23-4be9-b61e-c9bb1f7bdfcf";
    public static readonly string SHOPPING__CLOTHES = "-Category_f185132e-efe7-40c3-b9a0-073626a07413";
    public static readonly string SHOPPING__DRUGSTORE = "-Category_d0cbff8f-c482-4c34-938c-bbe302389cb0";
    public static readonly string SHOPPING__ELECTRONICS = "-Category_1c8d93ba-82ee-4cc7-8d6a-db7d54e84ee0";
    public static readonly string SHOPPING__FREE_TIME = "-Category_d373c2ac-da14-4992-b99a-c9af6148e7c7";
    public static readonly string SHOPPING__GIFTS = "-Category_7017c51d-38d4-4b00-a5c2-3dee2559eea0";
    public static readonly string SHOPPING__HEALTH_BEAUTY = "-Category_bd89f1f2-db3f-4489-b84e-d1138500d74f";
    public static readonly string SHOPPING__HOME_GARDEN = "-Category_31cd8654-be87-481f-90b6-8c1fd2b7e857";
    public static readonly string SHOPPING__JEWELS_ACCESSORIES = "-Category_60dbc5d3-030c-46ea-9491-309195dc27d3";
    public static readonly string SHOPPING__KIDS = null;
    public static readonly string SHOPPING__PETS_ANIMALS = "-Category_9b38c908-abcd-462f-8574-7ed59e13be28";
    public static readonly string SHOPPING__STATIONERY_TOOLS = "-Category_b7ecd3c2-3219-4753-b6d6-30ac16491841";
    public static readonly string HOUSING = null;
    public static readonly string HOUSING__ENERGY_UTILITIES = null;
    public static readonly string HOUSING__MAINTENANCE_REPAIRS = "-Category_1bb8be48-4f5b-46d1-b5ad-11cc10cd6af4";
    public static readonly string HOUSING__MORTGAGE = null;
    public static readonly string HOUSING__PROPERTY_INSURANCE = null;
    public static readonly string HOUSING__RENT = "-Category_3efd8691-144e-4c4e-b0ad-3ad0ad7448fc";
    public static readonly string HOUSING__SERVICES = "-Category_cd0db648-9891-4842-9cab-c1e5bed6d064";
    public static readonly string TRANSPORTATION = "-Category_adf628eb-0fbf-41cb-a22d-d28aff4a4388";
    public static readonly string TRANSPORTATION__BUSINESS_TRIPS = null;
    public static readonly string TRANSPORTATION__LONG_DISTANCE = "-Category_e71e5285-1f70-4063-820c-dd304971a5e5";
    public static readonly string TRANSPORTATION__PUBLIC_TRANSPORT = "-Category_0042a5b3-79b3-4455-a0a8-cd885066b6a4";
    public static readonly string TRANSPORTATION__TAXI = "-Category_fc204d93-ee58-4729-829a-4e9adc0afa07";
    public static readonly string VEHICLE = "-Category_a07833ed-410b-4600-a348-804f359b5eef";
    public static readonly string VEHICLE__FUEL = "-Category_fb3cc223-ba62-460a-93e2-548c3fd8818b";
    public static readonly string VEHICLE__LEASING = null;
    public static readonly string VEHICLE__PARKING = "-Category_0a99e144-158e-4921-a7fa-4258c1cef555";
    public static readonly string VEHICLE__RENTALS = null;
    public static readonly string VEHICLE__INSURANCE = null;
    public static readonly string VEHICLE__MAINTENANCE = "-Category_1d97245e-9226-401b-9d86-bc67fb1c9f63";
    public static readonly string LIFE = null;
    public static readonly string LIFE__ACTIVE_SPORT_FITNESS = "-Category_11061d4f-3822-4358-8740-c49a67caddcb";
    public static readonly string LIFE__ALCOHOL_TOBACCO = "-Category_1f6b3a55-93dd-499f-9146-0454826984d8";
    public static readonly string LIFE__BOOKS_AUDIO_SUBSCRIPTIONS = "-Category_48c51972-e350-431c-a2a4-78c90db9d42b";
    public static readonly string LIFE__CHARITY_GIFTS = "-Category_7ed2d08e-8718-4b21-8af9-1bb11c4b0f8f";
    public static readonly string LIFE__CULTURE_SPORT_EVENTS = "-Category_1bde7ebd-1d69-42a6-89ad-147fcdae8ebd";
    public static readonly string LIFE__EDUCATION_DEVELOPMENT = null;
    public static readonly string LIFE__HEALTH_CARE_DOCTOR = "-Category_0c098902-7895-4dfb-b51e-f30088322fb9";
    public static readonly string LIFE__HOBBIES = "-Category_f00f51ff-686e-4a0d-b928-7ce0e1be4594";
    public static readonly string LIFE__HOLIDAYS_TRIPS_HOTELS = "-Category_844982cb-6e6f-42a1-84cf-c2a5930c0a2a";
    public static readonly string LIFE__LIFE_EVENTS = null;
    public static readonly string LIFE__LOTTERY_GAMBLING = "-Category_ee8290d5-3641-4d7b-9e2b-04ddbd27af97";
    public static readonly string LIFE__TV_STREAMING = null;
    public static readonly string LIFE__WELLNESS_BEAUTY = "-Category_0c8d850e-dc5f-4331-b9ea-5c7e62f75638";
    public static readonly string COMMUNICATION_PC = null;
    public static readonly string COMMUNICATION_PC__INTERNET = "-Category_d6616c1d-4d51-43e1-ad91-103c2e6c3c2a";
    public static readonly string COMMUNICATION_PC__PHONE = "-Category_fc29169a-23db-4f39-8ca1-3422e428be1a";
    public static readonly string COMMUNICATION_PC__POSTAL_SERVICES = null;
    public static readonly string COMMUNICATION_PC__SOFTWARE_APPS_GAMES = "-Category_45f5b7c4-3011-4a06-9a2f-b772f2246557";
    public static readonly string FINANCIAL_EXPENSES = "-Category_9460fee4-bc14-4808-a23c-8cd1b31f87b7";
    public static readonly string FINANCIAL_EXPENSES__ADVISORY = null;
    public static readonly string FINANCIAL_EXPENSES__CHARGES_FEES = "-Category_643e3f34-557e-4433-a134-83b570b1a993";
    public static readonly string FINANCIAL_EXPENSES__CHILD_SUPPORT = null;
    public static readonly string FINANCIAL_EXPENSES__FINES = null;
    public static readonly string FINANCIAL_EXPENSES__INSURANCES = null;
    public static readonly string FINANCIAL_EXPENSES__LOAN_INTERESTS = "-Category_c43a1c43-84e9-4234-962f-d02fbdc8fd98";
    public static readonly string FINANCIAL_EXPENSES__TAXES = "-Category_45d57b61-997b-4909-9d55-658243e9d705";
    public static readonly string INVESTMENTS = null;
    public static readonly string INVESTMENTS__COLLECTIONS = null;
    public static readonly string INVESTMENTS__FINANCIAL_INVESTMENTS = null;
    public static readonly string INVESTMENTS__REALTY = null;
    public static readonly string INVESTMENTS__SAVINGS = null;
    public static readonly string INVESTMENTS__VEHICLES_CHATTELS = null;
    public static readonly string INCOME = "-Category_7dfa226c-9f76-456a-98a7-aef1c72ef5e5";
    public static readonly string INCOME__CHECKS_COUPONS = null;
    public static readonly string INCOME__CHILD_SUPPORT = null;
    public static readonly string INCOME__DUES_GRANTS = null;
    public static readonly string INCOME__GIFTS = "-Category_11fdf8fb-3d9e-4fea-b418-7fae77d8ba14";
    public static readonly string INCOME__INTERESTS_DIVIDENDS = "-Category_36f9a720-2426-4e7d-8d14-882ca6ab2cf3";
    public static readonly string INCOME__LENDING_RENTING = "-Category_12d113de-d32e-4b8d-a636-d00438027cb2";
    public static readonly string INCOME__LOTTERY_GAMBLING = "-Category_acc7099b-051c-4c82-abba-e660673ed1e8";
    public static readonly string INCOME__REFUNDS = "-Category_2a9c933e-5cb2-4723-a4c1-964b8c17f361";
    public static readonly string INCOME__RENTAL_INCOME = "-Category_bcb5ba44-e198-422a-a038-a675e2f3f7b6";
    public static readonly string INCOME__SALE = null;
    public static readonly string INCOME__WAGE_INVOICES = "-Category_4f0f341e-ca3d-4686-8805-1fe7be68e227";
    public static readonly string OTHERS = "-Category_75226b2c-9897-4d42-b0b0-cd181b76e119";
    public static readonly string TRANSFER = "-Category_32c3f79d-9782-45a1-8972-6dcbe2ae6cda";

    public static string getNameFromId(string id)
    {
      var type = typeof(StandardCategories);
      var fields = type.GetFields();

      foreach (var field in fields)
      {
        if ((string)field.GetValue(null) == id)
        {
          return field.Name;
        }
      }

      return null;
    }
  }
}