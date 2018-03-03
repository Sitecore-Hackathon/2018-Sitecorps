using Sitecore.Data;
using Sitecore.Data.Items;

namespace Community.Feature.IFTTT.Utils
{
    public static class ItemUtil
    {
        public static Item GetItemById(string id, Database db = null)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;            

            db = db ?? Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database;

            return ID.TryParse(id, out ID itemId) ? db?.GetItem(itemId) : null;
        }
    }
}